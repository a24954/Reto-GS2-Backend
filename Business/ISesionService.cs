using TeatroApi.Models;
using TeatroAPI.DTOs;

namespace TeatroApi.Business
{
     public interface ISesionService
    {
        List<Sesion> GetAll();
        SesionSimpleDto? Get(int id);
        void Add(Sesion sesion);
        void Delete(int id);
        void Update(Sesion sesion);
    }
}
