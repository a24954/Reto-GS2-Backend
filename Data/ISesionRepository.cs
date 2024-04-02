using TeatroApi.Models;
using TeatroAPI.DTOs;

namespace TeatroApi.Data
{
    public interface ISesionRepository
    {
        List<Sesion> GetAll();
        SesionSimpleDto? Get(int id);
        void Add(Sesion sesion);
        void Delete(int id);
        void Update(Sesion sesion);
    }
}
