using System;
using System.Collections.Generic;

namespace appbeneficiencia.Models;

public partial class PadresDeFamilium
{
    public int IdPadre { get; set; }

    public string? Dpipadre { get; set; }

    public string? NombreCompletoPadre { get; set; }

    public string? TelefonoPadre { get; set; }

    public string? Dpimadre { get; set; }

    public string? NombreCompletoMadre { get; set; }

    public string? TelefonoMadre { get; set; }

    public string? DireccionPrincipal { get; set; }

    public string? DireccionSecundaria { get; set; }

    public virtual ICollection<Beneficiario> Beneficiarios { get; set; } = new List<Beneficiario>();
}
