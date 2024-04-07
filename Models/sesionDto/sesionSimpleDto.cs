namespace TeatroApi.Models
{
    public class SesionSimpleDto
    {
        public int IdSesion { get; set; }
        public string SesionTime { get; set; }

        public int IdPlay { get; set; }

        public List<AsientosSimpleDto> Asientos { get; set; }
        public ObraSimpleDto Obra { get; set; }

    }

}