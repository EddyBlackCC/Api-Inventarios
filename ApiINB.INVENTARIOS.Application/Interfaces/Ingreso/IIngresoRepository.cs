using ApiINB.INVENTARIOS.Domain.Entities;

namespace ApiINB.INVENTARIOS.Application.Interfaces
{
    public interface IIngresoRepository
    {
        Task AddAsync(Ingreso ingreso);

        Task<List<Ingreso>> GetAllAsync();

        Task SaveChangesAsync();
    }
}