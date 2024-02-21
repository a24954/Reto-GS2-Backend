using Microsoft.AspNetCore.Mvc;

using TeatroApi.Data;
using TeatroApi.Models;
using TeatroApi.Business;

namespace TeatroApi.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AsientosController : ControllerBase
    {
        private readonly IAsientosService _asientosService;

        public AsientosController(IAsientosService asientosService)
        {
            _asientosService = asientosService;
        }

        [HttpGet]
        public ActionResult<List<Asientos>> GetAll() =>
            _asientosService.GetAll();

        [HttpGet("{id}")]
        public ActionResult<Asientos> Get(int id)
        {
            var asientos = _asientosService.Get(id);

            if (asientos == null)
                return NotFound();

            return asientos;
        }

        [HttpPost]
        public IActionResult Create(Asientos asientos)
        {
            _asientosService.Add(asientos);
            return CreatedAtAction(nameof(Get), new { id = asientos.IdSeats }, asientos);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Asientos asientos)
        {
            if (id != asientos.IdSeats)
                return BadRequest();

            var existingAsientos = _asientosService.Get(id);
            if (existingAsientos is null)
                return NotFound();

            _asientosService.Update(asientos);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var asientos = _asientosService.Get(id);

            if (asientos is null)
                return NotFound();

            _asientosService.Delete(id);

            return NoContent();
        }
    }
}