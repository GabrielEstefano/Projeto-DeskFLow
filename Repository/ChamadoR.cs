using Microsoft.EntityFrameworkCore;
using Projeto.Properties;
using Projeto.Properties.Entity;

namespace Projeto.Repositories
{
    public class ChamadoR
    {
        private readonly AppDbContext _context;

        public ChamadoR(AppDbContext context)
        {_context = context;}

        public async Task<List<Chamado>> ListarAsync()
        {return await _context.Chamados.ToListAsync();}

        public async Task<Chamado?> BuscarPorIdAsync(int id)
        {
            return await _context.Chamados
                .Include(ch => ch.Categoria)
                .Include(ch => ch.Interacoes)
                .FirstOrDefaultAsync(ch => ch.Id == id);
        }

        public async Task<Chamado> CadastrarAsync(Chamado chamado)
        {
            _context.Chamados.Add(chamado);
            await _context.SaveChangesAsync();

            return chamado;
        }

        public async Task AtualizarAsync(Chamado chamado)
        {
            _context.Chamados.Update(chamado);
            await _context.SaveChangesAsync();
        }
    }
}