using TeatroApi.Models;
using Microsoft.EntityFrameworkCore;

namespace TeatroApi.Data
{
    public class AsientosEFRepository : IAsientosRepository
    {
        private readonly TeatroContext _context;

        public AsientosEFRepository(TeatroContext context)
        {
            _context = context;
        }

        public void Add(Asientos asientos)
        {
            _context.Asientos.Add(asientos);
            SaveChanges();
        }

        public Asientos? Get(int asientosId)
        {
            return _context.Asientos.FirstOrDefault(asientos => asientos.IdSeats == asientosId);
        }

        public void Update(Asientos asientos)
        {
            var existingAsientos = _context.Asientos.Find(asientos.IdSeats, asientos.IdUser);
            if (existingAsientos != null)
            {
                existingAsientos.Number = asientos.Number;
                existingAsientos.Status = asientos.Status;

                _context.Entry(existingAsientos).State = EntityState.Modified;

                SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException("Asientos not found.");
            }
        }



        public void Delete(int asientosId)
        {
            var asientos = Get(asientosId);
            if (asientos is null)
            {
                throw new KeyNotFoundException("Account not found.");
            }
            _context.Asientos.Remove(asientos);
            SaveChanges();

        }


        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public List<Asientos> GetAll()
        {
            return _context.Asientos.ToList();

        }
    }
}