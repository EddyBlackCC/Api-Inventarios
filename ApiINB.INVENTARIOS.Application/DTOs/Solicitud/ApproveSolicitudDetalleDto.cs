namespace ApiINB.INVENTARIOS.Application.DTOs.Solicitud
{
    public class ApproveSolicitudDetalleDto
    {
        public int AutorizadorId { get; set; }

        public int CantidadAprobada { get; set; }
        public string? Observacion { get; set; }

    }
}