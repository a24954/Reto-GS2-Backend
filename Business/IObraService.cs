using TeatroApi.Models;
using TeatroAPI.DTOs;

namespace TeatroApi.Business
{
     public interface IObraService
    {
        List<Obra> GetAll();
        ObraSimpleDto? Get(int id);
        void Add(Obra obra);
        void Delete(int id);
        void Update(Obra obra);
    }
}
