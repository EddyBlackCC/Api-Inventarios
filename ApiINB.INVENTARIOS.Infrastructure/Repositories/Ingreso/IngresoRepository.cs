using ApiINB.INVENTARIOS.Application.Interfaces;
using ApiINB.INVENTARIOS.Domain.Entities;
using ApiINB.INVENTARIOS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ApiINB.INVENTARIOS.Infrastructure.Repositories
{
    public class IngresoRepository : IIngresoRepository
    {
        private readonly AppDbContext _context;

        public IngresoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Ingreso ingreso)
        {
            await _context.Ingresos.AddAsync(ingreso);
        }

        public async Task<List<Ingreso>> GetAllAsync()
        {
            return await _context.Ingresos
                .Include(x => x.Detalles)
                .ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}