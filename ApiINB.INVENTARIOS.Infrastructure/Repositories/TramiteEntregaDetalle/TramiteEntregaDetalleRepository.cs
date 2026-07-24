using ApiINB.INVENTARIOS.Application.Interfaces;
using ApiINB.INVENTARIOS.Domain.Entities;
using ApiINB.INVENTARIOS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ApiINB.INVENTARIOS.Infrastructure.Repositories
{
    public class TramiteEntregaDetalleRepository : ITramiteEntregaDetalleRepository
    {
        private readonly AppDbContext _context;

        public TramiteEntregaDetalleRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TramiteEntregaDetalle>> GetAllAsync()
        {
            return await _context.TramiteEntregaDetalles.ToListAsync();
        }

        public async Task<TramiteEntregaDetalle?> GetByIdAsync(int id)
        {
            return await _context.TramiteEntregaDetalles.FindAsync(id);
        }

        public async Task AddAsync(TramiteEntregaDetalle detalle)
        {
            await _context.TramiteEntregaDetalles.AddAsync(detalle);
        }

        public void Update(TramiteEntregaDetalle detalle)
        {
            _context.TramiteEntregaDetalles.Update(detalle);
        }

        public void Delete(TramiteEntregaDetalle detalle)
        {
            _context.TramiteEntregaDetalles.Remove(detalle);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}