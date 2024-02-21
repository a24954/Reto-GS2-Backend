using Microsoft.AspNetCore.Mvc;

using TeatroApi.Data;
using TeatroApi.Models;
using TeatroApi.Business;

namespace TeatroApi.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ObraController : ControllerBase
    {
        private readonly IObraService _obraService;

        public ObraController(IObraService obraService)
        {
            _obraService = obraService;
        }

        [HttpGet]
        public ActionResult<List<Obra>> GetAll() =>
            _obraService.GetAll();

        [HttpGet("{id}")]
        public ActionResult<Obra> Get(int id)
        {
            var obra = _obraService.Get(id);

            if (obra == null)
                return NotFound();

            return obra;
        }

        [HttpPost]
        public IActionResult Create(Obra obra)
        {
            _obraService.Add(obra);
            return CreatedAtAction(nameof(Get), new { id = obra.IdPlay }, obra);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Obra obra)
        {
            if (id != obra.IdPlay)
                return BadRequest();

            var existingObra = _obraService.Get(id);
            if (existingObra is null)
                return NotFound();

            _obraService.Update(obra);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var obra = _obraService.Get(id);

            if (obra is null)
                return NotFound();

            _obraService.Delete(id);

            return NoContent();
        }
    }
}