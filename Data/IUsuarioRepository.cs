using TeatroApi.Models;

namespace TeatroApi.Data
{
    public interface IUsuarioRepository
    {
        List<Usuario> GetAll();
        Usuario? Get(int id);
        void Add(Usuario usuario);
        void Delete(int id);
        void Update(Usuario usuario);
    }
}
