namespace appbeneficiencia.Models;

public partial class Puesto
{
    /// <summary>
    /// Id Puesto
    /// </summary>
    public int IdPuesto { get; set; }

    /// <summary>
    /// Nombre Puesto
    /// </summary>
    public string NombrePuesto { get; set; } = null!;

    /// <summary>
    /// Fecha Creación
    /// </summary>
    public DateTime FechaCreacion { get; set; }

    public virtual ICollection<Colaboradore> Colaboradores { get; set; } = new List<Colaboradore>();
}
