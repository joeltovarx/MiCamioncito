using System;
using System.Collections.Generic;

namespace MiCamioncito.Models;

public partial class Vehiculo
{
    public int Id { get; set; }

    public int? Capacidad { get; set; }

    public int? ConsumoConbustible { get; set; }

    public int? DistanciaPendiente { get; set; }

    public string? Disponibilidad { get; set; }

    public string? TipoCarga { get; set; }

    public virtual ICollection<Transaccione> Transacciones { get; set; } = new List<Transaccione>();
}
