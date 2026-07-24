namespace ApiINB.INVENTARIOS.Application.DTOs.Solicitud
{
    public class CreateSolicitudDetalleDto
    {
        public int ProductoId { get; set; }

        public int CantidadSolicitada { get; set; }

        public int AutorizadorId { get; set; }
    }
}