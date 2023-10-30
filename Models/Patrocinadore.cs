using System;
using System.Collections.Generic;

namespace appbeneficiencia.Models;

public partial class Patrocinadore
{
    public int IdPatrocinador { get; set; }

    public string? CodigoPais { get; set; }

    public bool Estado { get; set; }

    public string? Soporte { get; set; }

    public int? TipoBeneficio { get; set; }

    public virtual ICollection<AsignacionBeneficio> AsignacionBeneficios { get; set; } = new List<AsignacionBeneficio>();

    public virtual Beneficio? TipoBeneficioNavigation { get; set; }
}
