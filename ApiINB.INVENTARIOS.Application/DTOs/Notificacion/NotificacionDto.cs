namespace ApiINB.INVENTARIOS.Application.DTOs.Notificacion
{
    public class NotificacionDto
    {
        public int NotificacionId { get; set; }

        public int UsuarioDestinatario { get; set; }

        public string TipoTramite { get; set; } = string.Empty;

        public string Asunto { get; set; } = string.Empty;

        public string Mensaje { get; set; } = string.Empty;

        public int UsuarioEntrega { get; set; }

        public bool EmailEnviado { get; set; }

        public DateTime? FechaLectura { get; set; }

        public int SolicitudId { get; set; }
    }
}