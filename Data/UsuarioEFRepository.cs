using TeatroApi.Models;
using Microsoft.EntityFrameworkCore;

namespace TeatroApi.Data
{
    public class UsuarioEFRepository : IUsuarioRepository
    {
        private readonly TeatroContext _context;

        public UsuarioEFRepository(TeatroContext context)
        {
            _context = context;
        }

        public void Add(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            SaveChanges();
        }

        public Usuario? Get(int usuarioId)
        {
            return _context.Usuarios.FirstOrDefault(usuario => usuario.IdUser == usuarioId);
        }

        public void Update(Usuario usuario)
        {
            _context.Entry(usuario).State = EntityState.Modified;
        }

        public void Delete(int usuarioId) {
            var usuario = Get(usuarioId);
            if (usuario is null) {
                throw new KeyNotFoundException("Account not found.");
            }
            _context.Usuarios.Remove(usuario);
            SaveChanges();

        }
        

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public List<Usuario> GetAll()
        {
            return _context.Usuarios.ToList();

        }
    }   
}