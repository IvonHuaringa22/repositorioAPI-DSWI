using Proyecto_DSWI_API_GP3.Data.IRepository;
using Proyecto_DSWI_API_GP3.Models;

namespace Proyecto_DSWI_API_GP3.Data.Repository
{
    public class ZonasRepository : IZonas
    {
        private readonly ApplicationDbContext _context;

        public ZonasRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Zonas> Listar()
        {
            return _context.Zonas.ToList();
        }

        public IEnumerable<Zonas> ListarPorEvento(int idEvento)
        {
            return _context.Zonas.Where(z => z.IdEvento == idEvento).ToList();
        }
    }
}
