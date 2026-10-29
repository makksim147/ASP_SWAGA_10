using System;
using System.Collections.Generic;

namespace ASPNET_SWAGA.Models;

public partial class Order
{
    public int OrdersId { get; set; }

    public int IdCart { get; set; }

    public DateOnly? DateOrder { get; set; }

    public decimal TotalPrice { get; set; }

    public virtual Cart IdCartNavigation { get; set; } = null!;

    public virtual ICollection<Ordersitem> Ordersitems { get; set; } = new List<Ordersitem>();
}
