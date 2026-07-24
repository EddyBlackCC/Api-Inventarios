using Microsoft.AspNetCore.Mvc;
using ApiINB.INVENTARIOS.Application.DTOs.CategoriaProducto;
using ApiINB.INVENTARIOS.Application.Interfaces;

namespace ApiINB.INVENTARIOS.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriaProductoController : ControllerBase
    {
        private readonly ICategoriaProductoService _service;

        public CategoriaProductoController(ICategoriaProductoService service)
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
        public async Task<IActionResult> Create(CreateCategoriaProductoDto dto)
        {
            await _service.CreateAsync(dto);

            return Ok(new
            {
                message = "Categoría creada correctamente"
            });
        }
    }
}