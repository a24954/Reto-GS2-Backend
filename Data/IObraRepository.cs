using TeatroApi.Models;
using TeatroAPI.DTOs;

namespace TeatroApi.Data
{
    public interface IObraRepository
    {
        List<Obra> GetAll();
        ObraSimpleDto? Get(int id);
        void Add(Obra obra);
        void Delete(int id);
        void Update(Obra obra);
    }
}
