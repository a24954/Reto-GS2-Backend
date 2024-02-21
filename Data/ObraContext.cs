using Microsoft.EntityFrameworkCore;
using TeatroApi.Models;
using Microsoft.Extensions.Configuration;

namespace TeatroApi.Data
{
    public class ObraContext : DbContext
    {

        public ObraContext(DbContextOptions<ObraContext> options)
            : base(options)
        {

        }

      protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Obra>().HasData(
                new Obra { Id = 1, Name = "Lalaland", Description = "La mejor obra", Photo = "https://picsum.photos/200/300", Price = "100" },
                new Obra { Id = 2, Name = "Los 100",  Description = "La mejor obra", Photo = "https://picsum.photos/200/300", Price = "300" },
                new Obra { Id = 3, Name = "Fiesta",  Description = "La mejor obra", Photo = "https://picsum.photos/200/300", Price = "200" }
            );
        }

        public DbSet<Obra> Obra { get; set; }
       
    }
}
