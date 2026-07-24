using ApiINB.INVENTARIOS.Application.DTOs.TramiteEntrega;

namespace ApiINB.INVENTARIOS.Application.Interfaces
{
    public interface ITramiteEntregaService
    {
        Task CreateAsync(CreateTramiteEntregaDto dto);

        Task<List<TramiteEntregaResponseDto>> GetAllAsync();

        Task<TramiteEntregaResponseDto?> GetByIdAsync(int id);
    }
}