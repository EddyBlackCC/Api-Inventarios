using ApiINB.INVENTARIOS.Application.DTOs.Solicitud;
using ApiINB.INVENTARIOS.Application.Interfaces;
using ApiINB.INVENTARIOS.Domain.Entities;

namespace ApiINB.INVENTARIOS.Application.Services
{
    public class SolicitudService : ISolicitudService
    {
        private readonly ISolicitudRepository _repository;

        public SolicitudService(ISolicitudRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateAsync(CreateSolicitudDto dto)
        {
            var solicitud = new Solicitud
            {
                DependenciaId = dto.DependenciaId,
                EstadoSolicitudId = 1091,
                FechaSolicitud = DateTime.Now,
                LugarEntrega = dto.LugarEntrega,
                FechaEntregaSolicitada = dto.FechaEntregaSolicitada,
                PersonaRecibe = dto.PersonaRecibe,
                ObservacionesSolicitud = dto.ObservacionesSolicitud,
                Activo = true,

                AudCreaUsuario = 1,
                AudCreaFecha = DateTime.Now,

                Detalles = dto.Detalles.Select(d => new SolicitudDetalle
                {
                    ProductoId = d.ProductoId,
                    CantidadSolicitada = d.CantidadSolicitada,
                    EstadoSolicitudDetalleId = 1091,
                    EstadoEntregaDetalleId = 2001,
                    AutorizadorId = d.AutorizadorId,
                    Activo = true,

                    AudCreaUsuario = 1,
                    AudCreaFecha = DateTime.Now
                }).ToList()
            };

            await _repository.AddAsync(solicitud);

            await _repository.SaveChangesAsync();
        }

        public async Task<List<object>> GetAllAsync()
        {
            var solicitudes = await _repository.GetAllAsync();

            return solicitudes.Select(x => new
            {
                x.SolicitudId,
                x.DependenciaId,
                x.FechaSolicitud,
                x.PersonaRecibe,
                CantidadItems = x.Detalles.Count
            }).Cast<object>().ToList();
        }

        public async Task<object?> GetByIdAsync(int id)
        {
            var solicitud = await _repository.GetByIdAsync(id);

            if (solicitud == null)
                return null;

            return new
            {
                solicitud.SolicitudId,
                solicitud.DependenciaId,
                solicitud.FechaSolicitud,
                solicitud.PersonaRecibe,
                solicitud.LugarEntrega,
                solicitud.ObservacionesSolicitud,

                Detalles = solicitud.Detalles.Select(d => new
                {
                    d.DetalleSolicitudId,
                    d.ProductoId,
                    d.CantidadSolicitada,
                    d.CantidadAprobada
                })
            };
        }

        public async Task<SolicitudCompletaDto?> GetCompletaAsync(int id)
        {
            var solicitud = await _repository.GetCompletaByIdAsync(id);

            if (solicitud == null)
                return null;

            return new SolicitudCompletaDto
            {
                SolicitudId = solicitud.SolicitudId,
                DependenciaId = solicitud.DependenciaId,
                EstadoSolicitudId = solicitud.EstadoSolicitudId,
                FechaSolicitud = solicitud.FechaSolicitud,
                LugarEntrega = solicitud.LugarEntrega,
                PersonaRecibe = solicitud.PersonaRecibe,

                Detalles = solicitud.Detalles.Select(d => new SolicitudDetalleCompletoDto
                {
                    DetalleSolicitudId = d.DetalleSolicitudId,
                    CantidadSolicitada = d.CantidadSolicitada,
                    CantidadAprobada = d.CantidadAprobada,
                    EstadoSolicitudDetalleId = d.EstadoSolicitudDetalleId,

                    ProductoId = d.ProductoId,
                    ProductoNombre = d.Producto?.NombreProducto ?? "",
                    CodigoProducto = d.Producto?.CodigoProducto ?? "",

                    AutorizadorId = d.AutorizadorId,
                    UsuarioAutorizaId = d.Autorizador?.UsuarioAutorizaId ?? 0,

                    FechaAprobo = d.FechaAprobo ?? DateTime.MinValue
                }).ToList()
            };
        }



        public async Task<bool> AprobarDetalleAsync(
    int detalleSolicitudId,
    ApproveSolicitudDetalleDto dto)
        {
            var detalle = await _repository
                .GetDetalleByIdAsync(detalleSolicitudId);

            if (detalle == null)
                return false;

            detalle.CantidadAprobada = dto.CantidadAprobada;

            detalle.AutorizadorId = dto.AutorizadorId;

            detalle.FechaAprobo = DateTime.Now;

            // 1092 = APROBADO
            detalle.EstadoSolicitudDetalleId = 1092;

            await _repository.SaveChangesAsync();

            return true;
        }
        public async Task<bool> RechazarDetalleAsync(
    int detalleSolicitudId,
    ApproveSolicitudDetalleDto dto)
        {
            var detalle = await _repository
                .GetDetalleByIdAsync(detalleSolicitudId);

            if (detalle == null)
                return false;

            detalle.EstadoSolicitudDetalleId = 1093; // RECHAZADO

            detalle.CantidadAprobada = 0;

            detalle.AutorizadorId = dto.AutorizadorId;

            detalle.FechaAprobo = DateTime.Now;

            await _repository.SaveChangesAsync();

            return true;
        }

    }
}