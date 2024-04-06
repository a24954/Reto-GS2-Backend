using TeatroApi.Models;

namespace TeatroApi.Business
{
     public interface IUsuarioService
    {
        List<Usuario> GetAll();
        UsuarioSimpleDto? Get(int id);
        void Add(Usuario usuario);
        void Delete(int id);
        void Update(Usuario usuario);
        Usuario Login(string userName, string password);
    }
}
