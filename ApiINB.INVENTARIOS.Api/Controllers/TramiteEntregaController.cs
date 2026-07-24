using Microsoft.AspNetCore.Mvc;
using ApiINB.INVENTARIOS.Application.DTOs.TramiteEntrega;
using ApiINB.INVENTARIOS.Application.Interfaces;
using ApiINB.INVENTARIOS.Application.DTOs.Solicitud;

namespace ApiINB.INVENTARIOS.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TramiteEntregaController : ControllerBase
    {
        private readonly ITramiteEntregaService _service;

        public TramiteEntregaController(ITramiteEntregaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTramiteEntregaDto dto)
        {
            await _service.CreateAsync(dto);

            return Ok(new
            {
                message = "Entrega registrada correctamente"
            });
        }
    }
}