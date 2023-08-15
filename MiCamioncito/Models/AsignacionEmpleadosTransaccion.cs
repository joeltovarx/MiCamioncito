using System;
using System.Collections.Generic;

namespace MiCamioncito.Models;

public partial class AsignacionEmpleadosTransaccion
{
    public int Id { get; set; }

    public int? IdEmpleado { get; set; }

    public int? IdTransaccion { get; set; }

    public virtual Empleado? IdEmpleadoNavigation { get; set; }

    public virtual Transaccione? IdTransaccionNavigation { get; set; }
}
