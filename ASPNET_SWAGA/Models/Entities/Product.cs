using System;
using System.Collections.Generic;

namespace ASPNET_SWAGA.Models;

public partial class Product
{
    public int ProductsId { get; set; }

    public int IdInfoProducts { get; set; }

    public int IdCategories { get; set; }

    public decimal Price { get; set; }

    public string? ImagePath { get; set; }

    /// <summary>Остаток товара на складе (уменьшается при резервировании).</summary>
    public int StockCount { get; set; }

    public virtual ICollection<Cartitem> Cartitems { get; set; } = new List<Cartitem>();

    public virtual Category IdCategoriesNavigation { get; set; } = null!;

    public virtual Infoproduct IdInfoProductsNavigation { get; set; } = null!;

    public virtual ICollection<Ordersitem> Ordersitems { get; set; } = new List<Ordersitem>();

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
