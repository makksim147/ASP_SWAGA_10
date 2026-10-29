using ASPNET_SWAGA.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPNET_SWAGA.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(AspNetContext context) : base(context)
    {
    }

    protected override IQueryable<User> IncludeDetails(IQueryable<User> query) =>
        query.Include(u => u.IdRolesNavigation);
}
