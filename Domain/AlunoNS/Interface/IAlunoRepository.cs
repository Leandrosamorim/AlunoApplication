using Domain.Models.AlunoNS.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.AlunoNS.Interfaces
{
    public interface IAlunoRepository
    {
        public bool Registrar(Aluno aluno);
        public List<Aluno> Get(BuscarAlunoQuery query);
        public bool Deletar(int alunoId);
        public bool Editar(Aluno aluno);
        public Aluno Logar(string userName, string password);
    }
}
