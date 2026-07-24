namespace ApiINB.INVENTARIOS.Application.DTOs.Solicitud
{
    public class SolicitudDetalleCompletoDto
    {
        public int DetalleSolicitudId { get; set; }

        public int CantidadSolicitada { get; set; }

        public int? CantidadAprobada { get; set; }

        public int EstadoSolicitudDetalleId { get; set; }

        // PRODUCTO
        public int ProductoId { get; set; }

        public string ProductoNombre { get; set; } = string.Empty;

        public string CodigoProducto { get; set; } = string.Empty;

        // AUTORIZADOR
        public int AutorizadorId { get; set; }

        public int UsuarioAutorizaId { get; set; }

        public DateTime FechaAprobo { get; set; }
    }
}