using System;
using System.Collections.Generic;

namespace ComprasDeSupermercado.Models;

public partial class Supermercado
{
    public string NombreSupermercado { get; set; } = null!;

    public string? DireccionSupermercado { get; set; }

    public string? DescripcionSupermercado { get; set; }

    public string? EstatusSupermercado { get; set; }

    public virtual Estatus? EstatusSupermercadoNavigation { get; set; }

    public virtual ICollection<List> Lists { get; set; } = new List<List>();

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
