namespace TeatroAPI.DTOs
{
    public class ReservaInsertDto
    {
        public string User_Email { get; set; }
        public string ReservationPrice { get; set; }
        public DateTime ReservationDate { get; set; }
    }
}