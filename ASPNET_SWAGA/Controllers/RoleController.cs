using ASPNET_SWAGA.Models.CreateDTO;
using ASPNET_SWAGA.Models.DTO;
using ASPNET_SWAGA.Models.PatchDTO;
using ASPNET_SWAGA.Models.UpdateDTO;
using ASPNET_SWAGA.Services;

namespace ASPNET_SWAGA.Controllers;

public class RoleController : CrudControllerBase<RoleDTO, CreateRoleDTO, UpdateRoleDTO, PatchRoleDTO>
{
    public RoleController(IRoleService service) : base(service)
    {
    }

    protected override int GetId(RoleDTO dto) => dto.RolesId;
}
