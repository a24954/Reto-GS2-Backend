using TeatroApi.Models;
using Microsoft.EntityFrameworkCore;

namespace TeatroApi.Data
{
    public class SesionEFRepository : ISesionRepository
    {
        private readonly TeatroContext _context;

        public SesionEFRepository(TeatroContext context)
        {
            _context = context;
        }

        public void Add(Sesion sesion)
        {
            _context.Sesion.Add(sesion);
            SaveChanges();
        }

        public Sesion? Get(int sesionId)
        {
            return _context.Sesion.FirstOrDefault(sesion => sesion.IdSesion == sesionId);
        }

        public void Update(Sesion sesion)
        {
            _context.Entry(sesion).State = EntityState.Modified;
        }

        public void Delete(int sesionId) {
            var sesion = Get(sesionId);
            if (sesion is null) {
                throw new KeyNotFoundException("Account not found.");
            }
            _context.Sesion.Remove(sesion);
            SaveChanges();

        }
        

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public List<Sesion> GetAll()
        {
            return _context.Sesion.ToList();

        }
    }   
}