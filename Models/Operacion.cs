namespace appbeneficiencia.Models;

public partial class Operacion
{
    public int IdOperacion { get; set; }

    public string? Nombre { get; set; }

    public int? IdModulo { get; set; }

    public virtual Modulo? IdModuloNavigation { get; set; }

    public virtual ICollection<RolOperacion> RolOperacions { get; set; } = new List<RolOperacion>();
}
