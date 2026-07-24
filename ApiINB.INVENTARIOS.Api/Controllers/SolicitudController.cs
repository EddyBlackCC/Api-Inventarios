using Microsoft.AspNetCore.Mvc;
using ApiINB.INVENTARIOS.Application.DTOs.Solicitud;
using ApiINB.INVENTARIOS.Application.Interfaces;

namespace ApiINB.INVENTARIOS.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SolicitudController : ControllerBase
    {
        private readonly ISolicitudService _service;

        public SolicitudController(ISolicitudService service)
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
        public async Task<IActionResult> Create(CreateSolicitudDto dto)
        {
            await _service.CreateAsync(dto);

            return Ok(new
            {
                message = "Solicitud creada correctamente"
            });
        }

        [HttpGet("completa/{id}")]
        public async Task<IActionResult> GetCompleta(int id)
        {
            var result = await _service.GetCompletaAsync(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
        [HttpPut("aprobar/{detalleSolicitudId}")]
        public async Task<IActionResult> AprobarDetalle(
    int detalleSolicitudId,
    ApproveSolicitudDetalleDto dto)
        {
            var result = await _service
                .AprobarDetalleAsync(detalleSolicitudId, dto);

            if (!result)
                return NotFound();

            return Ok(new
            {
                message = "Detalle aprobado correctamente"
            });
        }

        [HttpPut("rechazar-detalle/{detalleSolicitudId}")]
        public async Task<IActionResult> RechazarDetalle(
            int detalleSolicitudId,
            ApproveSolicitudDetalleDto dto)
        {
            var result = await _service.RechazarDetalleAsync(
                detalleSolicitudId,
                dto);

            if (!result)
                return NotFound();

            return Ok(new
            {
                message = "Detalle rechazado correctamente"
            });
        }

    }
}