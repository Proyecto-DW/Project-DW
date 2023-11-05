namespace appbeneficiencia.Models;

public partial class AsignacionBeneficio
{
    /// <summary>
    /// Id Asignación
    /// </summary>
    public int IdAsignacion { get; set; }

    /// <summary>
    /// Id Beneficiario
    /// </summary>
    public int? IdBeneficiario { get; set; }

    /// <summary>
    /// Id Beneficio
    /// </summary>
    public int? IdBeneficio { get; set; }

    /// <summary>
    /// Descripcion Beneficio
    /// </summary>
    public string? DescripcionBeneficio { get; set; }

    /// <summary>
    /// Fecha Asignación
    /// </summary>
    public DateTime? FechaAsignacion { get; set; }

    public decimal? Monto { get; set; }

    /// <summary>
    /// DPI Recibe
    /// </summary>
    public string? Dpi { get; set; }

    /// <summary>
    /// Parentesco
    /// </summary>
    public string? Parentesco { get; set; }

    public string? Comentarios { get; set; }

    public virtual Beneficiario? IdBeneficiarioNavigation { get; set; }

    public virtual Beneficio? IdBeneficioNavigation { get; set; }
}
