using System;
using System.Collections.Generic;

namespace appbeneficiencia.Models;

public partial class Puesto
{
    public int Id { get; set; }

    public string? NombrePuesto { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual ICollection<Colaboradore> Colaboradores { get; set; } = new List<Colaboradore>();
}
