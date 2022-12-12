using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.AlunoNS.Query
{
    public class BuscarAlunoQuery
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public int? TurmaId { get; set; }
    }
}
