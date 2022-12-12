using Data.Context;
using Domain.EntregaNS.Interfaces;
using Domain.EntregaNS.Queries;
using Domain.Models.EntregaNS;

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
                _context.Entregas.Add(entrega);
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
                return _context.Entregas.Where(x => x.AlunoId == query.AlunoId || x.Id == query.EntregaId || x.TarefaId == query.TarefaId).ToList();
            }
            catch
            {
                return null;
            }
        }
    }
}
