using ASPNET_SWAGA.Models.CreateDTO;
using ASPNET_SWAGA.Models.DTO;
using ASPNET_SWAGA.Models.PatchDTO;
using ASPNET_SWAGA.Models.UpdateDTO;
using ASPNET_SWAGA.Services;

namespace ASPNET_SWAGA.Controllers;

public class OrdersitemController : CrudControllerBase<OrdersitemDTO, CreateOrdersitemDTO, UpdateOrdersitemDTO, PatchOrdersitemDTO>
{
    public OrdersitemController(IOrdersitemService service) : base(service)
    {
    }

    protected override int GetId(OrdersitemDTO dto) => dto.OrderItemsId;
}
