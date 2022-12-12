using Domain.AlunoNS;
using Domain.AlunoNS.Interfaces;
using Domain.Models.AlunoNS;
using Domain.Models.AlunoNS.Query;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlunoApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly IAlunoService _alunoService;

        public AlunoController(IAlunoService alunoService, IConfiguration configuration)
        {
            _alunoService = alunoService;
            _configuration = configuration;
        }

        [HttpPost]
        public bool Adicionar([FromBody]RegistrarAlunoCommand cmd)
        {
            try
            {
                _alunoService.Adicionar(cmd);
                return true;
            }
            catch
            {
                return false;
            }
        }

        [Authorize]
        [HttpPut]
        public bool Editar([FromBody]EditarAlunoCommand cmd)
        {
            try
            {
                var userId = Int32.Parse(User.FindFirst("id")?.Value);
                if (userId == cmd.Id)
                    _alunoService.Editar(cmd);
                return true;
                throw new Exception("Não pode editar este aluno");
            }
            catch
            {
                return false;
            }
        }

        [Authorize]
        [HttpDelete]
        public bool Deletar(int id)
        {
            try
            {
                var userId = Int32.Parse(User.FindFirst("id")?.Value);
                if (userId == id)
                    _alunoService.Deletar(id);
                return true;
                throw new Exception("Não pode deletar este aluno");
            }
            catch
            {
                return false;
            }
        }

        [HttpGet]
        public List<Aluno> Buscar([FromQuery]BuscarAlunoQuery query)
        {
            try
            {
               var alunos = _alunoService.Buscar(query);
                return alunos;
            }
            catch
            {
                return null;
            }
        }
    }
}
