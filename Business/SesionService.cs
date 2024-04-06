using TeatroApi.Data;
using TeatroApi.Models;

namespace TeatroApi.Business
{
    public class SesionService : ISesionService
    {
        private readonly ISesionRepository _sesionRepository;

        public SesionService(ISesionRepository sesionRepository){

            _sesionRepository = sesionRepository;
            
        }
        public List<SesionSimpleDto> GetAll() => _sesionRepository.GetAll();

        public SesionSimpleDto? Get(int id) => _sesionRepository.Get(id);

        public void Add(Sesion sesion) => _sesionRepository.Add(sesion);

        public void Delete(int id) => _sesionRepository.Delete(id);

        public void Update(Sesion sesion) => _sesionRepository.Update(sesion);
    }
}
