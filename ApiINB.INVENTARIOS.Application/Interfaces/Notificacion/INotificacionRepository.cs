using ApiINB.INVENTARIOS.Domain.Entities;

namespace ApiINB.INVENTARIOS.Application.Interfaces
{
    public interface INotificacionRepository
    {
        Task<IEnumerable<Notificacion>> GetAllAsync();

        Task<Notificacion?> GetByIdAsync(int id);

        Task AddAsync(Notificacion notificacion);

        void Update(Notificacion notificacion);

        void Delete(Notificacion notificacion);

        Task SaveChangesAsync();
    }
}