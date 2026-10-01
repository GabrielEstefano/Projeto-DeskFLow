using Microsoft.AspNetCore.Mvc;
using Projeto.Services;

namespace Projeto.Controllers
{
    
    [ApiController]
    [Route("api/categorias")]
    public class CategoriasController : ControllerBase
    {
        private readonly CategoriaS _service;
        public CategoriasController(CategoriaS service)
        {_service = service;}

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var categorias = await _service.ListarAsync();
            return Ok(categorias.Select(c => new {c.Id, c.Nome}));
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> BuscarPorId(int id)
        {
            var categoria = await _service.BuscarPorIdAsync(id);
            if (categoria == null)
            {return NotFound(new { Message = "Categoria não encontrada." });}
            return Ok(new {categoria.Id, categoria.Nome});
        }
        [HttpPost]
        public async Task<IActionResult> Cadastrar([FromBody] CategoriaRequest dados)
        {
             try
            {
                var categoria = await _service.CadastrarAsync(dados.Nome);

                return CreatedAtAction(
                       nameof(BuscarPorId),
                       new { id = categoria.Id },
                       new { categoria.Id, categoria.Nome });
            }
            catch (ArgumentException erro)
            {return BadRequest(new { mensagem = erro.Message });}
        }
        public class CategoriaRequest
        {public string Nome { get; set; } = string.Empty;}
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] CategoriaRequest dados)
        {
            try
            {
                bool atualizado = await _service.AtualizarAsync(id, dados.Nome);
                if (!atualizado)
                {return NotFound(new { Message = "Categoria não encontrada." });}
                return NoContent();
            }
            catch (ArgumentException erro)
            {return BadRequest(new { mensagem = erro.Message });}
        }
    }
}