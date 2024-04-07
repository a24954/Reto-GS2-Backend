using TeatroApi.Models;

namespace TeatroApi.Business
{
     public interface IAsientosService
    {
        List<Asientos> GetAll();
        Asientos? Get(int id);
        void Add(Asientos asientos);
        void Delete(int id);
        void Update(Asientos asientos);
    }
}
