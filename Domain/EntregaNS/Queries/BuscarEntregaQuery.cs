using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.EntregaNS.Queries
{
    public class BuscarEntregaQuery
    {
        public int AlunoId { get; set; }
        public int EntregaId { get; set; }
        public int TarefaId { get; set; }
    }
}
