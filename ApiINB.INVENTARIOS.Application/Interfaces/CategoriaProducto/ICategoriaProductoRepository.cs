using ApiINB.INVENTARIOS.Domain.Entities;

namespace ApiINB.INVENTARIOS.Application.Interfaces
{
    public interface ICategoriaProductoRepository
    {
        Task<List<CategoriaProducto>> GetAllAsync();

        Task<CategoriaProducto?> GetByIdAsync(int id);

        Task AddAsync(CategoriaProducto categoria);

        Task SaveChangesAsync();
    }
}