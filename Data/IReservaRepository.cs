using TeatroApi.Models;

namespace TeatroApi.Data
{
    public interface IReservaRepository
    {
        List<ReservaSimpleDto> GetAll();
        ReservaSimpleDto? Get(int id);
        void Add(Reserva reserva);
        void Delete(int id);
        void Update(Reserva reserva);
    }
}
