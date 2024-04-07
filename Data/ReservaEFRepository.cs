using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TeatroApi.Models;

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
            var reserva = _context.Reservas
                .Include(r => r.Obra)
                .FirstOrDefault(r => r.IdReservation == reservaId);

            if (reserva == null)
                return null;

            return new ReservaSimpleDto
            {
                IdReservation = reserva.IdReservation,
                User_Email = reserva.User_Email,
                ReservationPrice = reserva.ReservationPrice,
                ReservationDate = reserva.ReservationDate,
                Obra = new ObraSimpleDto
                {
                    Name = reserva.Obra.Name,
                    Description = reserva.Obra.Description,
                    Photo = reserva.Obra.Photo,
                    Price = reserva.Obra.Price,
                    Duration = reserva.Obra.Duration
                },
                IdUser = reserva.IdUser,
                IdSeats = reserva.IdSeats,
                IdPlay = reserva.IdPlay
            };
        }

        public void Update(Reserva reserva)
        {
            _context.Entry(reserva).State = EntityState.Modified;
            SaveChanges();
        }

        public void Delete(int reservaId)
        {
            var reserva = _context.Reservas.Find(reservaId);
            if (reserva == null)
            {
                throw new KeyNotFoundException("Reservation not found.");
            }

            _context.Reservas.Remove(reserva);
            SaveChanges();
        }

        public List<ReservaSimpleDto> GetAll()
        {
            var reservas = _context.Reservas
                .Include(r => r.Obra)
                .ToList();

            return reservas.Select(r => new ReservaSimpleDto
            {
                IdReservation = r.IdReservation,
                User_Email = r.User_Email,
                ReservationPrice = r.ReservationPrice,
                ReservationDate = r.ReservationDate,
                Obra = new ObraSimpleDto
                {
                    Name = r.Obra.Name,
                    Description = r.Obra.Description,
                    Photo = r.Obra.Photo,
                    Price = r.Obra.Price,
                    Duration = r.Obra.Duration
                },
                IdUser = r.IdUser,
                IdSeats = r.IdSeats,
                IdPlay = r.IdPlay
            }).ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
