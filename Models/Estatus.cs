using System;
using System.Collections.Generic;

namespace ComprasDeSupermercado.Models;

public partial class Estatus
{
    public string Estatus1 { get; set; } = null!;

    public string? Descripcion { get; set; }

    public virtual ICollection<Marca> Marcas { get; set; } = new List<Marca>();

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();

    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();

    public virtual ICollection<Supermercado> Supermercados { get; set; } = new List<Supermercado>();

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
