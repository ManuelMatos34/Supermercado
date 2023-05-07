using System;
using System.Collections.Generic;

namespace ComprasDeSupermercado.Models;

public partial class List
{
    public int IdList { get; set; }

    public int? Productos { get; set; }

    public string? Creador { get; set; }

    public string? Marca { get; set; }

    public string? Supermercado { get; set; }

    public decimal? Precio { get; set; }

    public DateTime? Fecha { get; set; }

    public virtual Usuario? CreadorNavigation { get; set; }

    public virtual Marca? MarcaNavigation { get; set; }

    public virtual Producto? ProductosNavigation { get; set; }

    public virtual Supermercado? SupermercadoNavigation { get; set; }
}
