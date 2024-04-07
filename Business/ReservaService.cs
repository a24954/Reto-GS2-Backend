using TeatroApi.Data;
using TeatroApi.Models;

namespace TeatroApi.Business
{
    public class ReservaService : IReservaService
    {
        private readonly IReservaRepository _reservaRepository;

        public ReservaService(IReservaRepository reservaRepository){

            _reservaRepository = reservaRepository;
            
        }
        public List<ReservaSimpleDto> GetAll() => _reservaRepository.GetAll();

        public ReservaSimpleDto? Get(int id) => _reservaRepository.Get(id);

        public void Add(Reserva reserva) => _reservaRepository.Add(reserva);

        public void Delete(int id) => _reservaRepository.Delete(id);

        public void Update(Reserva reserva) => _reservaRepository.Update(reserva);
    }
}
