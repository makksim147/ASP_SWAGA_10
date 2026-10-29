using ASPNET_SWAGA.Models.CreateDTO;
using ASPNET_SWAGA.Models.DTO;
using ASPNET_SWAGA.Models.PatchDTO;
using ASPNET_SWAGA.Models.UpdateDTO;
using ASPNET_SWAGA.Services;

namespace ASPNET_SWAGA.Controllers;

public class CartitemController : CrudControllerBase<CartitemDTO, CreateCartitemDTO, UpdateCartitemDTO, PatchCartitemDTO>
{
    public CartitemController(ICartitemService service) : base(service)
    {
    }

    protected override int GetId(CartitemDTO dto) => dto.CartItemsId;
}
