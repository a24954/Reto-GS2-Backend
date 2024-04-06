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
    public string  ? Duration { get; set; }
    public decimal Price { get; set; }
    [Required]
    public DateTime  ? Date { get; set; }
    [Required]
    public virtual ICollection<Sesion> Sesiones { get; set; } = new List<Sesion>(); 

}