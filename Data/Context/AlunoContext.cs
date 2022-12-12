using Domain.Models.AlunoNS;
using Domain.Models.EntregaNS;
using Domain.Models.TurmaNS;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public class AlunoContext : DbContext
    {
        public AlunoContext(DbContextOptions<AlunoContext> options) : base(options)
        {

        }
        public virtual DbSet<Aluno> Alunos { get; set; }
        public virtual DbSet<Entrega> Entregas { get; set; }
        public virtual DbSet<Turma> Turmas { get; set; }
    }
}
