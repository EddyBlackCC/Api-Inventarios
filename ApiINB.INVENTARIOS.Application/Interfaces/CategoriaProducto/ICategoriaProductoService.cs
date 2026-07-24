using ApiINB.INVENTARIOS.Application.DTOs.CategoriaProducto;

namespace ApiINB.INVENTARIOS.Application.Interfaces
{
    public interface ICategoriaProductoService
    {
        Task<List<CategoriaProductoDto>> GetAllAsync();

        Task<CategoriaProductoDto?> GetByIdAsync(int id);

        Task CreateAsync(CreateCategoriaProductoDto dto);
    }
}