using Proyecto_DSWI_API_GP3.Data.IRepository;
using Microsoft.AspNetCore.Mvc;
using Proyecto_DSWI_API_GP3.Models;
using Proyecto_DSWI_API_GP3.Models.DTO;
using Microsoft.AspNetCore.Http;
using Proyecto_DSWI_API_GP3.Models.DTO.Usuario;

namespace Proyecto_DSWI_API_GP3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : Controller
    {
        IUsuarios repo;
        public UsuariosController(IUsuarios repositorio)
        {
            repo = repositorio;
        }
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(repo.Listar());
        }
        [HttpPost]
        public IActionResult Registrar(RegistrarDTO usuarios)
        {
            return Ok(repo.Registrar(usuarios));
        }

        [HttpGet("{id}")]
        public IActionResult ObtenerPorId(int id)
        {
            var usuario = repo.ObtenerPorId(id);
            if (usuario == null)
            {
                return NotFound(new { mensaje = "Usuario no encontrado" });
            }
            return Ok(repo.ObtenerPorId(id));
        }

        [HttpPut]
        public IActionResult Actualizar(ActualizarDTO usuarios)
        {
            return Ok(repo.Actualizar(usuarios));
        }

        [HttpDelete("{id}")]
        public IActionResult Eliminar(int id)
        {
            return Ok(repo.Eliminar(id));
        }

    }
}
