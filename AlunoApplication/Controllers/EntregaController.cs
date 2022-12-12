using Domain.AlunoNS.Interfaces;
using Domain.AlunoNS;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.EntregaNS.Interfaces;
using Domain.EntregaNS;
using Microsoft.AspNetCore.Authorization;
using BrunoZell.ModelBinding;
using Domain.EntregaNS.Queries;
using Domain.Models.EntregaNS;

namespace AlunoApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntregaController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly IEntregaService _entregaService;

        public EntregaController(IEntregaService entregaService, IConfiguration configuration)
        {
            _entregaService = entregaService;
            _configuration = configuration;
        }

        [Authorize]
        [HttpPost]
        public async Task<bool> Adicionar([ModelBinder(BinderType = typeof(JsonModelBinder))] AdicionarEntregaCommand cmd,
    IFormFile arquivo)
        {
            try
            {
                return await _entregaService.AdicionarEntrega(arquivo, cmd.AlunoId, cmd.TarefaId);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [Authorize]
        [HttpGet]
        public List<Entrega> Buscar([FromQuery]BuscarEntregaQuery query)
        {
            try
            {
                return _entregaService.Buscar(query);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
