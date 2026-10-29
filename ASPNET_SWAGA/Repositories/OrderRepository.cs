using ASPNET_SWAGA.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPNET_SWAGA.Repositories;

public class OrderRepository : Repository<Order>, IOrderRepository
{
    public OrderRepository(AspNetContext context) : base(context)
    {
    }

    protected override IQueryable<Order> IncludeDetails(IQueryable<Order> query) =>
        query
            .Include(o => o.Ordersitems).ThenInclude(oi => oi.IdProductsNavigation).ThenInclude(p => p.IdInfoProductsNavigation)
            .Include(o => o.Ordersitems).ThenInclude(oi => oi.IdProductsNavigation).ThenInclude(p => p.IdCategoriesNavigation)
            .AsSplitQuery();
}
