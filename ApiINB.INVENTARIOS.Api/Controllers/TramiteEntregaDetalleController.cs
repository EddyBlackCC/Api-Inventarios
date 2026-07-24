using ApiINB.INVENTARIOS.Application.DTOs.TramiteEntregaDetalle;
using ApiINB.INVENTARIOS.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiINB.INVENTARIOS.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TramiteEntregaDetalleController : ControllerBase
    {
        private readonly ITramiteEntregaDetalleService _service;

        public TramiteEntregaDetalleController(
            ITramiteEntregaDetalleService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _service.GetAllAsync();
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            CreateTramiteEntregaDetalleDto dto)
        {
            await _service.CreateAsync(dto);

            return Ok(new
            {
                message = "Detalle de entrega creado correctamente"
            });
        }
    }
}