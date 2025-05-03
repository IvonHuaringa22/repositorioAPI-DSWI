using Microsoft.AspNetCore.Mvc;
using Proyecto_DSWI_API_GP3.Data.IRepository;
using Proyecto_DSWI_API_GP3.Models;

namespace Proyecto_DSWI_API_GP3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : Controller
    {
        private readonly IEventos _repo;

        public EventosController(IEventos repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            var lista = _repo.Listar();
            return Ok(lista);
        }

        [HttpGet("{id}")]
        public IActionResult Obtener(int id)
        {
            var evento = _repo.ObtenerPorId(id);
            if (evento == null)
                return NotFound();
            return Ok(evento);
        }

        [HttpPost]
        public IActionResult Registrar([FromBody] Eventos evento)
        {
            var exito = _repo.Registrar(evento);
            if (exito)
                return Ok(new { mensaje = "Evento registrado correctamente" });
            return BadRequest(new { mensaje = "Error al registrar el evento" });
        }

        [HttpPut]
        public IActionResult Editar([FromBody] Eventos evento)
        {
            var exito = _repo.Editar(evento);
            if (exito)
                return Ok(new { mensaje = "Evento actualizado correctamente" });
            return BadRequest(new { mensaje = "Error al actualizar el evento" });
        }

        [HttpDelete("{id}")]
        public IActionResult Eliminar(int id)
        {
            var exito = _repo.Eliminar(id);
            if (exito)
                return Ok(new { mensaje = "Evento eliminado correctamente" });
            return BadRequest(new { mensaje = "Error al eliminar el evento" });
        }
    }
}
