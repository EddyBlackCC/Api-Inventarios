using Microsoft.EntityFrameworkCore;
using ApiINB.INVENTARIOS.Domain.Entities;
using ApiINB.INVENTARIOS.Application.Interfaces;
using ApiINB.INVENTARIOS.Infrastructure.Data;

namespace ApiINB.INVENTARIOS.Infrastructure.Repositories
{
    public class NotificacionRepository : INotificacionRepository
    {
        private readonly AppDbContext _context;

        public NotificacionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Notificacion>> GetAllAsync()
        {
            return await _context.Notificaciones.ToListAsync();
        }

        public async Task<Notificacion?> GetByIdAsync(int id)
        {
            return await _context.Notificaciones.FindAsync(id);
        }

        public async Task AddAsync(Notificacion notificacion)
        {
            await _context.Notificaciones.AddAsync(notificacion);
        }

        public void Update(Notificacion notificacion)
        {
            _context.Notificaciones.Update(notificacion);
        }

        public void Delete(Notificacion notificacion)
        {
            _context.Notificaciones.Remove(notificacion);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}