using Domain.Models.AlunoNS;
using Domain.Models.AlunoNS.Query;
using Domain.Models.EntregaNS;
using Domain.Models.TarefaNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.AlunoNS.Interfaces
{
    public interface IAlunoService
    {
        public bool Adicionar(RegistrarAlunoCommand aluno);
        public bool Editar(EditarAlunoCommand aluno);
        public bool Deletar(int alunoId);
        public List<Aluno> Buscar(BuscarAlunoQuery query);
        public Aluno Logar(LogarAlunoCommand cmd);
    }
}
