using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TeatroApi.Models;


public class Sesion
{
    [Key]
    public int IdSesion { get; set; }
    [Required]
    public List<Asientos> Seats { get; set; }
    [Required]
    public DateTime SesionTime { get; set; }
    [ForeignKey("Obra")]
    public int IdPlay { get; set; }
    public virtual Obra Obra { get; set; }
}
