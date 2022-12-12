using Amazon.S3;
using Amazon.S3.Model;
using Domain.AlunoNS.Interfaces;
using Domain.EntregaNS;
using Domain.EntregaNS.Interfaces;
using Domain.Models.AlunoNS;
using Domain.Models.AlunoNS.Interfaces;
using Domain.Models.AlunoNS.Query;
using Domain.Models.EntregaNS;
using Domain.Models.TarefaNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Domain.AlunoNS.Service
{
    public class AlunoService : IAlunoService
    {
        private readonly IAlunoRepository _alunoRepository;
        private readonly IEntregaRepository _entregaRepository;
        private readonly IAmazonS3 _s3Client;
        public AlunoService(IAlunoRepository alunoRepository, IEntregaRepository entregaRepository, IAmazonS3 s3Client)
        {
            _alunoRepository = alunoRepository;
            _entregaRepository = entregaRepository;
            _s3Client = s3Client;
        }

        public bool Adicionar(RegistrarAlunoCommand cmd)
        {
            var aluno = AlunoFactory.RegistrarAluno(cmd);

            try
            {
                _alunoRepository.Registrar(aluno);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Deletar(int alunoId)
        {
            try
            {
                _alunoRepository.Deletar(alunoId);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Editar(EditarAlunoCommand cmd)
        {
            var aluno = AlunoFactory.EditarAluno(cmd);
            try
            {
                _alunoRepository.Editar(aluno);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Aluno Logar(LogarAlunoCommand cmd)
        {
            return _alunoRepository.Logar(cmd.UserName, cmd.Password);
        }

        public List<Aluno> Buscar(BuscarAlunoQuery query)
        {
            return _alunoRepository.Get(query);
        }
    }
}
