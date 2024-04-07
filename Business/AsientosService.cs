using TeatroApi.Data;
using TeatroApi.Models;

namespace TeatroApi.Business
{
    public class AsientosService : IAsientosService
    {
        private readonly IAsientosRepository _asientosRepository;

        public AsientosService(IAsientosRepository asientosRepository){

            _asientosRepository = asientosRepository;
            
        }
        public List<Asientos> GetAll() => _asientosRepository.GetAll();

        public Asientos? Get(int id) => _asientosRepository.Get(id);

        public void Add(Asientos asientos) => _asientosRepository.Add(asientos);

        public void Delete(int id) => _asientosRepository.Delete(id);

        public void Update(Asientos asientos) => _asientosRepository.Update(asientos);
    }
}
