using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TeatroApi.Models;


public class Reserva
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdReservation { get; set; }
    [Required]
    public string User_Email { get; set; }
    [Required]
    public string ReservationPrice { get; set; }
    [Required]
    public DateTime ReservationDate { get; set; }
    public string ListaSeats { get; set; }

    public int IdUser { get; set; }

    public int IdSeats { get; set; }

    public int IdSesion { get; set; }

}