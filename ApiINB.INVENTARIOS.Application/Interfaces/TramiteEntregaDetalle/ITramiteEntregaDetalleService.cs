using ApiINB.INVENTARIOS.Application.DTOs.TramiteEntregaDetalle;

namespace ApiINB.INVENTARIOS.Application.Interfaces
{
    public interface ITramiteEntregaDetalleService
    {
        Task<IEnumerable<TramiteEntregaDetalleDto>> GetAllAsync();

        Task CreateAsync(CreateTramiteEntregaDetalleDto dto);
    }
}