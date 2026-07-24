using Microsoft.EntityFrameworkCore;
using ApiINB.INVENTARIOS.Application.Interfaces;
using ApiINB.INVENTARIOS.Domain.Entities;
using ApiINB.INVENTARIOS.Infrastructure.Data;
   

namespace ApiINB.INVENTARIOS.Infrastructure.Repositories
{
    public class CategoriaProductoRepository : ICategoriaProductoRepository
    {
        private readonly AppDbContext _context;

        public CategoriaProductoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<CategoriaProducto>> GetAllAsync()
        {
            return await _context.CategoriaProductos.ToListAsync();
        }

        public async Task<CategoriaProducto?> GetByIdAsync(int id)
        {
            return await _context.CategoriaProductos
                .FirstOrDefaultAsync(x => x.CategoriaId == id);
        }

        public async Task AddAsync(CategoriaProducto categoria)
        {
            await _context.CategoriaProductos.AddAsync(categoria);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}