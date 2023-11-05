namespace appbeneficiencia.Models;

public partial class RolOperacion
{
    public int IdAsignacionRol { get; set; }

    public int? IdRol { get; set; }

    public int? IdOperacion { get; set; }

    public virtual Operacion? IdOperacionNavigation { get; set; }

    public virtual Role? IdRolNavigation { get; set; }
}
