namespace TeatroAPI.DTOs
{
    public class SesionInsertDto
    {
        public int IdSesion { get; set; }
        public List<AsientosDto> Seats { get; set; }
    }
}