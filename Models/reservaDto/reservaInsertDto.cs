namespace TeatroApi.Models
{
    public class ReservaInsertDto
    {
        public int IdReservation { get; set; }
        public string User_Email { get; set; }
        public string ReservationPrice { get; set; }
        public DateTime ReservationDate { get; set; }
        
        public int IdPlay { get; set; }
    }
}