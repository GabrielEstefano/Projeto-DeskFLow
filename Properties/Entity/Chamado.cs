using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Properties.Entity
{
    public class Chamado
    {
        public int Id {get; set; }
        public string Titulo {get; set; }
        public string Descricao {get; set; }
        public string Prioridade {get; set; }
        public string Status {get; set; }
        public string SolicitanteNome {get; set; }
        public DateTime DataAbertura {get; set; }
        public DateTime? DataFechamento {get; set; }
        public string? Solucao {get; set; }
        public int CategoriaId {get; set; }
        public virtual Categoria Categoria {get; set; }
        public ICollection<Interacoes> Interacoes { get; set; } = new List<Interacoes>();
    }
}