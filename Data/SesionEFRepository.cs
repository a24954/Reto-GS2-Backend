using TeatroApi.Models;
using Microsoft.EntityFrameworkCore;
using TeatroAPI.DTOs;

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
            _context.Sesiones.Add(sesion);
            SaveChanges();
        }

        public SesionSimpleDto? Get(int sesionId)
        {

            var asientos = _context.Asientos
            .Where(asientos => asientos.IdSeats == sesionId)
            .Select(r => new AsientosSimpleDto
            {
                IdSeats = r.IdSeats,
                Number = r.Number,
                Status = r.Status
            }).FirstOrDefault();

            var sesion = _context.Sesiones
            .Where(sesiones => sesiones.IdSesion == sesionId)
            .Select(u => new SesionSimpleDto
            {
                IdSesion = u.IdSesion,
                SesionTime = u.SesionTime,
                Asientos = asientos
            }).FirstOrDefault();
            return sesion;
        }

        public void Update(Sesion sesion)
        {
            _context.Entry(sesion).State = EntityState.Modified;
        }

        public void Delete(int sesionId)
        {
            var sesion = _context.Sesiones.Find(sesionId);
            if (sesion is null)
            {
                throw new KeyNotFoundException("Account not found.");
            }
            _context.Sesiones.Remove(sesion);
            SaveChanges();

        }


        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public List<Sesion> GetAll()
        {
            return _context.Sesiones.ToList();

        }
    }
}