using System;

namespace TeatroApi.Models
{
    public class ReservaSimpleDto
    {
        public int IdReservation { get; set; }
        public string User_Email { get; set; }
        public string ReservationPrice { get; set; }
        public DateTime ReservationDate { get; set; }
        public ObraSimpleDto Obra { get; set; }
        public int IdUser { get; set; }
        public int IdSeats { get; set; }
        public int IdPlay { get; set; }
        public string ListaSeats { get; set; }
    }
}
