using ASPNET_SWAGA.Common;

namespace ASPNET_SWAGA.Services;

public interface ICrudService<TDto, TCreate, TUpdate, TPatch>
{
    Task<PagedResult<TDto>> GetPageAsync(int page, int pageSize, CancellationToken ct = default);
    Task<ServiceResult<TDto>> GetByIdAsync(int id, CancellationToken ct = default);
    Task<ServiceResult<TDto>> CreateAsync(TCreate dto, CancellationToken ct = default);
    Task<ServiceResult> UpdateAsync(int id, TUpdate dto, CancellationToken ct = default);
    Task<ServiceResult> PatchAsync(int id, TPatch dto, CancellationToken ct = default);
    Task<ServiceResult> DeleteAsync(int id, CancellationToken ct = default);
}
