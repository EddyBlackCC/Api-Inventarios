using ApiINB.INVENTARIOS.Application.DTOs.Notificacion;

namespace ApiINB.INVENTARIOS.Application.Interfaces
{
    public interface INotificacionService
    {
        Task<IEnumerable<NotificacionDto>> GetAllAsync();

        Task CreateAsync(CreateNotificacionDto dto);
    }
}