using Microsoft.AspNetCore.Mvc;

using TeatroApi.Data;
using TeatroApi.Models;
using TeatroApi.Business;

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
        public ActionResult<List<SesionSimpleDto>> GetAll() =>
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
        public IActionResult Create(SesionSimpleDto sesiondto)
        {
            var sesion = new Sesion { SesionTime = sesiondto.SesionTime, IdPlay = sesiondto.IdPlay };
            _sesionService.Add(sesion);
            return CreatedAtAction(nameof(Get), new { id = sesion.IdSesion }, sesion);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, SesionSimpleDto sesionDto)
        {
            if (id != sesionDto.IdSesion)
                return BadRequest();

            var existingSesion = _sesionService.Get(id);
            if (existingSesion == null)
                return NotFound();

            var sesionToUpdate = new Sesion
            {
                IdSesion = sesionDto.IdSesion,
                SesionTime = sesionDto.SesionTime,
                IdPlay = sesionDto.IdPlay
            };

            _sesionService.Update(sesionToUpdate);

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