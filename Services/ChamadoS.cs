using Projeto.Properties.Entity;
using Projeto.Repositories;

namespace Projeto.Services
{
    public class ChamadoS
    {
        private readonly ChamadoR _chamadoR;
        private readonly CategoriaR _categoriaR;

        public ChamadoS(ChamadoR chamadoR, CategoriaR categoriaR)
        {
            _chamadoR = chamadoR;
            _categoriaR = categoriaR;
        }

        public async Task<List<Chamado>> ListarAsync()
        {return await _chamadoR.ListarAsync();}

        public async Task<Chamado?> BuscarPorIdAsync(int id)
        {return await _chamadoR.BuscarPorIdAsync(id);}

        public async Task<Chamado> CadastrarAsync(
            string titulo,
            string descricao,
            string prioridade,
            string solicitanteNome,
            int categoriaId)
        {
            if (string.IsNullOrWhiteSpace(titulo))
            {throw new ArgumentException("O título é obrigatório.");}
            if (string.IsNullOrWhiteSpace(descricao))
            {throw new ArgumentException("A descrição é obrigatória.");}

            if (string.IsNullOrWhiteSpace(solicitanteNome))
            {throw new ArgumentException("O nome do solicitante é obrigatório.");}

            if (prioridade != "Baixa" && prioridade != "Media" && prioridade != "Alta")
            {throw new ArgumentException("A prioridade deve ser Baixa, Media ou Alta.");}

            var categoria = await _categoriaR.BuscarAsyncPorId(categoriaId);

            if (categoria == null)
            {throw new ArgumentException("A categoria não existe.");}

            Chamado chamado = new Chamado
            {
                Titulo = titulo.Trim(),
                Descricao = descricao.Trim(),
                Prioridade = prioridade,
                SolicitanteNome = solicitanteNome.Trim(),
                CategoriaId = categoriaId,
                Status = "Aberto",
                DataAbertura = DateTime.UtcNow,
                DataFechamento = null,
                Solucao = null
            };

            return await _chamadoR.CadastrarAsync(chamado);
        }
    }
}