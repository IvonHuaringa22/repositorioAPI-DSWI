using Proyecto_DSWI_API_GP3.Models;
using Proyecto_DSWI_API_GP3.Models.DTO;

namespace Proyecto_DSWI_API_GP3.Data.IRepository
{
    public interface IUsuarios
    {
        IEnumerable<Usuarios> Listar();
        Usuarios ObtenerPorId(int id);
        bool Registrar(UsuariosDTO usuarios);
        bool Actualizar(Usuarios usuarios);
        bool Eliminar(int id);
    }
}
