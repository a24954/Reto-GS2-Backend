using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TeatroApi.Models;


public class Sesion
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdSesion { get; set; }
    [Required]
    public List<Asientos> Asientos { get; set; } = new List<Asientos>(); 
    [Required]
    public string SesionTime { get; set; }
    public int IdPlay { get; set; }
    public virtual Obra Obra { get; set; }
    public int IdSeats { get; set; }
}
