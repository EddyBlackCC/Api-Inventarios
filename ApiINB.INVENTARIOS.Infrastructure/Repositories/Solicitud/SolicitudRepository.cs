using Microsoft.EntityFrameworkCore;
using ApiINB.INVENTARIOS.Application.Interfaces;
using ApiINB.INVENTARIOS.Domain.Entities;
using ApiINB.INVENTARIOS.Infrastructure.Data;

namespace ApiINB.INVENTARIOS.Infrastructure.Repositories
{
    public class SolicitudRepository : ISolicitudRepository
    {
        private readonly AppDbContext _context;

        public SolicitudRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Solicitud solicitud)
        {
            await _context.Solicitudes.AddAsync(solicitud);
        }

        public async Task<List<Solicitud>> GetAllAsync()
        {
            return await _context.Solicitudes
                .Include(x => x.Detalles)
                .ToListAsync();
        }

        public async Task<Solicitud?> GetByIdAsync(int id)
        {
            return await _context.Solicitudes
                .Include(x => x.Detalles)
                .FirstOrDefaultAsync(x => x.SolicitudId == id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<Solicitud?> GetCompletaByIdAsync(int id)
        {
            return await _context.Solicitudes
                .Include(x => x.Detalles)
                    .ThenInclude(d => d.Producto)
                .Include(x => x.Detalles)
                    .ThenInclude(d => d.Autorizador)
                .FirstOrDefaultAsync(x => x.SolicitudId == id);
        }

        public async Task<SolicitudDetalle?> GetDetalleByIdAsync(int detalleSolicitudId)
        {
            return await _context.SolicitudDetalles
                .FirstOrDefaultAsync(x =>
                    x.DetalleSolicitudId == detalleSolicitudId);
        }
        

    }
}