namespace TeatroAPI.DTOs
{
    public class SesionSesiontimeDto
    {
        public int IdSesion { get; set; }
        public List<AsientosDto> Seats { get; set; }
        public DateTime SesionTime { get; set; }
        public int IdPlay { get; set; }
    }
}