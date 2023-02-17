using System;
using System.Collections.Generic;

namespace Ejercicio1_Festejo.Models;

public partial class Vwmenoresdoce
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public DateTime FechaNacimiento { get; set; }

    public string? Domicilio { get; set; }

    public long? Edad { get; set; }
}
