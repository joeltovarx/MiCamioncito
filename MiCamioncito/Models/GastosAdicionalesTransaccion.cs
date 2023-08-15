using System;
using System.Collections.Generic;

namespace MiCamioncito.Models;

public partial class GastosAdicionalesTransaccion
{
    public int Id { get; set; }

    public string? DescripcionGasto { get; set; }

    public int? CostoGasto { get; set; }

    public int? IdTransaccion { get; set; }

    public virtual Transaccione? IdTransaccionNavigation { get; set; }
}
