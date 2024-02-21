using TeatroApi.Models;
using Microsoft.EntityFrameworkCore;

namespace TeatroApi.Data
{
    public class ObraEFRepository : IObraRepository
    {
        private readonly ObraContext _context;

        public ObraEFRepository(ObraContext context)
        {
            _context = context;
        }

        public void Add(Obra obra)
        {
            _context.Obra.Add(obra);
        }

        public Obra Get(int obraId)
        {
            return _context.Obra.FirstOrDefault(obra => obra.Id == obraId);
        }

        public void Update(Obra obra)
        {
            _context.Entry(obra).State = EntityState.Modified;
        }

        public void Delete(int obraId) {
            var obra = Get(obraId);
            if (obra is null) {
                throw new KeyNotFoundException("Account not found.");
            }
            _context.Obra.Remove(obra);
            SaveChanges();

        }
        

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public List<Obra> GetAll()
        {
            return _context.Obra.ToList();

        }
    }   
}