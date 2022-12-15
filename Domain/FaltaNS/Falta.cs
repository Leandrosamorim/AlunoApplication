using Domain.Models.EntregaNS;
using Domain.Models.JustificativaNS;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.FaltaNS
{
    public class Falta
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Aluno")]
        [Required]
        public int AlunoId { get; set; }
        public DateTime Data { get; set; }
        public virtual Justificativa? Justificativa {get;set;}

        public Falta()
        {
            this.Justificativa = new Justificativa();
        }
    }
}
