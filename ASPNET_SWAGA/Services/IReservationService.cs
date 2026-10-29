using ASPNET_SWAGA.Common;
using ASPNET_SWAGA.Models.CreateDTO;
using ASPNET_SWAGA.Models.DTO;

namespace ASPNET_SWAGA.Services;

public interface IReservationService
{
    Task<PagedResult<ReservationDTO>> GetPageAsync(int page, int pageSize, CancellationToken ct = default);
    Task<ServiceResult<ReservationDTO>> GetByIdAsync(int id, CancellationToken ct = default);

    Task<ServiceResult<ReservationDTO>> ReserveAsync(ReserveProductDTO dto, CancellationToken ct = default);

    Task<ServiceResult<ReservationDTO>> CancelAsync(int reservationId, CancellationToken ct = default);
}
