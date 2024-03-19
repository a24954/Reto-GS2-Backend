namespace TeatroAPI.DTOs
{
    public class SesionDto
    {
        public int IdSesion { get; set; }
        public List<AsientosDto> Seats { get; set; }
    }
    public class AsientosDto
    {
        public int Number { get; set; }
        public bool Status { get; set; }
    }
}