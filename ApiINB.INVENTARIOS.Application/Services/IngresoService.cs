using ApiINB.INVENTARIOS.Application.DTOs.Ingreso;
using ApiINB.INVENTARIOS.Application.Interfaces;
using ApiINB.INVENTARIOS.Domain.Entities;

namespace ApiINB.INVENTARIOS.Application.Services
{
    public class IngresoService : IIngresoService
    {
        private readonly IProductoRepository _productoRepository;
        private readonly IIngresoRepository _repository;

        public IngresoService(IIngresoRepository repository, IProductoRepository productoRepository)
        {
            _repository = repository;
            _productoRepository = productoRepository;
        }

        public async Task CreateAsync(CreateIngresoDto dto)
        {
            var ingreso = new Ingreso
            {
                FacturaActa = dto.FacturaActa,
                FacturaActaFecha = dto.FacturaActaFecha,
                FechaIngreso = DateTime.Now,
                Soporte = dto.Soporte,
                Observaciones = dto.Observaciones,
                Activo = true,
                AudCreaUsuario = 1,
                AudCreaFecha = DateTime.Now
            };

            foreach (var item in dto.Detalles)
            {
                ingreso.Detalles.Add(new IngresoDetalle
                {
                    ProductoId = item.ProductoId,
                    Cantidad = item.Cantidad,
                    Observaciones = item.Observaciones,
                    Activo = true
                });
            }

            await _repository.AddAsync(ingreso);

            await _repository.SaveChangesAsync();

            foreach (var detalle in ingreso.Detalles)
            {
                var producto = await _productoRepository
                    .GetByIdAsync(detalle.ProductoId);

                if (producto != null)
                {
                    producto.StockActual += detalle.Cantidad;
                }
            }

            await _repository.SaveChangesAsync();
        }

        public async Task<List<object>> GetAllAsync()
        {
            var ingresos = await _repository.GetAllAsync();

            return ingresos.Select(x => new
            {
                x.InventarioId,
                x.FacturaActa,
                x.FechaIngreso,
                x.Soporte,
                TotalDetalles = x.Detalles.Count
            }).Cast<object>().ToList();
        }
    }
}