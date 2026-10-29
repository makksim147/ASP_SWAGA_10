using ASPNET_SWAGA.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPNET_SWAGA.Repositories;

public class OrdersitemRepository : Repository<Ordersitem>, IOrdersitemRepository
{
    public OrdersitemRepository(AspNetContext context) : base(context)
    {
    }

    protected override IQueryable<Ordersitem> IncludeDetails(IQueryable<Ordersitem> query) =>
        query
            .Include(oi => oi.IdProductsNavigation).ThenInclude(p => p.IdInfoProductsNavigation)
            .Include(oi => oi.IdProductsNavigation).ThenInclude(p => p.IdCategoriesNavigation);
}
