using Domain.EntregaNS.Queries;
using Domain.Models.EntregaNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.EntregaNS.Interfaces
{
    public interface IEntregaRepository
    {
        public bool Adicionar(Entrega entrega);
        public List<Entrega> Buscar(BuscarEntregaQuery query);
    }
}
