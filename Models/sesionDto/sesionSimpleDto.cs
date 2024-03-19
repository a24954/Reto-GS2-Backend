namespace TeatroAPI.DTOs
{
    public class SesionSimpleDto
    {
        public int IdSesion { get; set; }
        public List<AsientosDto> Seats { get; set; }
        public int IdPlay { get; set; }

    }
}