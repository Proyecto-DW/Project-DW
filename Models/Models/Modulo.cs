namespace appbeneficiencia.Models;

public partial class Modulo
{
    public int IdModulo { get; set; }

    public string? Modulo1 { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual ICollection<Operacion> Operacions { get; set; } = new List<Operacion>();
}
