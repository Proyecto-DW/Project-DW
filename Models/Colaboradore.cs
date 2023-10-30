using System;
using System.Collections.Generic;

namespace appbeneficiencia.Models;

public partial class Colaboradore
{
    public int IdColaborador { get; set; }

    public string? NombreCompleto { get; set; }

    public string? Dpi { get; set; }

    public string? Correo { get; set; }

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public DateTime? FechaNacimiento { get; set; }

    public string? Genero { get; set; }

    public int? IdPuesto { get; set; }

    public virtual ICollection<Beneficiario> Beneficiarios { get; set; } = new List<Beneficiario>();

    public virtual Puesto? IdPuestoNavigation { get; set; }
}
