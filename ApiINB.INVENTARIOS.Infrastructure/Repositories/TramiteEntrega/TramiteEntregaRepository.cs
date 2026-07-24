using Microsoft.EntityFrameworkCore;
using ApiINB.INVENTARIOS.Application.Interfaces;
using ApiINB.INVENTARIOS.Domain.Entities;
using ApiINB.INVENTARIOS.Infrastructure.Data;

namespace ApiINB.INVENTARIOS.Infrastructure.Repositories
{
    public class TramiteEntregaRepository : ITramiteEntregaRepository
    {
        private readonly AppDbContext _context;

        public TramiteEntregaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(TramiteEntrega entrega)
        {
            await _context.TramiteEntregas.AddAsync(entrega);
        }

        public async Task<List<TramiteEntrega>> GetAllAsync()
        {
            return await _context.TramiteEntregas
                .Include(x => x.Detalles)
                .ToListAsync();
        }

        public async Task<TramiteEntrega?> GetByIdAsync(int id)
        {
            return await _context.TramiteEntregas
                .Include(x => x.Detalles)
                .FirstOrDefaultAsync(x => x.EntregaId == id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
        public async Task<int> ObtenerTotalEntregadoAsync(int detalleSolicitudId)
        {
            return await _context.TramiteEntregaDetalles
                .Where(x => x.DetalleSolicitudId == detalleSolicitudId)
                .SumAsync(x => (int?)x.CantidadEntregadaId) ?? 0;
        }
    }
}