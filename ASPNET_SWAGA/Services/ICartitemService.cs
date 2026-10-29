using ASPNET_SWAGA.Models.CreateDTO;
using ASPNET_SWAGA.Models.DTO;
using ASPNET_SWAGA.Models.PatchDTO;
using ASPNET_SWAGA.Models.UpdateDTO;

namespace ASPNET_SWAGA.Services;

public interface ICartitemService : ICrudService<CartitemDTO, CreateCartitemDTO, UpdateCartitemDTO, PatchCartitemDTO>
{
}
