using System;
using System.Collections.Generic;

namespace ASPNET_SWAGA.Models;

public partial class Ordersitem
{
    public int OrderItemsId { get; set; }

    public int IdOrders { get; set; }

    public int IdProducts { get; set; }

    public int CountItem { get; set; }

    public decimal TotalPrice { get; set; }

    public virtual Order IdOrdersNavigation { get; set; } = null!;

    public virtual Product IdProductsNavigation { get; set; } = null!;
}
