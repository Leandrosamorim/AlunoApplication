using Domain.AlunoNS;
using Domain.Models.AtrasoNS;
using Domain.Models.EntregaNS;
using Domain.Models.FaltaNS;
using Domain.Models.JustificativaNS;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.AlunoNS
{
    public class Aluno
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        [ForeignKey("Turma")]
        public int TurmaId { get; set; }
        public virtual HashSet<Falta>? Faltas { get; set; }
        public virtual HashSet<Atraso>? Atrasos { get; set; }
        public virtual HashSet<Entrega>? Entregas { get; set; }

        public Aluno()
        {
            this.Faltas = new HashSet<Falta>();
            this.Atrasos = new HashSet<Atraso>();
            this.Entregas = new HashSet<Entrega>();
        }
    }

    public static class AlunoFactory
    {
        public static Aluno RegistrarAluno(RegistrarAlunoCommand cmd)
        {
            return new Aluno()
            {
                Nome = cmd.Nome,
                TurmaId = cmd.TurmaId,
                UserName = cmd.UserName,
                Password = cmd.Password
            };
        }

        public static Aluno EditarAluno(EditarAlunoCommand cmd)
        {
            return new Aluno()
            {
                Id = cmd.Id,
                Nome = cmd.Nome,
                TurmaId = cmd.TurmaId,
                UserName = cmd.Username,
                Password = cmd.Password
            };
        }
    }
}
