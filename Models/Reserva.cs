using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TeatroApi.Models;


public class Reserva
{
    [Key]
    public int IdReservation { get; set; }
    [Required]
    public string? User_Email { get; set; }
    [Required]
    public string? ReservationPrice { get; set; }
    [Required]
    public string? ReservationDate { get; set; }
    [Required]
    public int Id_Obra { get; set; }
    
}