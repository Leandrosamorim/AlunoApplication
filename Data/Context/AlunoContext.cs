using Domain.Models.AlunoNS;
using Domain.Models.AtrasoNS;
using Domain.Models.EntregaNS;
using Domain.Models.FaltaNS;
using Domain.Models.JustificativaNS;
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
        public virtual DbSet<Aluno> Aluno { get; set; }
        public virtual DbSet<Atraso> Atraso { get; set; }
        public virtual DbSet<Falta> Falta { get; set; }
        public virtual DbSet<Justificativa> Justificativa { get; set; }
        public virtual DbSet<Entrega> Entrega { get; set; }
        public virtual DbSet<Turma> Turma { get; set; }
    }
}
