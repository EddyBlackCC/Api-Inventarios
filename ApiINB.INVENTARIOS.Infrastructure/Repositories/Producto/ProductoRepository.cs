using ApiINB.INVENTARIOS.Application.Interfaces;
using ApiINB.INVENTARIOS.Domain.Entities;
using ApiINB.INVENTARIOS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ApiINB.INVENTARIOS.Infrastructure.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly AppDbContext _context;

        public ProductoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Producto>> GetAllAsync()
        {
            return await _context.Productos
                .Include(x => x.CategoriaProducto)
                .ToListAsync();
        }

        public async Task<Producto?> GetByIdAsync(int id)
        {
            return await _context.Productos
                .Include(x => x.CategoriaProducto)
                .FirstOrDefaultAsync(x => x.ProductoId == id);
        }

        public async Task AddAsync(Producto producto)
        {
            await _context.Productos.AddAsync(producto);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
        public async Task<(List<Producto>, int)> GetPagedAsync(int page, int pageSize)
        {
            var query =
                _context.Productos
                    .Where(x => x.Activo);

            var total = await query.CountAsync();

            var data = await query
                .OrderBy(x => x.ProductoId)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (data, total);
        }

        public async Task<(List<Producto>, int)>
    FiltrarAsync(ProductoFiltroDto filtro)
        {
            var query =
                _context.Productos
                    .Include(x => x.CategoriaProducto)
                    .Where(x => x.Activo)
                    .AsQueryable();

            if (!string.IsNullOrEmpty(filtro.Nombre))
            {
                query = query.Where(x =>
                    x.NombreProducto.Contains(filtro.Nombre));
            }

            if (!string.IsNullOrEmpty(filtro.Codigo))
            {
                query = query.Where(x =>
                    x.CodigoProducto.Contains(filtro.Codigo));
            }

            if (filtro.CategoriaId.HasValue)
            {
                query = query.Where(x =>
                    x.CategoriaId == filtro.CategoriaId);
            }

            if (filtro.StockMinimo.HasValue)
            {
                query = query.Where(x =>
                    x.StockActual >= filtro.StockMinimo);
            }
            Console.WriteLine(query.ToQueryString());
            var total = await query.CountAsync();
                
            var data = await query
                .OrderBy(x => x.ProductoId)
                .Skip((filtro.Page - 1) * filtro.PageSize)
                .Take(filtro.PageSize)
                .ToListAsync();
               Console.WriteLine($"CategoriaId: {filtro.CategoriaId}");
Console.WriteLine($"Page: {filtro.Page}");
Console.WriteLine($"PageSize: {filtro.PageSize}");
            return (data, total);
        }


    }
}