using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ComprasDeSupermercado.Models;

public partial class SistemaComprasContext : DbContext
{
    public SistemaComprasContext()
    {
    }

    public SistemaComprasContext(DbContextOptions<SistemaComprasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Estatus> Estatuses { get; set; }

    public virtual DbSet<List> Lists { get; set; }

    public virtual DbSet<Marca> Marcas { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Supermercado> Supermercados { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Estatus>(entity =>
        {
            entity.HasKey(e => e.Estatus1).HasName("PK__estatus__7C6BAF5E209BFEFA");

            entity.ToTable("estatus");

            entity.Property(e => e.Estatus1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("estatus");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("descripcion");
        });

        modelBuilder.Entity<List>(entity =>
        {
            entity.HasKey(e => e.IdList);

            entity.ToTable("list");

            entity.Property(e => e.IdList).HasColumnName("id_list");
            entity.Property(e => e.Creador)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("creador");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.Marca)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("marca");
            entity.Property(e => e.Precio)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("precio");
            entity.Property(e => e.Productos).HasColumnName("productos");
            entity.Property(e => e.Supermercado)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("supermercado");

            entity.HasOne(d => d.CreadorNavigation).WithMany(p => p.Lists)
                .HasForeignKey(d => d.Creador)
                .HasConstraintName("FK_list_usuarios");

            entity.HasOne(d => d.MarcaNavigation).WithMany(p => p.Lists)
                .HasForeignKey(d => d.Marca)
                .HasConstraintName("FK_list_marcas");

            entity.HasOne(d => d.ProductosNavigation).WithMany(p => p.Lists)
                .HasForeignKey(d => d.Productos)
                .HasConstraintName("FK_list_productos");

            entity.HasOne(d => d.SupermercadoNavigation).WithMany(p => p.Lists)
                .HasForeignKey(d => d.Supermercado)
                .HasConstraintName("FK_list_supermercados");
        });

        modelBuilder.Entity<Marca>(entity =>
        {
            entity.HasKey(e => e.NombreMarca);

            entity.ToTable("marcas");

            entity.Property(e => e.NombreMarca)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre_marca");
            entity.Property(e => e.DescripcionMarca)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("descripcion_marca");
            entity.Property(e => e.EstatusMarca)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("estatus_marca");

            entity.HasOne(d => d.EstatusMarcaNavigation).WithMany(p => p.Marcas)
                .HasForeignKey(d => d.EstatusMarca)
                .HasConstraintName("FK_marcas_estatus");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PK__producto__FF341C0D1EA0426B");

            entity.ToTable("productos");

            entity.Property(e => e.IdProducto).HasColumnName("id_producto");
            entity.Property(e => e.DescripcionProducto)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("descripcion_producto");
            entity.Property(e => e.EstatusProducto)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("estatus_producto");
            entity.Property(e => e.Marca)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("marca");
            entity.Property(e => e.NombreProducto)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre_producto");
            entity.Property(e => e.PrecioProducto)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("precio_producto");
            entity.Property(e => e.Supermercado)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("supermercado");

            entity.HasOne(d => d.EstatusProductoNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.EstatusProducto)
                .HasConstraintName("FK_productos_estatus");

            entity.HasOne(d => d.MarcaNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.Marca)
                .HasConstraintName("FK_productos_marcas");

            entity.HasOne(d => d.SupermercadoNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.Supermercado)
                .HasConstraintName("FK_productos_supermercados");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Rol).HasName("PK__roles__C2B79D27C7550351");

            entity.ToTable("roles");

            entity.Property(e => e.Rol)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("rol");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Estatus)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("estatus");

            entity.HasOne(d => d.EstatusNavigation).WithMany(p => p.Roles)
                .HasForeignKey(d => d.Estatus)
                .HasConstraintName("FK_roles_estatus");
        });

        modelBuilder.Entity<Supermercado>(entity =>
        {
            entity.HasKey(e => e.NombreSupermercado);

            entity.ToTable("supermercados");

            entity.Property(e => e.NombreSupermercado)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre_supermercado");
            entity.Property(e => e.DescripcionSupermercado)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("descripcion_supermercado");
            entity.Property(e => e.DireccionSupermercado)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("direccion_supermercado");
            entity.Property(e => e.EstatusSupermercado)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("estatus_supermercado");

            entity.HasOne(d => d.EstatusSupermercadoNavigation).WithMany(p => p.Supermercados)
                .HasForeignKey(d => d.EstatusSupermercado)
                .HasConstraintName("FK_supermercados_estatus");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.NombreUsuario).HasName("PK__usuarios__D4D22D75C5F51D54");

            entity.ToTable("usuarios");

            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre_usuario");
            entity.Property(e => e.CorreoUsuario)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("correo_usuario");
            entity.Property(e => e.EstatusUsuario)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("estatus_usuario");
            entity.Property(e => e.GeneroUsuario)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("genero_usuario");
            entity.Property(e => e.NombreCompleto)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre_completo");
            entity.Property(e => e.Password)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Rol)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("rol");
            entity.Property(e => e.TelefonoUsuario)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("telefono_usuario");

            entity.HasOne(d => d.EstatusUsuarioNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.EstatusUsuario)
                .HasConstraintName("FK_usuarios_estatus");

            entity.HasOne(d => d.RolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.Rol)
                .HasConstraintName("FK_usuarios_roles");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
