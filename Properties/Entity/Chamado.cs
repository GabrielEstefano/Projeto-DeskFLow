using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Properties.Entity
{
    public class Chamado
    {
        public int Id {get; set; }
        public string Descricao {get; set; }
        public int CategoriaId {get; set; }
        public virtual Categoria Categoria {get; set; }
    }
}