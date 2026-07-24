namespace ApiINB.INVENTARIOS.Domain.Common;

public abstract class AuditableEntity
{
    public int AudCreaUsuario { get; set; }

    public DateTime AudCreaFecha { get; set; }

    public int? AudModUsuario { get; set; }

    public DateTime? AudModFecha { get; set; }

    public bool Activo { get; set; } = true;
}