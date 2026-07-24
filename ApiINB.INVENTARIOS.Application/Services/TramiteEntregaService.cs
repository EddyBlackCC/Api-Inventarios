using ApiINB.INVENTARIOS.Application.DTOs.TramiteEntrega;
using ApiINB.INVENTARIOS.Application.Interfaces;
using ApiINB.INVENTARIOS.Domain.Entities;

namespace ApiINB.INVENTARIOS.Application.Services
{
    public class TramiteEntregaService : ITramiteEntregaService
    {
        private readonly IProductoRepository _productoRepository;
        private readonly ITramiteEntregaRepository _repository;
        private readonly ISolicitudRepository _solicitudRepository;

        public TramiteEntregaService(ITramiteEntregaRepository repository, IProductoRepository productoRepository, ISolicitudRepository solicitudRepository)
        {
            _repository = repository;
            _productoRepository = productoRepository;
            _solicitudRepository = solicitudRepository;
        }

        public async Task CreateAsync(CreateTramiteEntregaDto dto)
        {
            var entrega = new TramiteEntrega
            {
                SolicitudId = dto.SolicitudId,
                TipoEntrega = dto.TipoEntrega,
                FechaTramite = dto.FechaTramite,
                FechaEntrega = dto.FechaEntrega,
                UsuarioEntrega = dto.UsuarioEntrega,
                PersonaRecibe = dto.PersonaRecibe,
                LugarEntrega = dto.LugarEntrega,
                FirmaEntregaBase64 = dto.FirmaEntregaBase64,
                FirmaRecibeBase64 = dto.FirmaRecibeBase64,

                AudCreaUsuario = dto.AudCreaUsuario,
                AudCreaFecha = DateTime.Now,

                Activo = true,

                Detalles = dto.Detalles.Select(d => new TramiteEntregaDetalle
                {
                    DetalleSolicitudId = d.DetalleSolicitudId,
                    ProductoId = d.ProductoId,
                    CantidadEntregadaId = d.CantidadEntregadaId,

                    AudCreaUsuario = dto.AudCreaUsuario,
                    AudCreaFecha = DateTime.Now,

                    Activo = true
                }).ToList()
            };

            await _repository.AddAsync(entrega);

            await _repository.SaveChangesAsync();

            foreach (var detalle in dto.Detalles)
            {
                var detalleSolicitud =
                    await _solicitudRepository.GetDetalleByIdAsync(
                        detalle.DetalleSolicitudId);

                if (detalleSolicitud == null)
                    continue;
                var producto = await _productoRepository
    .GetByIdAsync(detalle.ProductoId);

                if (producto == null)
                {
                    throw new Exception("Producto no existe");
                }

                if (producto.StockActual < detalle.CantidadEntregadaId)
                {
                    throw new Exception(
                        $"Stock insuficiente para el producto {producto.NombreProducto}");
                }

                producto.StockActual -= detalle.CantidadEntregadaId;
                
                var totalEntregado =
                    await _repository.ObtenerTotalEntregadoAsync(
                        detalle.DetalleSolicitudId);

                if (totalEntregado >
                    detalleSolicitud.CantidadAprobada)
                {
                    throw new Exception(
                        "La cantidad entregada excede la aprobada");
                }

                if (totalEntregado == 0)
                {
                    detalleSolicitud.EstadoEntregaDetalleId = 2001;
                }
                else if (totalEntregado <
                         detalleSolicitud.CantidadAprobada)
                {
                    detalleSolicitud.EstadoEntregaDetalleId = 2002;
                }
                else
                {
                    detalleSolicitud.EstadoEntregaDetalleId = 2003;
                }
            }

            await _repository.SaveChangesAsync();
        }

        public async Task<List<TramiteEntregaResponseDto>> GetAllAsync()
        {
            var data = await _repository.GetAllAsync();

            return data.Select(x => new TramiteEntregaResponseDto
            {
                EntregaId = x.EntregaId,
                SolicitudId = x.SolicitudId,
                TipoEntrega = x.TipoEntrega,
                FechaEntrega = x.FechaEntrega,
                PersonaRecibe = x.PersonaRecibe,
                Activo = x.Activo
            }).ToList();
        }

        public async Task<TramiteEntregaResponseDto?> GetByIdAsync(int id)
        {
            var x = await _repository.GetByIdAsync(id);

            if (x == null)
                return null;

            return new TramiteEntregaResponseDto
            {
                EntregaId = x.EntregaId,
                SolicitudId = x.SolicitudId,
                TipoEntrega = x.TipoEntrega,
                FechaEntrega = x.FechaEntrega,
                PersonaRecibe = x.PersonaRecibe,
                Activo = x.Activo
            };
        }
    }
}