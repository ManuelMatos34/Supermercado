using System;
using System.Collections.Generic;

namespace ComprasDeSupermercado.Models;

public partial class Marca
{
    public string NombreMarca { get; set; } = null!;

    public string? DescripcionMarca { get; set; }

    public string? EstatusMarca { get; set; }

    public virtual Estatus? EstatusMarcaNavigation { get; set; }

    public virtual ICollection<List> Lists { get; set; } = new List<List>();

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
