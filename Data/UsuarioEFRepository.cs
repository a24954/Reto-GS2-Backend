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

        public UsuarioSimpleDto? Get(int usuarioId)
        {
            var usuario = _context.Usuarios
            .Where(usuario => usuario.IdUser == usuarioId)
            .Select(r => new UsuarioSimpleDto
            {
                UserName = r.UserName,
                Password = r.Password,
            }).FirstOrDefault();
            return usuario;
        }
        

        public void Update(Usuario usuario)
        {
            _context.Entry(usuario).State = EntityState.Modified;
        }

        public void Delete(int usuarioId) {
            var usuario = _context.Usuarios.Find(usuarioId);
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