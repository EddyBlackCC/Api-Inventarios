using ApiINB.INVENTARIOS.Domain.Entities;

namespace ApiINB.INVENTARIOS.Application.Interfaces
{
    public interface ITramiteEntregaDetalleRepository
    {
        Task<IEnumerable<TramiteEntregaDetalle>> GetAllAsync();

        Task<TramiteEntregaDetalle?> GetByIdAsync(int id);

        Task AddAsync(TramiteEntregaDetalle detalle);

        void Update(TramiteEntregaDetalle detalle);

        void Delete(TramiteEntregaDetalle detalle);

        Task SaveChangesAsync();
    }
}