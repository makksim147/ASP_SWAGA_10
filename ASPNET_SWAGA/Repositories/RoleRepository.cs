using ASPNET_SWAGA.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPNET_SWAGA.Repositories;

public class RoleRepository : Repository<Role>, IRoleRepository
{
    public RoleRepository(AspNetContext context) : base(context)
    {
    }
}
