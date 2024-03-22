using TeatroApi.Models;
using Microsoft.EntityFrameworkCore;
using TeatroAPI.DTOs;

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
            _context.Reservas.Add(reserva);
            SaveChanges();
        }

        public ReservaSimpleDto? Get(int reservaId)
        {

            var sesiones = _context.Sesiones
            .Where(sesiones => sesiones.IdSesion == reservaId)
            .Select(p => new SesionSimpleDto
            {
                IdSesion = p.IdSesion,
                SesionTime = p.SesionTime,
            }).FirstOrDefault();

            var usuarios = _context.Usuarios
            .Where(usuarios => usuarios.IdUser == reservaId)
            .Select(u => new UsuarioSimpleDto
            {
                UserName = u.IdUser.ToString()
            }).FirstOrDefault();

            var asientos = _context.Asientos
            .Where(asientos => asientos.IdSeats == reservaId)
            .Select(s => new AsientosSimpleDto
            {
                IdSeats = s.IdSeats,
                Number = s.Number,
                Status = s.Status,
            }).FirstOrDefault();

            var obra = _context.Obras
            .Where(obra => obra.IdPlay == reservaId)
            .Select(o => new ObraSimpleDto
            {
                IdPlay = o.IdPlay,
                Name = o.Name,
                Photo = o.Photo,
                Price = o.Price,
            }).FirstOrDefault();

            var reserva = _context.Reservas
            .Where(reserva => reserva.IdReservation == reservaId)
            .Select(r => new ReservaSimpleDto
            {
                IdReservation = r.IdReservation,
                User_Email = r.User_Email,
                ReservationPrice = r.ReservationPrice,
                Obra = obra,
                Asientos = asientos,
                Usuario = usuarios,
                Sesion = sesiones
            }).FirstOrDefault();

            return reserva;
        }

        public void Update(Reserva reserva)
        {
            _context.Entry(reserva).State = EntityState.Modified;
        }

        public void Delete(int reservaId)
        {
            var reserva = _context.Reservas.Find(reservaId);
            if (reserva is null)
            {
                throw new KeyNotFoundException("Account not found.");
            }
            _context.Reservas.Remove(reserva);
            SaveChanges();

        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public List<Reserva> GetAll()
        {
            return _context.Reservas.ToList();

        }
    }
}