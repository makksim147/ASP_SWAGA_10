using ASPNET_SWAGA.Models;

namespace ASPNET_SWAGA.Repositories;

public interface IReservationRepository : IRepository<Reservation>
{
    Task<Reservation?> GetActiveWithProductAsync(int id, CancellationToken ct = default);
}
