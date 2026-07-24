using ApiINB.INVENTARIOS.Application.DTOs.Solicitud;

namespace ApiINB.INVENTARIOS.Application.Interfaces
{
    public interface ISolicitudService
    {
        Task CreateAsync(CreateSolicitudDto dto);

        Task<List<object>> GetAllAsync();

        Task<object?> GetByIdAsync(int id);
        Task<SolicitudCompletaDto?> GetCompletaAsync(int id);
        Task<bool> RechazarDetalleAsync(int detalleSolicitudId,ApproveSolicitudDetalleDto dto);
        Task<bool> AprobarDetalleAsync(int detalleSolicitudId, ApproveSolicitudDetalleDto dto);
    }
}