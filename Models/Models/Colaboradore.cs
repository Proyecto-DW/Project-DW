namespace appbeneficiencia.Models;

public partial class Colaboradore
{
    /// <summary>
    /// Id Colaborador
    /// </summary>
    public int IdColaborador { get; set; }

    /// <summary>
    /// Nombre Completo
    /// </summary>
    public string? NombreCompleto { get; set; }

    public string? Profesion { get; set; }

    /// <summary>
    /// DPI Colaborador
    /// </summary>
    public string? Dpi { get; set; }

    /// <summary>
    /// Correo Electrónico
    /// </summary>
    public string? Correo { get; set; }

    /// <summary>
    /// Dirección
    /// </summary>
    public string? Direccion { get; set; }

    /// <summary>
    /// Teléfono
    /// </summary>
    public string? Telefono { get; set; }

    /// <summary>
    /// Fecha Nacimiento
    /// </summary>
    public DateTime? FechaNacimiento { get; set; }

    /// <summary>
    /// Género
    /// </summary>
    public string? Genero { get; set; }

    /// <summary>
    /// Id Puesto
    /// </summary>
    public int? IdPuesto { get; set; }

    public virtual ICollection<Beneficiario> Beneficiarios { get; set; } = new List<Beneficiario>();

    public virtual Puesto? IdPuestoNavigation { get; set; }
}
