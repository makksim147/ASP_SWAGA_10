using ASPNET_SWAGA.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPNET_SWAGA.Repositories;

public class ReservationRepository : Repository<Reservation>, IReservationRepository
{
    public ReservationRepository(AspNetContext context) : base(context)
    {
    }

    protected override IQueryable<Reservation> IncludeDetails(IQueryable<Reservation> query) =>
        query
            .Include(r => r.IdUserNavigation).ThenInclude(u => u.IdRolesNavigation)
            .Include(r => r.IdProductsNavigation).ThenInclude(p => p.IdInfoProductsNavigation)
            .Include(r => r.IdProductsNavigation).ThenInclude(p => p.IdCategoriesNavigation);

    public Task<Reservation?> GetActiveWithProductAsync(int id, CancellationToken ct = default) =>
        Set.Include(r => r.IdProductsNavigation)
           .Where(r => r.ReservationsId == id && r.ReleasedAt == null)
           .FirstOrDefaultAsync(ct);
}
