using Microsoft.AspNetCore.Mvc;
using Projeto.Services;

namespace Projeto.Controllers
{
    [ApiController]
    [Route("api/chamados")]
    public class ChamadosController : ControllerBase
    {
        private readonly ChamadoS _service;

        public ChamadosController(ChamadoS service)
        {_service = service;}

        [HttpPost]
        public async Task<IActionResult> Cadastrar([FromBody] ChamadoRequest dados)
        {
            try
            {
                var chamado = await _service.CadastrarAsync(
                    dados.Titulo,
                    dados.Descricao,
                    dados.Prioridade,
                    dados.SolicitanteNome,
                    dados.CategoriaId);

                return StatusCode(201, new
                {
                    chamado.Id,
                    chamado.Titulo,
                    chamado.Descricao,
                    chamado.Prioridade,
                    chamado.Status,
                    chamado.SolicitanteNome,
                    chamado.CategoriaId,
                    chamado.DataAbertura,
                    chamado.DataFechamento,
                    chamado.Solucao
                });
            }
            catch (ArgumentException erro)
            {return BadRequest(new { mensagem = erro.Message });}
        }
    }

    public class ChamadoRequest
    {
        public string Titulo { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public string Prioridade { get; set; } = string.Empty;
        public string SolicitanteNome { get; set; } = string.Empty;
        public int CategoriaId { get; set; }
    }
}