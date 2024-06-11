namespace TeatroApi.Models
{
    public class ReservaInsertDto
    {
        public string User_Email { get; set; }
        public string ReservationPrice { get; set; }
        public DateTime ReservationDate { get; set; }
        public int IdSesion { get; set; }
        public string ListaSeats { get; set; }
    }
}