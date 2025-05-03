using Proyecto_DSWI_API_GP3.Models;

namespace Proyecto_DSWI_API_GP3.Data.IRepository
{
    public interface IZonas
    {
        IEnumerable<Zonas> Listar();
        IEnumerable<Zonas> ListarPorEvento(int idEvento);
    }
}
