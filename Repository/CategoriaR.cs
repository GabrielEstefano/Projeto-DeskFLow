using Microsoft.EntityFrameworkCore;
using Projeto.Properties;
using Projeto.Properties.Entity;

namespace Projeto.Repositories
{
    public class CategoriaR
    {
        private readonly AppDbContext _context;
        public CategoriaR(AppDbContext context)
        { _context = context;}

        public async Task<List<Categoria>> ListarAsync()
        {return await _context.categorias.ToListAsync();}

        public async Task<Categoria?> BuscarAsyncPorId(int id)
        {return await _context.categorias.FindAsync(id);}

        public async Task<Categoria> CadastrarAsync(Categoria categoria)
        {
            _context.categorias.Add(categoria);
            await _context.SaveChangesAsync();
            return categoria;
        }
        public async Task AtualizarAsync(Categoria categoria)
        {
            _context.categorias.Update(categoria);
            await _context.SaveChangesAsync();
        }

    }
}
