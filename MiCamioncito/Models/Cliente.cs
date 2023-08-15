using System;
using System.Collections.Generic;

namespace MiCamioncito.Models;

public partial class Cliente
{
    public int Id { get; set; }

    public string CodigoCliente { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public string? Telefono { get; set; }

    public string? Documentacion { get; set; }

    public int? PorcentajeCargo { get; set; }

    public virtual ICollection<Transaccione> Transacciones { get; set; } = new List<Transaccione>();
}
