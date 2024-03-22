using TeatroApi.Models;
using TeatroAPI.DTOs;

namespace TeatroApi.Business
{
     public interface IReservaService
    {
        List<Reserva> GetAll();
        ReservaSimpleDto? Get(int id);
        void Add(Reserva reserva);
        void Delete(int id);
        void Update(Reserva reserva);
    }
}
