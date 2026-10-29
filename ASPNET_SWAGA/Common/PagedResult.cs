namespace ASPNET_SWAGA.Common;

public record PagedResult<T>(List<T> Items, int TotalCount);
