using System;
using System.Collections.Generic;

namespace ASPNET_SWAGA.Models;

public partial class Cart
{
    public int CartsId { get; set; }

    public int? IdUser { get; set; }

    public virtual ICollection<Cartitem> Cartitems { get; set; } = new List<Cartitem>();

    public virtual User? IdUserNavigation { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
