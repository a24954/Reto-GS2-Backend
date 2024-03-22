using TeatroApi.Models;

namespace TeatroAPI.DTOs
{
    public class ReservaSimpleDto
    {
        public int IdReservation { get; set; }
        public string User_Email { get; set; }
        public string ReservationPrice { get; set; }

        public ObraSimpleDto Obra { get; set; }
        public AsientosSimpleDto Asientos { get; set; }

        public UsuarioSimpleDto Usuario { get; set; }

        public SesionSimpleDto Sesion { get; set; }

    }
}