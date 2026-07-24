using ApiINB.INVENTARIOS.Application.DTOs.Ingreso;

namespace ApiINB.INVENTARIOS.Application.Interfaces
{
    public interface IIngresoService
    {
        Task CreateAsync(CreateIngresoDto dto);

        Task<List<object>> GetAllAsync();
    }
}