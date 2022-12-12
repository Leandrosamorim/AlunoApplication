using Data.Context;
using Domain.Models.AlunoNS;
using Domain.Models.AlunoNS.Interfaces;
using Domain.Models.AlunoNS.Query;
using Microsoft.EntityFrameworkCore;
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
                _context.Alunos.Remove(new Aluno() { Id = alunoId });
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
            var alunos = _context.Alunos.Where(x => x.Id == query.Id || x.Nome == query.Name || x.TurmaId == query.TurmaId).ToList();
            return alunos;
        }

        public bool Registrar(Aluno aluno)
        {
            try
            {
                _context.Alunos.Add(aluno);
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
            return _context.Alunos.FirstOrDefault(u => u.UserName == userName && u.Password == password);
        }
    }
}
