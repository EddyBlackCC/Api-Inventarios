namespace ApiINB.INVENTARIOS.Application.DTOs.TramiteEntregaDetalle
{
    public class TramiteEntregaDetalleDto
    {
        public int DetalleEntregaId { get; set; }

        public int EntregaId { get; set; }

        public int DetalleSolicitudId { get; set; }

        public int ProductoId { get; set; }

        public int CantidadEntregada { get; set; }
    }
}