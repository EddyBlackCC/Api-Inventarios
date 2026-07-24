using ApiINB.INVENTARIOS.Application.DTOs.Producto;

namespace ApiINB.INVENTARIOS.Application.Interfaces
{
    public interface IProductoService
    {
        Task<List<ProductoDto>> GetAllAsync();

        Task<ProductoDto?> GetByIdAsync(int id);

        Task CreateAsync(CreateProductoDto dto);

        Task<object> GetPagedAsync(
     int page,
     int pageSize);

        Task<object> FiltrarAsync(
            ProductoFiltroDto filtro);

    }
}