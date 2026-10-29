using ASPNET_SWAGA.Models.CreateDTO;
using ASPNET_SWAGA.Models.DTO;
using ASPNET_SWAGA.Models.PatchDTO;
using ASPNET_SWAGA.Models.UpdateDTO;
using ASPNET_SWAGA.Services;

namespace ASPNET_SWAGA.Controllers;

public class CartController : CrudControllerBase<CartDTO, CreateCartDTO, UpdateCartDTO, PatchCartDTO>
{
    public CartController(ICartService service) : base(service)
    {
    }

    protected override int GetId(CartDTO dto) => dto.CartsId;
}
