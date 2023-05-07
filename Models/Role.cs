using System;
using System.Collections.Generic;

namespace ComprasDeSupermercado.Models;

public partial class Role
{
    public string Rol { get; set; } = null!;

    public string? Estatus { get; set; }

    public string? Descripcion { get; set; }

    public virtual Estatus? EstatusNavigation { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
