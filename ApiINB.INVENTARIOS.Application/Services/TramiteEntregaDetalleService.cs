using ApiINB.INVENTARIOS.Application.DTOs.TramiteEntregaDetalle;
using ApiINB.INVENTARIOS.Application.Interfaces;
using ApiINB.INVENTARIOS.Domain.Entities;

namespace ApiINB.INVENTARIOS.Application.Services
{
    public class TramiteEntregaDetalleService : ITramiteEntregaDetalleService
    {
        private readonly ITramiteEntregaDetalleRepository _repository;

        public TramiteEntregaDetalleService(
            ITramiteEntregaDetalleRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TramiteEntregaDetalleDto>> GetAllAsync()
        {
            var lista = await _repository.GetAllAsync();

            return lista.Select(x => new TramiteEntregaDetalleDto
            {
                DetalleEntregaId = x.DetalleEntregaId,
                EntregaId = x.EntregaId,
                DetalleSolicitudId = x.DetalleSolicitudId,
                ProductoId = x.ProductoId,
                CantidadEntregada = x.CantidadEntregadaId
            });
        }

        public async Task CreateAsync(CreateTramiteEntregaDetalleDto dto)
        {
            var detalle = new TramiteEntregaDetalle
            {
                EntregaId = dto.EntregaId,
                DetalleSolicitudId = dto.DetalleSolicitudId,
                ProductoId = dto.ProductoId,
                CantidadEntregadaId = dto.CantidadEntregadaId,

                AudCreaUsuario = dto.AudCreaUsuario,
                AudCreaFecha = DateTime.Now,
                Activo = true
            };

            await _repository.AddAsync(detalle);
            await _repository.SaveChangesAsync();
        }
    }
}