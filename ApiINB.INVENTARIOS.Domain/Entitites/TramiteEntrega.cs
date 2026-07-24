using ApiINB.INVENTARIOS.Domain.Common;

namespace ApiINB.INVENTARIOS.Domain.Entities
{
    public class TramiteEntrega : AuditableEntity
    {
        public int EntregaId { get; set; }

        public int SolicitudId { get; set; }

        public string TipoEntrega { get; set; } = string.Empty;

        public DateTime? FechaTramite { get; set; }

        public DateTime? FechaEntrega { get; set; }

        public int UsuarioEntrega { get; set; }

        public string PersonaRecibe { get; set; } = string.Empty;

        public string? LugarEntrega { get; set; }

        public string? FirmaEntregaBase64 { get; set; }

        public string? FirmaRecibeBase64 { get; set; }

        // navegación
        public Solicitud? Solicitud { get; set; }

        public ICollection<TramiteEntregaDetalle> Detalles { get; set; }
            = new List<TramiteEntregaDetalle>();
    }
}