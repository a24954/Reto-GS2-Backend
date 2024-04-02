namespace TeatroAPI.DTOs
{
    public class SesionSimpleDto
    {
        public int IdSesion { get; set; }
        public string SesionTime { get; set; }

        public int IdPlay { get; set; }

        public AsientosSimpleDto Asientos { get; set; }

    }

}