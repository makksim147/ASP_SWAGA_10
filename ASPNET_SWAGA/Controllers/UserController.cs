using ASPNET_SWAGA.Models.CreateDTO;
using ASPNET_SWAGA.Models.DTO;
using ASPNET_SWAGA.Models.PatchDTO;
using ASPNET_SWAGA.Models.UpdateDTO;
using ASPNET_SWAGA.Services;

namespace ASPNET_SWAGA.Controllers;

public class UserController : CrudControllerBase<UserDTO, CreateUserDTO, UpdateUserDTO, PatchUserDTO>
{
    public UserController(IUserService service) : base(service)
    {
    }

    protected override int GetId(UserDTO dto) => dto.UsersId;
}
