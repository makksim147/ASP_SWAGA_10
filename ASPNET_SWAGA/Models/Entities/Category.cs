using System;
using System.Collections.Generic;

namespace ASPNET_SWAGA.Models;

public partial class Category
{
    public int CategoriesId { get; set; }

    public string CategoriesItems { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
