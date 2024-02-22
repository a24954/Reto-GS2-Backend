using TeatroApi.Models;
using Microsoft.EntityFrameworkCore;

namespace TeatroApi.Data
{
    public class ReservaEFRepository : IReservaRepository
    {
        private readonly TeatroContext _context;

        public ReservaEFRepository(TeatroContext context)
        {
            _context = context;
        }

        public void Add(Reserva reserva)
        {
            _context.Reserva.Add(reserva);
        }

        public Reserva Get(int reservaId)
        {
            return _context.Reserva.FirstOrDefault(reserva => reserva.IdReservation == reservaId);
        }

        public void Update(Reserva reserva)
        {
            _context.Entry(reserva).State = EntityState.Modified;
        }

        public void Delete(int reservaId) {
            var reserva = Get(reservaId);
            if (reserva is null) {
                throw new KeyNotFoundException("Account not found.");
            }
            _context.Reserva.Remove(reserva);
            SaveChanges();

        }
        

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public List<Reserva> GetAll()
        {
            return _context.Reserva.ToList();

        }
    }   
}