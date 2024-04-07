using TeatroApi.Models;
using Microsoft.EntityFrameworkCore;

namespace TeatroApi.Data
{
    public class ObraEFRepository : IObraRepository
    {
        private readonly TeatroContext _context;

        public ObraEFRepository(TeatroContext context)
        {
            _context = context;
        }

        public void Add(Obra obra)
        {
            _context.Obras.Add(obra);
            SaveChanges();
        }

        public ObraSimpleDto? Get(int obraId)
        {

            var sesiones = _context.Sesiones
            .Where(sesiones => sesiones.IdSesion == obraId)
            .Select(u => new SesionSimpleDto
            {
                IdSesion = u.IdSesion,
                SesionTime = u.SesionTime

            }).FirstOrDefault();

            var obra = _context.Obras
            .Where(obra => obra.IdPlay == obraId)
            .Select(r => new ObraSimpleDto
            {
                IdPlay = r.IdPlay,
                Name = r.Name,
                Photo = r.Photo,
                Price = r.Price,
                Duration = r.Duration,
            }).FirstOrDefault();

            return obra;
        }


        public void Update(Obra obra)
        {
            _context.Entry(obra).State = EntityState.Modified;
        }

        public void Delete(int obraId)
        {
            var obra = _context.Obras.Find(obraId);
            if (obra is null)
            {
                throw new KeyNotFoundException("Account not found.");
            }
            _context.Obras.Remove(obra);
            SaveChanges();

        }


        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public List<Obra> GetAll()
        {
            return _context.Obras.ToList();

        }
    }
}