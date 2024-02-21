using TeatroApi.Models;

namespace TeatroApi.Business
{
     public interface IUsuarioService
    {
        List<Usuario> GetAll();
        Usuario? Get(int id);
        void Add(Usuario usuario);
        void Delete(int id);
        void Update(Usuario usuario);
    }
}
