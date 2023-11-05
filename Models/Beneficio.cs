namespace appbeneficiencia.Models;

public partial class Beneficio
{
    public int IdBeneficio { get; set; }

    public string? Nombre { get; set; }

    public string? DetalleBeneficio { get; set; }

    public string? Soporte { get; set; }

    public int? IdPatrocinador { get; set; }

    public virtual ICollection<AsignacionBeneficio> AsignacionBeneficios { get; set; } = new List<AsignacionBeneficio>();

    public virtual Patrocinadore? IdPatrocinadorNavigation { get; set; }
}
