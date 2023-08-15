using System;
using System.Collections.Generic;

namespace MiCamioncito.Models;

public partial class Empleado
{
    public int Id { get; set; }

    public string CodigoEmpleado { get; set; } = null!;

    public int? Cui { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Disponibilidad { get; set; }

    public string TipoEmpleado { get; set; } = null!;

    public virtual ICollection<AsignacionEmpleadosTransaccion> AsignacionEmpleadosTransaccions { get; set; } = new List<AsignacionEmpleadosTransaccion>();
}
