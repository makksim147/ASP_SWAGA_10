using ASPNET_SWAGA.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPNET_SWAGA.Repositories;

public class ProductRepository : Repository<Product>, IProductRepository
{
    public ProductRepository(AspNetContext context) : base(context)
    {
    }

    protected override IQueryable<Product> IncludeDetails(IQueryable<Product> query) =>
        query
            .Include(p => p.IdInfoProductsNavigation)
            .Include(p => p.IdCategoriesNavigation);
}
