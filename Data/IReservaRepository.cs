using TeatroApi.Models;
using TeatroAPI.DTOs;

namespace TeatroApi.Data
{
    public interface IReservaRepository
    {
        List<Reserva> GetAll();
        ReservaSimpleDto? Get(int id);
        void Add(Reserva reserva);
        void Delete(int id);
        void Update(Reserva reserva);
    }
}
