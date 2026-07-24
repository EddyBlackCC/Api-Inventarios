using Microsoft.AspNetCore.Mvc;
using ApiINB.INVENTARIOS.Application.DTOs.Ingreso;
using ApiINB.INVENTARIOS.Application.Interfaces;

namespace ApiINB.INVENTARIOS.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IngresoController : ControllerBase
    {
        private readonly IIngresoService _service;

        public IngresoController(IIngresoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateIngresoDto dto)
        {
            await _service.CreateAsync(dto);

            return Ok(new
            {
                message = "Ingreso registrado correctamente"
            });
        }
    }
}