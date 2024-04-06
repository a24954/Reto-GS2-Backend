using TeatroApi.Models;

namespace TeatroApi.Business
{
     public interface ISesionService
    {
        List<SesionSimpleDto> GetAll();
        SesionSimpleDto? Get(int id);
        void Add(Sesion sesion);
        void Delete(int id);
        void Update(Sesion sesion);
    }
}
