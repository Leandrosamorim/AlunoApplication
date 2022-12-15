using Data.Context;
using Domain.EntregaNS.Interfaces;
using Domain.EntregaNS.Query;
using Domain.Models.EntregaNS;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class EntregaRepository : IEntregaRepository
    {
        private readonly AlunoContext _context;
        public EntregaRepository(AlunoContext context)
        {
            _context = context;
        }

        public bool Adicionar(Entrega entrega)
        {
            try
            {
                _context.Entrega.Add(entrega);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Entrega> Buscar(BuscarEntregaQuery query)
        {
            try
            {
                var entregas = _context.Entrega.Where(x => x.AlunoId == query.AlunoId || x.Id == query.EntregaId || x.TarefaId == query.TarefaId).Include(e => e.Avaliacao).ToList();
                return entregas;
            }
            catch
            {
                return null;
            }
        }
    }
}
