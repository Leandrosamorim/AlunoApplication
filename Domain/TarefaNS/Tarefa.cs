using Domain.Models.AlunoNS;
using Domain.Models.EntregaNS;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.TarefaNS
{
    public class Tarefa
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Descricao { get; set; }
        public DateTime DataEntrega { get; set; }
        public virtual HashSet<Entrega>? Entrega { get; set; }

        public Tarefa()
        {
            this.Entrega = new HashSet<Entrega>();
        }
    }
}
