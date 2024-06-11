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
            _context.Sesiones.Add(sesion);
            SaveChanges();
        }

        public List<SesionSimpleDto>? Get(int sesionId)
        {

            var sesiones = _context.Sesiones
                .Include(s => s.Obra)
                .Include(s => s.Asientos)
                .Where(s => s.IdSesion == sesionId)
                .ToList();

            var sesionesdto = sesiones
                .Select(s => new SesionSimpleDto
                {
                    IdSesion = s.IdSesion,
                    SesionTime = s.SesionTime,
                    Obra = new ObraSimpleDto
                    {
                        IdPlay = s.Obra.IdPlay,
                        Name = s.Obra.Name,
                        Description = s.Obra.Description,
                        Photo = s.Obra.Photo,
                        Price = s.Obra.Price,
                        Duration = s.Obra.Duration
                    },
                    Asientos = s.Asientos.Select(a => new AsientosSimpleDto
                    {
                        IdSeats = a.IdSeats,
                        Number = a.Number,
                        Status = a.Status
                    }).ToList()
                }).ToList();
            return sesionesdto;

            var asientos = _context.Asientos
            .Where(asientos => asientos.IdSeats == sesionId)
            .Select(r => new AsientosSimpleDto
            {
                IdSeats = r.IdSeats,
                Number = r.Number,
                Status = r.Status
            }).ToList();

            var sesion = _context.Sesiones
            .Where(sesiones => sesiones.IdSesion == sesionId)
            .Select(u => new SesionSimpleDto
            {
                IdSesion = u.IdSesion,
                SesionTime = u.SesionTime,
                Asientos = asientos,
            }).ToList();
            return sesion;
        }

        public void Update(SesionSimpleDto sesion)
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

        public List<SesionSimpleDto> GetAll()
        {
            var sesiones = _context.Sesiones
                .Include(s => s.Obra)
                .Include(s => s.Asientos)
                .ToList();

            var sesionesdto = sesiones
                .Select(s => new SesionSimpleDto
                {
                    IdSesion = s.IdSesion,
                    SesionTime = s.SesionTime,
                    Obra = new ObraSimpleDto
                    {
                        IdPlay = s.Obra.IdPlay,
                        Name = s.Obra.Name,
                        Description = s.Obra.Description,
                        Photo = s.Obra.Photo,
                        Price = s.Obra.Price,
                        Duration = s.Obra.Duration
                    },
                    Asientos = s.Asientos.Select(a => new AsientosSimpleDto
                    {
                        IdSeats = a.IdSeats,
                        Number = a.Number,
                        Status = a.Status
                    }).ToList()
                }).ToList();
            return sesionesdto;
        }

    }
}