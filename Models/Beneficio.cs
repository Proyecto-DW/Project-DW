using System;
using System.Collections.Generic;

namespace appbeneficiencia.Models;

public partial class Beneficio
{
    public int IdBeneficio { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Patrocinadore> Patrocinadores { get; set; } = new List<Patrocinadore>();
}
