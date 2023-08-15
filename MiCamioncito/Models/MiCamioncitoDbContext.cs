using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MiCamioncito.Models;

public partial class MiCamioncitoDbContext : DbContext
{
    public MiCamioncitoDbContext()
    {
    }

    public MiCamioncitoDbContext(DbContextOptions<MiCamioncitoDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AsignacionEmpleadosTransaccion> AsignacionEmpleadosTransaccions { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<GastosAdicionalesTransaccion> GastosAdicionalesTransaccions { get; set; }

    public virtual DbSet<Transaccione> Transacciones { get; set; }

    public virtual DbSet<Vehiculo> Vehiculos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        //   => optionsBuilder.UseSqlServer("server=DESKTOP-795S2OP; database=MiCamioncitoDB; integrated security=true; TrustServerCertificate=True");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AsignacionEmpleadosTransaccion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__asignaci__3213E83FA300EFDF");

            entity.ToTable("asignacionEmpleadosTransaccion");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdEmpleado).HasColumnName("idEmpleado");
            entity.Property(e => e.IdTransaccion).HasColumnName("idTransaccion");

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.AsignacionEmpleadosTransaccions)
                .HasForeignKey(d => d.IdEmpleado)
                .HasConstraintName("FK__asignacio__idEmp__4316F928");

            entity.HasOne(d => d.IdTransaccionNavigation).WithMany(p => p.AsignacionEmpleadosTransaccions)
                .HasForeignKey(d => d.IdTransaccion)
                .HasConstraintName("FK__asignacio__idTra__440B1D61");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__clientes__3213E83F61F2A23B");

            entity.ToTable("clientes");

            entity.HasIndex(e => e.CodigoCliente, "UQ__clientes__6B8A31ACDE4D79DB").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CodigoCliente)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("codigoCliente");
            entity.Property(e => e.Direccion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.Documentacion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("documentacion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.PorcentajeCargo).HasColumnName("porcentajeCargo");
            entity.Property(e => e.Telefono)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__empleado__3213E83F1EE3BB5A");

            entity.ToTable("empleados");

            entity.HasIndex(e => e.CodigoEmpleado, "UQ__empleado__18674A5AE5136FCF").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Apellido)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.CodigoEmpleado)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("codigoEmpleado");
            entity.Property(e => e.Cui).HasColumnName("cui");
            entity.Property(e => e.Disponibilidad)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("disponibilidad");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.TipoEmpleado)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("tipoEmpleado");
        });

        modelBuilder.Entity<GastosAdicionalesTransaccion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__gastosAd__3213E83F8559112E");

            entity.ToTable("gastosAdicionalesTransaccion");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CostoGasto).HasColumnName("costoGasto");
            entity.Property(e => e.DescripcionGasto)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("descripcionGasto");
            entity.Property(e => e.IdTransaccion).HasColumnName("idTransaccion");

            entity.HasOne(d => d.IdTransaccionNavigation).WithMany(p => p.GastosAdicionalesTransaccions)
                .HasForeignKey(d => d.IdTransaccion)
                .HasConstraintName("FK__gastosAdi__idTra__46E78A0C");
        });

        modelBuilder.Entity<Transaccione>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__transacc__3213E83F7296BE38");

            entity.ToTable("transacciones");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Departamento)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("departamento");
            entity.Property(e => e.DireccionEntrega)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("direccionEntrega");
            entity.Property(e => e.DireccionRecepcion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("direccionRecepcion");
            entity.Property(e => e.FechaFin)
                .HasColumnType("datetime")
                .HasColumnName("fechaFin");
            entity.Property(e => e.FechaInicio)
                .HasColumnType("datetime")
                .HasColumnName("fechaInicio");
            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.IdVehiculo).HasColumnName("idVehiculo");
            entity.Property(e => e.Municipio)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("municipio");
            entity.Property(e => e.TipoTransaccion)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("tipoTransaccion");
            entity.Property(e => e.Viaticos).HasColumnName("viaticos");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Transacciones)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK__transacci__idCli__3F466844");

            entity.HasOne(d => d.IdVehiculoNavigation).WithMany(p => p.Transacciones)
                .HasForeignKey(d => d.IdVehiculo)
                .HasConstraintName("FK__transacci__idVeh__403A8C7D");
        });

        modelBuilder.Entity<Vehiculo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__vehiculo__3213E83F4F6D7D30");

            entity.ToTable("vehiculos");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Capacidad).HasColumnName("capacidad");
            entity.Property(e => e.ConsumoConbustible).HasColumnName("consumoConbustible");
            entity.Property(e => e.Disponibilidad)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("disponibilidad");
            entity.Property(e => e.DistanciaPendiente).HasColumnName("distanciaPendiente");
            entity.Property(e => e.TipoCarga)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("tipoCarga");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
