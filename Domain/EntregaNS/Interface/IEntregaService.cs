using Domain.EntregaNS.Query;
using Domain.Models.EntregaNS;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.EntregaNS.Interfaces
{
    public interface IEntregaService
    {
        public Task<bool> AdicionarEntrega(IFormFile arquivo, int alunoId, int tarefaId);
        public List<Entrega> Buscar(BuscarEntregaQuery query);
    }
}
