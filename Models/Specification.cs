using System;
using System.Collections.Generic;

namespace demo1.Models;

public partial class Specification
{
    public int Id { get; set; }

    public int? Productid { get; set; }

    public int? Kolvoprod { get; set; }

    public int? Creatorid { get; set; }

    public int? Materialid { get; set; }

    public string? Unit { get; set; }

    public double? Kolvomat { get; set; }

    public virtual Zakazchiki? Creator { get; set; }

    public virtual Productsmaterial? Material { get; set; }

    public virtual Productsmaterial? Product { get; set; }
}
