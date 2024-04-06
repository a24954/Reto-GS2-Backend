using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TeatroApi.Models;


public class Reserva
{
    [Key]
    public int IdReservation { get; set; }
    [Required]
    public string User_Email { get; set; }
    [Required]
    public string ReservationPrice { get; set; }
    [Required]
    public DateTime ReservationDate { get; set; }

    public int IdUser { get; set; }

    public int IdPlay { get; set; }
    public virtual Obra Obra { get; set; }

}