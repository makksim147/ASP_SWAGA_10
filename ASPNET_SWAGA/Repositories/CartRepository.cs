using ASPNET_SWAGA.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPNET_SWAGA.Repositories;

public class CartRepository : Repository<Cart>, ICartRepository
{
    public CartRepository(AspNetContext context) : base(context)
    {
    }

    protected override IQueryable<Cart> IncludeDetails(IQueryable<Cart> query) =>
        query
            .Include(c => c.IdUserNavigation).ThenInclude(u => u!.IdRolesNavigation)
            .Include(c => c.Cartitems).ThenInclude(ci => ci.IdProductsNavigation).ThenInclude(p => p.IdInfoProductsNavigation)
            .Include(c => c.Cartitems).ThenInclude(ci => ci.IdProductsNavigation).ThenInclude(p => p.IdCategoriesNavigation)
            .AsSplitQuery();
}
