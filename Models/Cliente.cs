using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_DSWI_API_GP3.Models
{
    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string DNI { get; set; }
        public string Telefono { get; set; }

        public int IdUsuario { get; set; }
        public Usuarios Usuarios { get; set; }
    }
}
