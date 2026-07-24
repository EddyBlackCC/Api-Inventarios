using ApiINB.INVENTARIOS.Application.DTOs.Producto;
using ApiINB.INVENTARIOS.Application.Interfaces;
using ApiINB.INVENTARIOS.Domain.Entities;

namespace ApiINB.INVENTARIOS.Application.Services
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _repository;

        public ProductoService(IProductoRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ProductoDto>> GetAllAsync()
        {
            var productos = await _repository.GetAllAsync();

            return productos.Select(x => new ProductoDto
            {
                ProductoId = x.ProductoId,
                CodigoProducto = x.CodigoProducto,
                NombreProducto = x.NombreProducto,
                Descripcion = x.Descripcion,
                CategoriaId = x.CategoriaId,
                Categoria = x.CategoriaProducto.NombreCategoria,
                UnidadMedida = x.UnidadMedida,
                StockMinimo = x.StockMinimo ?? 0,
                StockMaximo = x.StockMaximo ?? 0,
                Activo = x.Activo
            }).ToList();
        }

        public async Task<ProductoDto?> GetByIdAsync(int id)
        {
            var x = await _repository.GetByIdAsync(id);

            if (x == null)
                return null;

            return new ProductoDto
            {
                ProductoId = x.ProductoId,
                CodigoProducto = x.CodigoProducto,
                NombreProducto = x.NombreProducto,
                Descripcion = x.Descripcion,
                CategoriaId = x.CategoriaId,
                Categoria = x.CategoriaProducto.NombreCategoria,
                UnidadMedida = x.UnidadMedida,
                StockMinimo = x.StockMinimo ?? 0,
                StockMaximo = x.StockMaximo ?? 0,
                Activo = x.Activo
            };
        }

        public async Task CreateAsync(CreateProductoDto dto)
        {
            var producto = new Producto
            {
                CodigoProducto = dto.CodigoProducto,
                NombreProducto = dto.NombreProducto,
                Descripcion = dto.Descripcion,
                CategoriaId = dto.CategoriaId,
                UnidadMedida = dto.UnidadMedida,
                StockMinimo = dto.StockMinimo,
                StockMaximo = dto.StockMaximo,
                UsoExclusivo = dto.UsoExclusivo,
                Activo = true,
                AudCreaUsuario = 1,
                AudCreaFecha = DateTime.Now
            };

            await _repository.AddAsync(producto);

            await _repository.SaveChangesAsync();
        }

        public async Task<object> GetPagedAsync(
    int page,
    int pageSize)
        {
            var result =
                await _repository.GetPagedAsync(page, pageSize);

            return new
            {
                TotalRegistros = result.Total,
                Pagina = page,
                PageSize = pageSize,
                Data = result.Data
            };
        }

        public async Task<object> FiltrarAsync(
            ProductoFiltroDto filtro)
        {
            var result =
                await _repository.FiltrarAsync(filtro);

            return new
            {
                TotalRegistros = result.Total,
                Data = result.Data.Select(x => new ProductoDto
                {
                    ProductoId = x.ProductoId,
                    CodigoProducto = x.CodigoProducto,
                    NombreProducto = x.NombreProducto,
                    Descripcion = x.Descripcion,
                    CategoriaId = x.CategoriaId,
                    Categoria = x.CategoriaProducto.NombreCategoria ?? "",
                    UnidadMedida = x.UnidadMedida,
                    StockMinimo = x.StockMinimo ?? 0,
                    StockMaximo = x.StockMaximo ?? 0,
                    Activo = x.Activo
                }).ToList()
            };
    }
    }
}

    