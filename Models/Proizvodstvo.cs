using System;
using System.Collections.Generic;

namespace demo1.Models;

public partial class Proizvodstvo
{
    public int Id { get; set; }

    public int? Productid { get; set; }

    public string? Kodprod { get; set; }

    public int? Kolvoprod { get; set; }

    public string? Unitprod { get; set; }

    public int? Materialid { get; set; }

    public string? Materialkod { get; set; }

    public double? Kolvomaterial { get; set; }

    public string? Unitmaterial { get; set; }

    public virtual Productsmaterial? Material { get; set; }

    public virtual Productsmaterial? Product { get; set; }
}
