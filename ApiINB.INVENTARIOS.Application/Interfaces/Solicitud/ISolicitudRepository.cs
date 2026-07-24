using ApiINB.INVENTARIOS.Domain.Entities;


namespace ApiINB.INVENTARIOS.Application.Interfaces
{
    public interface ISolicitudRepository
    {
        Task AddAsync(Solicitud solicitud);

        Task<List<Solicitud>> GetAllAsync();

        Task<Solicitud?> GetByIdAsync(int id);
        Task<Solicitud?> GetCompletaByIdAsync(int id);

        Task SaveChangesAsync();
        
        Task<SolicitudDetalle?> GetDetalleByIdAsync(int detalleSolicitudId);
    }
}