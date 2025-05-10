using System.ComponentModel.DataAnnotations;

namespace Proyecto_DSWI_API_GP3.Models.DTO
{
    public class UsuariosDTO
    {
        public int IdUsuario { get; set; }

        public string Nombre { get; set; }

        public string Correo { get; set; }

        public string Contraseña { get; set; }

        public string TipoUsuario { get; set; } // "Cliente" o "Administrador"
    }
}
