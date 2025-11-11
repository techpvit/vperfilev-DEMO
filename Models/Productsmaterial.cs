using System;
using System.Collections.Generic;

namespace demo1.Models;

public partial class Productsmaterial
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public double? Price { get; set; }

    public int? Prodormatid { get; set; }

    public virtual Idformatorprod? Prodormat { get; set; }

    public virtual ICollection<Proizvodstvo> ProizvodstvoMaterials { get; set; } = new List<Proizvodstvo>();

    public virtual ICollection<Proizvodstvo> ProizvodstvoProducts { get; set; } = new List<Proizvodstvo>();

    public virtual ICollection<Specification> SpecificationMaterials { get; set; } = new List<Specification>();

    public virtual ICollection<Specification> SpecificationProducts { get; set; } = new List<Specification>();
}
