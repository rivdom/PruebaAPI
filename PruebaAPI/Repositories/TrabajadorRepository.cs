using PruebaAPI.Data;
using PruebaAPI.Models;
using PruebaAPI.Repositories.IRepositories;

namespace PruebaAPI.Repositories
{
    public class TrabajadorRepository : ITrabajadorRepository
    {
        private readonly ApplicationDBContext _db;
        public TrabajadorRepository(ApplicationDBContext db)
        {
            _db = db;
        }

        public bool CreateTrabajador(Trabajador trabajador)
        {
           trabajador.FechaCreacion = DateTime.Now;
            _db.Trabajador.Add(trabajador);
            return SaveTrabajador();
        }

        public ICollection<Trabajador> GetTrabajadores()
        {
            return _db.Trabajador.OrderBy(t => t.Nombre).ToList();
        }

        public Trabajador GetOneTrabajador(int TrabajadorId)
        {
            return _db.Trabajador.FirstOrDefault(t => t.Id == TrabajadorId);
        }
        public bool UpdateTrabajador(Trabajador trabajador)
        {
            trabajador.FechaCreacion = DateTime.Now;
            _db.Trabajador.Update(trabajador);
            return SaveTrabajador();
        }
        public bool DeleteTrabajador(Trabajador trabajador)
        {
            _db.Trabajador.Remove(trabajador);
            return SaveTrabajador();
        }
        public bool SaveTrabajador()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }


    }
}
