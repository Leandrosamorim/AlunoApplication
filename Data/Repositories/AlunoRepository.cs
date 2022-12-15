using Data.Context;
using Domain.Models.AlunoNS;
using Domain.Models.AlunoNS.Interfaces;
using Domain.Models.AlunoNS.Query;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly AlunoContext _context;
        public AlunoRepository(AlunoContext context)
        {
            _context = context;
        }

        public bool Deletar(int alunoId)
        {
            try
            {
                _context.Aluno.Remove(new Aluno() { Id = alunoId });
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Editar(Aluno aluno)
        {
            try
            {
                _context.Update(aluno);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Aluno> Get(BuscarAlunoQuery query)
        {
            var alunos = _context.Aluno.Where(x =>
            x.Id == query.Id || x.Nome == query.Name || (query.TurmaId == null ? false : query.TurmaId.Contains(x.TurmaId))).Include(a => a.Atrasos).Include(a => a.Faltas).Include(a => a.Entregas);
            var result = alunos.ToList();
            return result;
        }

        public bool Registrar(Aluno aluno)
        {
            try
            {
                _context.Aluno.Add(aluno);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Aluno Logar(string userName, string password)
        {
            return _context.Aluno.FirstOrDefault(u => u.UserName == userName && u.Password == password);
        }
    }
}
