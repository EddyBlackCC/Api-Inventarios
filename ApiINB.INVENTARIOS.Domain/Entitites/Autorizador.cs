using ApiINB.INVENTARIOS.Domain.Common;
public class Autorizador : AuditableEntity
{
    public int AutorizadorId { get; set; }

    public int DespachoAutorizaId { get; set; }

    public int UsuarioAutorizaId { get; set; }

    public DateTime? FechaAutorizado { get; set; }

}