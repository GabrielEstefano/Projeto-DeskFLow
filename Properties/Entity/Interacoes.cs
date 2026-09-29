using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Properties.Entity
{
    public class Interacoes
    {
        public int Id {get; set; }
        public string ChamadoId {get; set; }
        public string Autor {get; set; }
        public string mensagem {get; set; }
        public DateTime DataRegistro {get; set; }

        public virtual Chamado Chamado {get; set; }
    }
}