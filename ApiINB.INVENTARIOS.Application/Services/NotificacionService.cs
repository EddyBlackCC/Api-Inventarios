using ApiINB.INVENTARIOS.Application.DTOs.Notificacion;
using ApiINB.INVENTARIOS.Domain.Entities;
using ApiINB.INVENTARIOS.Application.Interfaces;

namespace ApiINB.INVENTARIOS.Application.Services
{
    public class NotificacionService : INotificacionService
    {
        private readonly INotificacionRepository _repository;

        public NotificacionService(INotificacionRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<NotificacionDto>> GetAllAsync()
        {
            var lista = await _repository.GetAllAsync();

            return lista.Select(x => new NotificacionDto
            {
                NotificacionId = x.NotificacionId,
                UsuarioDestinatario = x.UsuarioDestinatario,
                TipoTramite = x.TipoTramite,
                Asunto = x.Asunto,
                Mensaje = x.Mensaje,
                UsuarioEntrega = x.UsuarioEntrega,
                EmailEnviado = x.EmailEnviado,
                FechaLectura = x.FechaLectura,
                SolicitudId = x.SolicitudId
            });
        }

        public async Task CreateAsync(CreateNotificacionDto dto)
        {
            var entity = new Notificacion
            {
                UsuarioDestinatario = dto.UsuarioDestinatario,
                TipoTramite = dto.TipoTramite,
                Asunto = dto.Asunto,
                Mensaje = dto.Mensaje,
                UsuarioEntrega = dto.UsuarioEntrega,
                EmailEnviado = dto.EmailEnviado,
                FechaLectura = dto.FechaLectura,
                SolicitudId = dto.SolicitudId,

                AudCreaUsuario = dto.AudCreaUsuario,
                AudCreaFecha = DateTime.Now,
                Activo = true
            };

            await _repository.AddAsync(entity);

            await _repository.SaveChangesAsync();
        }
    }
}