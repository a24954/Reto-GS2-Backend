using TeatroApi.Models;

namespace TeatroApi.Data
{
    public interface IObraRepository
    {
        List<Obra> GetAll();
        Obra? Get(int id);
        void Add(Obra obra);
        void Delete(int id);
        void Update(Obra obra);
    }
}
