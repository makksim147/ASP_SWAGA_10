using System;
using System.Collections.Generic;

namespace ASPNET_SWAGA.Models;

public partial class Cartitem
{
    public int CartItemsId { get; set; }

    public int IdCart { get; set; }

    public int IdProducts { get; set; }

    public int CountItems { get; set; }

    public virtual Cart IdCartNavigation { get; set; } = null!;

    public virtual Product IdProductsNavigation { get; set; } = null!;
}
