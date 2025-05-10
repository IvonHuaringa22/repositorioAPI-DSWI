using Proyecto_DSWI_API_GP3.Models;
using Proyecto_DSWI_API_GP3.Models.DTO;
using Proyecto_DSWI_API_GP3.Models.DTO.Usuario;

namespace Proyecto_DSWI_API_GP3.Data.IRepository
{
    public interface IUsuarios
    {
        IEnumerable<Usuarios> Listar();
        Usuarios ObtenerPorId(int id);
        bool Registrar(RegistrarDTO usuarios);
        bool Actualizar(ActualizarDTO usuarios);
        bool Eliminar(int id);
    }
}
