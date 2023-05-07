using System;
using System.Collections.Generic;

namespace ComprasDeSupermercado.Models;

public partial class Producto
{
    public int IdProducto { get; set; }

    public string? NombreProducto { get; set; }

    public decimal? PrecioProducto { get; set; }

    public string? DescripcionProducto { get; set; }

    public string? EstatusProducto { get; set; }

    public string? Marca { get; set; }

    public string? Supermercado { get; set; }

    public virtual Estatus? EstatusProductoNavigation { get; set; }

    public virtual ICollection<List> Lists { get; set; } = new List<List>();

    public virtual Marca? MarcaNavigation { get; set; }

    public virtual Supermercado? SupermercadoNavigation { get; set; }
}
