using ASPNET_SWAGA.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPNET_SWAGA.Repositories;

public class CartitemRepository : Repository<Cartitem>, ICartitemRepository
{
    public CartitemRepository(AspNetContext context) : base(context)
    {
    }

    protected override IQueryable<Cartitem> IncludeDetails(IQueryable<Cartitem> query) =>
        query
            .Include(ci => ci.IdProductsNavigation).ThenInclude(p => p.IdInfoProductsNavigation)
            .Include(ci => ci.IdProductsNavigation).ThenInclude(p => p.IdCategoriesNavigation);
}
