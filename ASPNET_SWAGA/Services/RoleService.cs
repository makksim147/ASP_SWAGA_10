using ASPNET_SWAGA.Models;
using ASPNET_SWAGA.Models.CreateDTO;
using ASPNET_SWAGA.Models.DTO;
using ASPNET_SWAGA.Models.PatchDTO;
using ASPNET_SWAGA.Models.UpdateDTO;
using ASPNET_SWAGA.Repositories;
using AutoMapper;

namespace ASPNET_SWAGA.Services;

public class RoleService
    : CrudService<Role, RoleDTO, CreateRoleDTO, UpdateRoleDTO, PatchRoleDTO>, IRoleService
{
    public RoleService(IRoleRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }
}
