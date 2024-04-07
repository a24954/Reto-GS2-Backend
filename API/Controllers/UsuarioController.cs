using Microsoft.AspNetCore.Mvc;

using TeatroApi.Data;
using TeatroApi.Models;
using TeatroApi.Business;

namespace TeatroApi.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public ActionResult<List<Usuario>> GetAll() =>
            _usuarioService.GetAll();

        [HttpGet("{id}")]
        public ActionResult<UsuarioSimpleDto> Get(int id)
        {
            var usuario = _usuarioService.Get(id);

            if (usuario == null)
                return NotFound();

            return usuario;
        }

        [HttpPost]
        public IActionResult Create(Usuario usuario)
        {
            _usuarioService.Add(usuario);
            return CreatedAtAction(nameof(Get), new { id = usuario.IdUser }, usuario);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, Usuario usuario)
        {
            if (id != usuario.IdUser)
                return BadRequest();

            var existingUsuario = _usuarioService.Get(id);
            if (existingUsuario is null)
                return NotFound();

            _usuarioService.Update(usuario);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var usuario = _usuarioService.Get(id);

            if (usuario is null)
                return NotFound();

            _usuarioService.Delete(id);

            return NoContent();
        }
    }
}