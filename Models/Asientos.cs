using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TeatroApi.Models;


public class Asientos
{
    [Key]
    public int IdSeats { get; set; }
    [Required]
    public int Number { get; set; }
    [Required]
    public bool Status { get; set; }
}

public class AsientosReserva
{
    [ForeignKey("Reserva")]
    public int IdReservation { get; set; }
    public Reserva Reserva { get; set; }
}