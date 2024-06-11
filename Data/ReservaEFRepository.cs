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

        public List<ReservaSimpleDto>? Get(int reservaId)
        {
            var reservas = _context.Reservas
            .Where(r => r.IdSesion == reservaId)
            .Select(reserva => new ReservaSimpleDto
            {
                IdReservation = reserva.IdReservation,
                User_Email = reserva.User_Email,
                ReservationPrice = reserva.ReservationPrice,
                ReservationDate = reserva.ReservationDate,
                IdUser = reserva.IdUser,
                IdSeats = reserva.IdSeats,
                IdSesion = reserva.IdSesion,
                ListaSeats = reserva.ListaSeats
            }).ToList();
            return reservas;
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
                .ToList();

            return reservas.Select(r => new ReservaSimpleDto
            {
                IdReservation = r.IdReservation,
                User_Email = r.User_Email,
                ReservationPrice = r.ReservationPrice,
                ReservationDate = r.ReservationDate,
                IdUser = r.IdUser,
                IdSeats = r.IdSeats,
                IdSesion = r.IdSesion,
                ListaSeats = r.ListaSeats
            }).ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
