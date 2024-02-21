using Microsoft.EntityFrameworkCore;
using TeatroApi.Models;
using Microsoft.Extensions.Configuration;

namespace TeatroApi.Data
{
    public class TeatroContext : DbContext
    {

        public TeatroContext(DbContextOptions<TeatroContext> options)
            : base(options)
        {

        }

        public enum UserRole
        {
            Admin,
            StandardUser
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Obra>().HasData(
                new Obra { IdPlay = 1, Name = "Lalaland", Description = "La mejor obra", Photo = "https://picsum.photos/200/300", Price = "100" },
                new Obra { IdPlay = 2, Name = "Los 100", Description = "La mejor obra", Photo = "https://picsum.photos/200/300", Price = "300" },
                new Obra { IdPlay = 3, Name = "Fiesta", Description = "La mejor obra", Photo = "https://picsum.photos/200/300", Price = "200" }
            );
            modelBuilder.Entity<Reserva>().HasData(
                new Reserva { IdReservation = 1, User_Email = "Lalaland", ReservationPrice = "La mejor obra", ReservationDate = "https://picsum.photos/200/300", Id_Obra = 1 },
                new Reserva { IdReservation = 2, User_Email = "Los 100", ReservationPrice = "La mejor obra", ReservationDate = "https://picsum.photos/200/300", Id_Obra = 2 },
                new Reserva { IdReservation = 3, User_Email = "Fiesta", ReservationPrice = "La mejor obra", ReservationDate = "https://picsum.photos/200/300", Id_Obra = 3 }
            );
            modelBuilder.Entity<Asientos>().HasData(
                new Asientos { IdSeats = 1, Number = 1, Status = true },
                new Asientos { IdSeats = 1, Number = 2, Status = false },
                new Asientos { IdSeats = 1, Number = 3, Status = true }
            );
            var listaasientos = new List<Asientos>();
            modelBuilder.Entity<Sesion>().HasData(
                new Sesion { IdSesion = 1, Seats = listaasientos, SesionTime = new DateTime(1, 1, 1, 10, 0, 0) },
                new Sesion { IdSesion = 2, Seats = listaasientos, SesionTime = new DateTime(1, 1, 1, 10, 30, 0) },
                new Sesion { IdSesion = 3, Seats = listaasientos, SesionTime = new DateTime(1, 1, 1, 20, 30, 0) }
            );
            var rol = TeatroApi.Models.Usuario.UserRole.StandardUser;
            var rol2 = TeatroApi.Models.Usuario.UserRole.Admin;
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario { IdUser = 1, UserName = "cosmar", Password = "123", Email = "hola1@gmail.com", Rol = rol2 },
                new Usuario { IdUser = 2, UserName = "cosmari", Password = "123", Email = "hola2@gmail.com", Rol = rol },
                new Usuario { IdUser = 3, UserName = "cosmaro", Password = "123", Email = "hola3@gmail.com", Rol = rol }
            );
        }

        DbContextOptions<TeatroContext> options;
        public DbSet<Obra> Obra { get; set; }
        public DbSet<Reserva> Reserva { get; set; }
        public DbSet<Asientos> Asientos { get; set; }
        public DbSet<Sesion> Sesion { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

    }
}
