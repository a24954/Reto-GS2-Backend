using Microsoft.AspNetCore.Mvc;

using TeatroApi.Data;
using TeatroApi.Models;
using TeatroApi.Business;
using TeatroAPI.DTOs;

namespace TeatroApi.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SesionController : ControllerBase
    {
        private readonly ISesionService _sesionService;

        public SesionController(ISesionService sesionService)
        {
            _sesionService = sesionService;
        }

        [HttpGet]
        public ActionResult<List<Sesion>> GetAll() =>
            _sesionService.GetAll();

        [HttpGet("{id}")]
        public ActionResult<SesionSimpleDto> Get(int id)
        {
            var sesion = _sesionService.Get(id);

            if (sesion == null)
                return NotFound();

            return sesion;
        }

        [HttpPost]
        public IActionResult Create(Sesion sesiondto)
        {
            var sesion = new Sesion { Seats = sesiondto.Seats, SesionTime = sesiondto.SesionTime, IdPlay = sesiondto.IdPlay };
            _sesionService.Add(sesion);
            return CreatedAtAction(nameof(Get), new { id = sesion.IdSesion }, sesion);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Sesion sesion)
        {
            if (id != sesion.IdSesion)
                return BadRequest();

            var existingSesion = _sesionService.Get(id);
            if (existingSesion is null)
                return NotFound();

            _sesionService.Update(sesion);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var sesion = _sesionService.Get(id);

            if (sesion is null)
                return NotFound();

            _sesionService.Delete(id);

            return NoContent();
        }
    }
}