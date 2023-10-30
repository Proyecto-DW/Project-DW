using System;
using System.Collections.Generic;

namespace appbeneficiencia.Models;

public partial class AsignacionBeneficio
{
    public int IdAsignacion { get; set; }

    public int? IdBeneficiario { get; set; }

    public int? IdPatrocinador { get; set; }

    public DateTime? FechaAsignacion { get; set; }

    public string? DescripcionBeneficio { get; set; }

    public decimal? Monto { get; set; }

    public int? Dpi { get; set; }

    public string? Parentesco { get; set; }

    public string? FirmaRecibido { get; set; }

    public virtual Beneficiario? IdBeneficiarioNavigation { get; set; }

    public virtual Patrocinadore? IdPatrocinadorNavigation { get; set; }
}
