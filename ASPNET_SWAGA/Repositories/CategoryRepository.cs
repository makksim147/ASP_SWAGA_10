using ASPNET_SWAGA.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPNET_SWAGA.Repositories;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    public CategoryRepository(AspNetContext context) : base(context)
    {
    }
}
