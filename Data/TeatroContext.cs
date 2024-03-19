using Microsoft.EntityFrameworkCore;
using TeatroApi.Models;
using System.Collections.Generic;

namespace TeatroApi.Data
{
    public class TeatroContext : DbContext
    {
        public TeatroContext(DbContextOptions<TeatroContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Reserva>()
                .HasOne<Usuario>(r => r.Usuario)
                .WithMany(u => u.Reservas)
                .HasForeignKey(r => r.IdUser);

            modelBuilder.Entity<Reserva>()
                .HasOne(r => r.Obra)
                .WithMany(o => o.Reservas)
                .HasForeignKey(r => r.IdPlay);

            modelBuilder.Entity<Sesion>()
                .HasOne<Obra>(s => s.Obra)
                .WithMany(o => o.Sesiones)
                .HasForeignKey(s => s.IdPlay);

            modelBuilder.Entity<Obra>().HasData(
                new Obra { IdPlay = 1, Name = "Lalaland", Description = "Una descripción", Photo = "https://picsum.photos/200/300", Price = 100 },
                new Obra { IdPlay = 2, Name = "Los 100", Description = "Otra descripción", Photo = "https://picsum.photos/200/300", Price = 300 },
                new Obra { IdPlay = 3, Name = "Fiesta", Description = "Otra más", Photo = "https://picsum.photos/200/300", Price = 200 }
            );

            modelBuilder.Entity<Reserva>().HasData(
                new Reserva { IdReservation = 1, User_Email = "user1@example.com", ReservationPrice = "100", ReservationDate = new DateTime(2024, 3, 20), IdUser = 1, IdPlay = 1 },
                new Reserva { IdReservation = 2, User_Email = "user2@example.com", ReservationPrice = "200", ReservationDate = new DateTime(2024, 3, 21), IdUser = 2, IdPlay = 2 },
                new Reserva { IdReservation = 3, User_Email = "user3@example.com", ReservationPrice = "300", ReservationDate = new DateTime(2024, 3, 22), IdUser = 3, IdPlay = 3 }
            );


            modelBuilder.Entity<Asientos>().HasData(
                new Asientos { IdSeats = 1, Number = 1, Status = true },
                new Asientos { IdSeats = 2, Number = 2, Status = false },
                new Asientos { IdSeats = 3, Number = 3, Status = true }
            );

            modelBuilder.Entity<Sesion>().HasData(
                new Sesion { IdSesion = 1, IdPlay = 1, SesionTime = new DateTime(2024, 3, 20, 10, 0, 0) },
                new Sesion { IdSesion = 2, IdPlay = 2, SesionTime = new DateTime(2024, 3, 21, 10, 30, 0) },
                new Sesion { IdSesion = 3, IdPlay = 3, SesionTime = new DateTime(2024, 3, 22, 20, 30, 0) }
            );

            modelBuilder.Entity<Usuario>().HasData(
                new Usuario { IdUser = 1, UserName = "cosmar", Password = "123", Email = "hola1@gmail.com", Rol = Usuario.UserRole.Admin },
                new Usuario { IdUser = 2, UserName = "cosmari", Password = "123", Email = "hola2@gmail.com", Rol = Usuario.UserRole.StandardUser },
                new Usuario { IdUser = 3, UserName = "cosmaro", Password = "123", Email = "hola3@gmail.com", Rol = Usuario.UserRole.StandardUser }
            );
        }

        public DbSet<Obra> Obras { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Asientos> Asientos { get; set; }
        public DbSet<Sesion> Sesiones { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
