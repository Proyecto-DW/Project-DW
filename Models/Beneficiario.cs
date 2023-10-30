using System;
using System.Collections.Generic;

namespace appbeneficiencia.Models;

public partial class Beneficiario
{
    public int IdBeneficiario { get; set; }

    public string? NombreCompleto { get; set; }

    public DateTime? FechaNacimiento { get; set; }

    public string? Genero { get; set; }

    public string? Direccion { get; set; }

    public string? CodigoBeneficiario { get; set; }

    public string? Nivel { get; set; }

    /// <summary>
    /// Telefono del Beneficiario
    /// </summary>
    public string? Telefono { get; set; }

    public int? IdPadre { get; set; }

    public bool Estado { get; set; }

    public int? IdColaborador { get; set; }

    public virtual ICollection<AsignacionBeneficio> AsignacionBeneficios { get; set; } = new List<AsignacionBeneficio>();

    public virtual Colaboradore? IdColaboradorNavigation { get; set; }

    public virtual PadresDeFamilium? IdPadreNavigation { get; set; }
}
