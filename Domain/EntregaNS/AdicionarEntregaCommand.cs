using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.EntregaNS
{
    public class AdicionarEntregaCommand
    {
        [Required]
        public int TarefaId { get; set; }
        public int AlunoId { get; set; }
    }
}
