using System;
using System.Collections.Generic;

namespace ASPNET_SWAGA.Models;

public partial class Infoproduct
{
    public int InfoProductsId { get; set; }

    public string NameProduct { get; set; } = null!;

    public string? DescriptionProduct { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
