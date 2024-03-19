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

        public Obra? Get(int obraId)
        {
            return _context.Obras.FirstOrDefault(obra => obra.IdPlay == obraId);
        }


        public void Update(Obra obra)
        {
            _context.Entry(obra).State = EntityState.Modified;
        }

        public void Delete(int obraId)
        {
            var obra = Get(obraId);
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