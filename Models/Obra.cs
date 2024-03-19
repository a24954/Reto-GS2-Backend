using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TeatroApi.Models;


public class Obra
{
    [Key]
    public int IdPlay { get; set; }
    [Required]
    public string ? Name  { get; set; }
    [Required]
    public string ? Description { get; set; }
    [Required]
    public string  ? Photo { get; set; }
    [Required]
    public decimal Price { get; set; }

    public virtual ICollection<Sesion> Sesiones { get; set; }
    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>(); 
}