using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_DSWI_API_GP3.Data;
using Proyecto_DSWI_API_GP3.Models;
using Proyecto_DSWI_API_GP3.Models.DTO;

namespace Proyecto_DSWI_API_GP3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ClientesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("usuario/{idUsuario}")]
        public ActionResult<PerfilClienteViewModel> GetClientePorUsuario(int idUsuario)
        {
            var cliente = _context.Clientes
                .Include(c => c.Usuarios)
                .FirstOrDefault(c => c.IdUsuario == idUsuario);

            if (cliente == null)
            {
                return NotFound();
            }

            var perfil = new PerfilClienteViewModel
            {
                IdCliente = cliente.IdCliente,
                Nombre = cliente.Nombre,
                DNI = cliente.DNI,
                Telefono = cliente.Telefono,
                Usuarios = new Usuarios
                {
                    IdUsuario = cliente.Usuarios.IdUsuario,
                    Nombre = cliente.Usuarios.Nombre,
                    Correo = cliente.Usuarios.Correo,
                    TipoUsuario = cliente.Usuarios.TipoUsuario
                }
            };

            return Ok(perfil);
        }

        [HttpPut("actualizar/{id}")]
        public async Task<IActionResult> ActualizarPerfil(int id, [FromBody] ClienteDTO perfil)
        {
            if (id != perfil.IdCliente)
            {
                return BadRequest("El ID del cliente no coincide.");
            }

            // Busqueda del cliente en la base de datos
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound("Cliente no encontrado.");
            }

            // Actualizando los datos del cliente
            cliente.Nombre = perfil.Nombre;
            cliente.DNI = perfil.DNI;
            cliente.Telefono = perfil.Telefono;


            try
            {
                // Guardamos los cambios en la base de datos
                await _context.SaveChangesAsync();
                return Ok("Perfil actualizado correctamente.");
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Clientes.Any(c => c.IdCliente == id))
                {
                    return NotFound("Cliente no encontrado.");
                }
                else
                {
                    throw;
                }
            }
        }
    }
}
