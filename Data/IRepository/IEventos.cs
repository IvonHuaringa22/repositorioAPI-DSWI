using Proyecto_DSWI_API_GP3.Models;

namespace Proyecto_DSWI_API_GP3.Data.IRepository
{
    public interface IEventos
    {
        IEnumerable<Eventos> Listar();
        Eventos ObtenerPorId(int id);
        bool Registrar(Eventos evento);
        bool Editar(Eventos evento);
        bool Eliminar(int id);
    }
}
