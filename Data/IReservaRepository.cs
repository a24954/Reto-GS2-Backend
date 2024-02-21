using TeatroApi.Models;

namespace TeatroApi.Data
{
    public interface IReservaRepository
    {
        List<Reserva> GetAll();
        Reserva? Get(int id);
        void Add(Reserva reserva);
        void Delete(int id);
        void Update(Reserva reserva);
    }
}
