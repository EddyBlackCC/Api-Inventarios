namespace ApiINB.INVENTARIOS.Application.DTOs.TramiteEntregaDetalle
{
    public class CreateTramiteEntregaDetalleDto
    {
        public int EntregaId { get; set; }

        public int DetalleSolicitudId { get; set; }

        public int ProductoId { get; set; }

        public int CantidadEntregadaId { get; set; }

        public int AudCreaUsuario { get; set; }
    }
}