using ASPNET_SWAGA.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPNET_SWAGA.Repositories;

public class InfoproductRepository : Repository<Infoproduct>, IInfoproductRepository
{
    public InfoproductRepository(AspNetContext context) : base(context)
    {
    }
}
