using System;
using System.Collections.Generic;

namespace MiCamioncito.Models;

public partial class Transaccione
{
    public int Id { get; set; }

    public string? TipoTransaccion { get; set; }

    public int? IdCliente { get; set; }

    public DateTime FechaInicio { get; set; }

    public DateTime? FechaFin { get; set; }

    public string DireccionRecepcion { get; set; } = null!;

    public string DireccionEntrega { get; set; } = null!;

    public int? IdVehiculo { get; set; }

    public string? Departamento { get; set; }

    public string? Municipio { get; set; }

    public int? Viaticos { get; set; }

    public virtual ICollection<AsignacionEmpleadosTransaccion> AsignacionEmpleadosTransaccions { get; set; } = new List<AsignacionEmpleadosTransaccion>();

    public virtual ICollection<GastosAdicionalesTransaccion> GastosAdicionalesTransaccions { get; set; } = new List<GastosAdicionalesTransaccion>();

    public virtual Cliente? IdClienteNavigation { get; set; }

    public virtual Vehiculo? IdVehiculoNavigation { get; set; }
}
