using ASPNET_SWAGA.Common;
using ASPNET_SWAGA.Models;
using ASPNET_SWAGA.Models.CreateDTO;
using ASPNET_SWAGA.Models.DTO;
using ASPNET_SWAGA.Models.PatchDTO;
using ASPNET_SWAGA.Models.UpdateDTO;
using ASPNET_SWAGA.Repositories;
using AutoMapper;

namespace ASPNET_SWAGA.Services;

public class UserService
    : CrudService<User, UserDTO, CreateUserDTO, UpdateUserDTO, PatchUserDTO>, IUserService
{
    private readonly IRoleRepository _roles;

    public UserService(IUserRepository repository, IMapper mapper, IRoleRepository roles)
        : base(repository, mapper)
    {
        _roles = roles;
    }

    protected override Task<ServiceResult> ValidateCreateAsync(CreateUserDTO dto, CancellationToken ct) =>
        CheckReferencesAsync(dto.IdRoles, ct);

    protected override Task<ServiceResult> ValidateUpdateAsync(int id, UpdateUserDTO dto, CancellationToken ct) =>
        CheckReferencesAsync(dto.IdRoles, ct);

    protected override Task<ServiceResult> ValidatePatchAsync(int id, PatchUserDTO dto, CancellationToken ct) =>
        CheckReferencesAsync(dto.IdRoles, ct);

    private async Task<ServiceResult> CheckReferencesAsync(int? idRoles, CancellationToken ct)
    {
        if (idRoles.HasValue && !await _roles.ExistsAsync(idRoles.Value, ct))
            return ServiceResult.Validation("Указанная роль не существует.");

        return ServiceResult.Ok();
    }
}
