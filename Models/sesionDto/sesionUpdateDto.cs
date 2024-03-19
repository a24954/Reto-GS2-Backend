namespace TeatroAPI.DTOs
{
    public class SesionUpdateDto
    {
        public List<AsientosDto> Seats { get; set; }
        public DateTime SesionTime { get; set; }

    }
}