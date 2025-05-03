using Microsoft.AspNetCore.Mvc;
using Proyecto_DSWI_API_GP3.Data.IRepository;
using Proyecto_DSWI_API_GP3.Models;

namespace Proyecto_DSWI_API_GP3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZonasController : Controller
    {
        private readonly IZonas _zonasRepo;

        public ZonasController(IZonas zonasRepo)
        {
            _zonasRepo = zonasRepo;
        }

        // GET: api/Zonas
        [HttpGet]
        public ActionResult<IEnumerable<Zonas>> GetZonas()
        {
            var zonas = _zonasRepo.Listar();
            return Ok(zonas);
        }

        // GET: api/Zonas/evento/1
        [HttpGet("eventos/{idEvento}")]
        public ActionResult<IEnumerable<Zonas>> GetZonasPorEvento(int idEvento)
        {
            var zonas = _zonasRepo.ListarPorEvento(idEvento);
            return Ok(zonas);
        }
    }
}
