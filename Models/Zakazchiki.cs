using System;
using System.Collections.Generic;

namespace demo1.Models;

public partial class Zakazchiki
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Inn { get; set; }

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public bool? Salesman { get; set; }

    public bool? Boyer { get; set; }

    public virtual ICollection<Specification> Specifications { get; set; } = new List<Specification>();

    public virtual ICollection<Zakaz> ZakazBuyers { get; set; } = new List<Zakaz>();

    public virtual ICollection<Zakaz> ZakazSalesmen { get; set; } = new List<Zakaz>();
}
