using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Properties.Entity
{
    public class Categoria
    {
        public int Id {get; set; }
        public string Nome {get; set; }
        public virtual ICollection<Chamado> Chamados {get; set; }
    }
}