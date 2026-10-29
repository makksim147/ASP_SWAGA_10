using ASPNET_SWAGA.Models.CreateDTO;
using ASPNET_SWAGA.Models.DTO;
using ASPNET_SWAGA.Models.PatchDTO;
using ASPNET_SWAGA.Models.UpdateDTO;

namespace ASPNET_SWAGA.Services;

public interface IOrderService : ICrudService<OrderDTO, CreateOrderDTO, UpdateOrderDTO, PatchOrderDTO>
{
}
