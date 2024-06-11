using TeatroApi.Models;

namespace TeatroApi.Business
{
     public interface ISesionService
    {
        List<SesionSimpleDto> GetAll();
        List<SesionSimpleDto>? Get(int id);
        void Add(Sesion sesion);
        void Delete(int id);
        void Update(SesionSimpleDto sesion);
    }
}
