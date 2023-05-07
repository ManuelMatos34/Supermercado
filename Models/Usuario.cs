using System;
using System.Collections.Generic;

namespace ComprasDeSupermercado.Models;

public partial class Usuario
{
    public string NombreUsuario { get; set; } = null!;

    public string? GeneroUsuario { get; set; }

    public string? CorreoUsuario { get; set; }

    public string? TelefonoUsuario { get; set; }

    public string? NombreCompleto { get; set; }

    public string? Password { get; set; }

    public string? Rol { get; set; }

    public string? EstatusUsuario { get; set; }

    public virtual Estatus? EstatusUsuarioNavigation { get; set; }

    public virtual ICollection<List> Lists { get; set; } = new List<List>();

    public virtual Role? RolNavigation { get; set; }
}
