using ApiINB.INVENTARIOS.Application.DTOs.Producto;
using ApiINB.INVENTARIOS.Domain.Entities;

namespace ApiINB.INVENTARIOS.Application.Interfaces
{
    public interface IProductoRepository
    {
        Task<List<Producto>> GetAllAsync();

        Task<Producto?> GetByIdAsync(int id);

        Task AddAsync(Producto producto);

        Task SaveChangesAsync();

        Task<(List<Producto> Data, int Total)> GetPagedAsync(int page, int pageSize);

        Task<(List<Producto> Data, int Total)> FiltrarAsync(ProductoFiltroDto filtro);
    }
}