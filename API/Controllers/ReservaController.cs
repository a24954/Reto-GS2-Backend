using Microsoft.AspNetCore.Mvc;

using TeatroApi.Data;
using TeatroApi.Models;
using TeatroApi.Business;
using TeatroAPI.DTOs;

namespace TeatroApi.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReservaController : ControllerBase
    {
        private readonly IReservaService _reservaService;

        public ReservaController(IReservaService reservaService)
        {
            _reservaService = reservaService;
        }

        [HttpGet]
        public ActionResult<List<Reserva>> GetAll() =>
            _reservaService.GetAll();

        [HttpGet("{id}")]
        public ActionResult<ReservaSimpleDto> Get(int id)
        {
            var reserva = _reservaService.Get(id);

            if (reserva == null)
                return NotFound();

            return reserva;
        }

        [HttpPost]
        public IActionResult Create(Reserva reserva)
        {
            _reservaService.Add(reserva);
            return CreatedAtAction(nameof(Get), new { id = reserva.IdReservation }, reserva);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Reserva reserva)
        {
            if (id != reserva.IdReservation)
                return BadRequest();

            var existingReserva = _reservaService.Get(id);
            if (existingReserva is null)
                return NotFound();

            _reservaService.Update(reserva);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var reserva = _reservaService.Get(id);

            if (reserva is null)
                return NotFound();

            _reservaService.Delete(id);

            return NoContent();
        }
    }
}