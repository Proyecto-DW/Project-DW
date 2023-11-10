namespace appbeneficiencia.Models;

public partial class Beneficiario
{
    public int IdBeneficiario { get; set; }

    public string NombreCompleto { get; set; } = null!;

    public DateTime FechaNacimiento { get; set; }

    public int Edad { get; set; }

    public string Genero { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public string? TelefonoBeneficiario { get; set; }

    public string CodigoBeneficiario { get; set; } = null!;

    public string Nivel { get; set; } = null!;

    public string? NombrePadre { get; set; }

    public string? Dpipadre { get; set; }

    public string? TelefonoPadre { get; set; }

    public string? DireccionPadre { get; set; }

    public string? NombreMadre { get; set; }

    public string? Dpimadre { get; set; }

    public string? TelefonoMadre { get; set; }

    public string? DireccionMadre { get; set; }

    public string? TelefonoPrincipal { get; set; }

    public string? TelefonoSecundario { get; set; }

    public int? IdColaborador { get; set; }

    public bool? Estado { get; set; }

    public virtual ICollection<AsignacionBeneficio> AsignacionBeneficios { get; set; } = new List<AsignacionBeneficio>();

    public virtual Colaboradore? IdColaboradorNavigation { get; set; }
}
