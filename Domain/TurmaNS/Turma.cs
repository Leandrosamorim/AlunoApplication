using Domain.Models.AlunoNS;
using Domain.Models.ProfessorNS;
using Domain.Models.TarefaNS;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.TurmaNS
{
    public class Turma
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public Professor? Professor { get; set; }
        public virtual HashSet<Aluno>? Alunos { get; set; } = null;
        public virtual List<Tarefa>? Tarefas { get; set; } = null;

        public Turma()
        {
            this.Alunos = new HashSet<Aluno>();
        }
    }
}
