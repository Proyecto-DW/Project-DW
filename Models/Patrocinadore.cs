namespace appbeneficiencia.Models;

public partial class Patrocinadore
{
    public int IdPatrocinador { get; set; }

    /// <summary>
    /// Código Referencia
    /// </summary>
    public string? CodigoReferencia { get; set; }

    /// <summary>
    /// Código Pais
    /// </summary>
    public string? CodigoPais { get; set; }

    /// <summary>
    /// Estado
    /// </summary>
    public bool? Estado { get; set; }

    /// <summary>
    /// Fecha Registro
    /// </summary>
    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<Beneficio> Beneficios { get; set; } = new List<Beneficio>();
}
