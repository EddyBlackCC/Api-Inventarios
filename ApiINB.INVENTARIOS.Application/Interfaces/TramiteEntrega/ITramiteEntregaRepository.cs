using ApiINB.INVENTARIOS.Domain.Entities;

namespace ApiINB.INVENTARIOS.Application.Interfaces
{
    public interface ITramiteEntregaRepository
    {
        Task AddAsync(TramiteEntrega entrega);

        Task<List<TramiteEntrega>> GetAllAsync();

        Task<TramiteEntrega?> GetByIdAsync(int id);
        Task<int> ObtenerTotalEntregadoAsync(int detalleSolicitudId);

        Task SaveChangesAsync();
    }
}