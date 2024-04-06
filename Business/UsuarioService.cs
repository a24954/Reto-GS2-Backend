using TeatroApi.Data;
using TeatroApi.Models;

namespace TeatroApi.Business
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository){

            _usuarioRepository = usuarioRepository;
            
        }
        public List<Usuario> GetAll() => _usuarioRepository.GetAll();

        public UsuarioSimpleDto? Get(int id) => _usuarioRepository.Get(id);

        public void Add(Usuario usuario) => _usuarioRepository.Add(usuario);

        public void Delete(int id) => _usuarioRepository.Delete(id);

        public void Update(Usuario usuario) => _usuarioRepository.Update(usuario);
    
        public Usuario Login(string userName, string password)
        {
            var usuario = _usuarioRepository.GetAll().FirstOrDefault(u => u.UserName == userName && u.Password == password);

            return usuario; 
        }
    }
}
