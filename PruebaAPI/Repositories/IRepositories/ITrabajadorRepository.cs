using PruebaAPI.Models;

namespace PruebaAPI.Repositories.IRepositories
{
    public interface ITrabajadorRepository
    {
        ICollection<Trabajador> GetTrabajadores();
        Trabajador GetOneTrabajador(int TrabajadorId);
        bool CreateTrabajador(Trabajador trabajador);
        bool UpdateTrabajador(Trabajador trabajador);
        bool DeleteTrabajador(Trabajador trabajador);
        bool SaveTrabajador();

    }
}
