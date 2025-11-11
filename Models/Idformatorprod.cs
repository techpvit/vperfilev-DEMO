using System;
using System.Collections.Generic;

namespace demo1.Models;

public partial class Idformatorprod
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Productsmaterial> Productsmaterials { get; set; } = new List<Productsmaterial>();
}
