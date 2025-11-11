using System;
using System.Collections.Generic;

namespace demo1.Models;

public partial class Zakaz
{
    public int Id { get; set; }

    public int? Salesmanid { get; set; }

    public int? Buyerid { get; set; }

    public string? Product { get; set; }

    public int? Kolvo { get; set; }

    public string? Unit { get; set; }

    public double? Price { get; set; }

    public double? Summ { get; set; }

    public virtual Zakazchiki? Buyer { get; set; }

    public virtual Zakazchiki? Salesman { get; set; }
}
