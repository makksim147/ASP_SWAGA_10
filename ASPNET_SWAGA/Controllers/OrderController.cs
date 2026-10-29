using ASPNET_SWAGA.Models.CreateDTO;
using ASPNET_SWAGA.Models.DTO;
using ASPNET_SWAGA.Models.PatchDTO;
using ASPNET_SWAGA.Models.UpdateDTO;
using ASPNET_SWAGA.Services;

namespace ASPNET_SWAGA.Controllers;

public class OrderController : CrudControllerBase<OrderDTO, CreateOrderDTO, UpdateOrderDTO, PatchOrderDTO>
{
    public OrderController(IOrderService service) : base(service)
    {
    }

    protected override int GetId(OrderDTO dto) => dto.OrdersId;
}
