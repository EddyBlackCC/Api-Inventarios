using Microsoft.AspNetCore.Mvc;
using ApiINB.INVENTARIOS.Application.DTOs.Notificacion;
using ApiINB.INVENTARIOS.Application.Interfaces;
namespace ApiINB.INVENTARIOS.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificacionController : ControllerBase
    {
        private readonly INotificacionService _service;

        public NotificacionController(INotificacionService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateNotificacionDto dto)
        {
            await _service.CreateAsync(dto);

            return Ok(new
            {
                message = "Notificación creada correctamente"
            });
        }
    }
}