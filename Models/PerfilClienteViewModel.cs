using Proyecto_DSWI_API_GP3.Data.IRepository;

namespace Proyecto_DSWI_API_GP3.Models
{
    public class PerfilClienteViewModel
    {
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string DNI { get; set; }
        public string Telefono { get; set; }
        public Usuarios Usuarios { get; set; }
    }
}
