using Projeto.Properties.Entity;
using Projeto.Repositories;

namespace Projeto.Services
{
    public class CategoriaS
    {
        private readonly CategoriaR _categoriaR;

        public CategoriaS(CategoriaR categoriaR)
        {
            _categoriaR = categoriaR;
        }

        public async Task<List<Categoria>> ListarAsync()
        {
            return await _categoriaR.ListarAsync();
        }

        public async Task<Categoria?>BuscarPorIdAsync(int id)
        {
            return await _categoriaR.BuscarAsyncPorId(id);
        }

        public async Task<Categoria> CadastrarAsync(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {throw new ArgumentException("O nome da categoria é obrigatório!");}

            var categoria = new Categoria
            {Nome = nome.Trim()};

            return await _categoriaR.CadastrarAsync(categoria);
        }
        public async Task AtualizarAsync(int id, string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {throw new ArgumentException("O nome da categoria é obrigatório!");}

            var categoria = await _categoriaR.BuscarAsyncPorId(id);

            if (categoria == null)
            {return false;}

            categoria.Nome = nome.Trim();
            await _categoriaR.AtualuzarAsync(categoria);
            return true;
        }
    }
}