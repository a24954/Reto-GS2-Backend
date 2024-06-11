using TeatroApi.Models;

namespace TeatroApi.Business
{
     public interface IReservaService
    {
        List<ReservaSimpleDto> GetAll();
        List<ReservaSimpleDto>? Get(int id);
        void Add(Reserva reserva);
        void Delete(int id);
        void Update(Reserva reserva);
    }
}
