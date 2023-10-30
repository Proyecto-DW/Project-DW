using System;
using System.Collections.Generic;

namespace appbeneficiencia.Models;

public partial class Role
{
    public int IdRol { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<RolOperacion> RolOperacions { get; set; } = new List<RolOperacion>();

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
