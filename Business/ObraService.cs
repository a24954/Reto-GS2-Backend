using TeatroApi.Data;
using TeatroApi.Models;
using TeatroAPI.DTOs;

namespace TeatroApi.Business
{
    public class ObraService : IObraService
    {
        private readonly IObraRepository _obraRepository;

        public ObraService(IObraRepository obraRepository)
        {

            _obraRepository = obraRepository;

        }
        public List<Obra> GetAll() => _obraRepository.GetAll();

        public ObraSimpleDto? Get(int id) => _obraRepository.Get(id);

        public void Add(Obra obra) => _obraRepository.Add(obra);

        public void Delete(int id) => _obraRepository.Delete(id);

        public void Update(Obra obra) => _obraRepository.Update(obra);
    }
}
