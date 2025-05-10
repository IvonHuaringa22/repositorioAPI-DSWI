using Microsoft.AspNetCore.Mvc;
using Proyecto_DSWI_API_GP3.Data.IRepository;
using Proyecto_DSWI_API_GP3.Models;

namespace Proyecto_DSWI_API_GP3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventosController : Controller
    {
        IEventos repo;

        public EventosController(IEventos repositorio)
        {
            repo = repositorio;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(repo.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult Obtener(int id)
        {
            var evento = repo.ObtenerPorId(id);
            if (evento == null)
                return NotFound();
            return Ok(evento);
        }

        [HttpGet("Buscar")]
        public IActionResult BuscarPorNombre(string nombre)
        {
            var evento = repo.BuscarPorNombre(nombre);
            if (evento == null)
                return NotFound();
            return Ok(evento);
        }

        [HttpPost]
        public IActionResult Registrar([FromBody] Eventos evento)
        {
            var exito = repo.Registrar(evento);
            if (exito)
                return Ok(new { mensaje = "Evento registrado correctamente" });
            return BadRequest(new { mensaje = "Error al registrar el evento" });
        }

        [HttpPut]
        public IActionResult Editar([FromBody] Eventos evento)
        {
            var exito = repo.Editar(evento);
            if (exito)
                return Ok(new { mensaje = "Evento actualizado correctamente" });
            return BadRequest(new { mensaje = "Error al actualizar el evento" });
        }

        [HttpDelete("{id}")]
        public IActionResult Eliminar(int id)
        {
            var exito = repo.Eliminar(id);
            if (exito)
                return Ok(new { mensaje = "Evento eliminado correctamente" });
            return BadRequest(new { mensaje = "Error al eliminar el evento" });
        }
    }
}
