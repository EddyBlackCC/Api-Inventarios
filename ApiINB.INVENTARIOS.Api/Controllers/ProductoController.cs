using Microsoft.AspNetCore.Mvc;
using ApiINB.INVENTARIOS.Application.DTOs.Producto;
using ApiINB.INVENTARIOS.Application.Interfaces;

namespace ApiINB.INVENTARIOS.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoService _service;

        public ProductoController(IProductoService service)
        {
            _service = service;
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
        public async Task<IActionResult> Create(CreateProductoDto dto)
        {
            await _service.CreateAsync(dto);

            return Ok(new
            {
                message = "Producto creado correctamente"
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetPaged(
            int page = 1,
            int pageSize = 50)
        {
            var result =
                await _service.GetPagedAsync(page, pageSize);

            return Ok(result);
        }

        [HttpGet("filtro")]
        public async Task<IActionResult> Filtrar([FromQuery] ProductoFiltroDto filtro)
        {
            var result = await _service.FiltrarAsync(filtro);

            return Ok(result);
        }
    }
}