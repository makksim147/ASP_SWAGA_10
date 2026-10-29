using ASPNET_SWAGA.Common;
using ASPNET_SWAGA.Models;
using ASPNET_SWAGA.Models.CreateDTO;
using ASPNET_SWAGA.Models.DTO;
using ASPNET_SWAGA.Models.PatchDTO;
using ASPNET_SWAGA.Models.UpdateDTO;
using ASPNET_SWAGA.Repositories;
using AutoMapper;

namespace ASPNET_SWAGA.Services;

public class CartService
    : CrudService<Cart, CartDTO, CreateCartDTO, UpdateCartDTO, PatchCartDTO>, ICartService
{
    private readonly IUserRepository _users;

    public CartService(ICartRepository repository, IMapper mapper, IUserRepository users)
        : base(repository, mapper)
    {
        _users = users;
    }

    protected override Task<ServiceResult> ValidateCreateAsync(CreateCartDTO dto, CancellationToken ct) =>
        CheckReferencesAsync(dto.IdUser, ct);

    protected override Task<ServiceResult> ValidateUpdateAsync(int id, UpdateCartDTO dto, CancellationToken ct) =>
        CheckReferencesAsync(dto.IdUser, ct);

    protected override Task<ServiceResult> ValidatePatchAsync(int id, PatchCartDTO dto, CancellationToken ct) =>
        CheckReferencesAsync(dto.IdUser, ct);

    private async Task<ServiceResult> CheckReferencesAsync(int? idUser, CancellationToken ct)
    {
        if (idUser.HasValue && !await _users.ExistsAsync(idUser.Value, ct))
            return ServiceResult.Validation("Указанный id пользователя не существует.");

        return ServiceResult.Ok();
    }
}
