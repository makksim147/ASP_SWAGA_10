using ASPNET_SWAGA.Common;
using ASPNET_SWAGA.Models;
using ASPNET_SWAGA.Models.CreateDTO;
using ASPNET_SWAGA.Models.DTO;
using ASPNET_SWAGA.Models.PatchDTO;
using ASPNET_SWAGA.Models.UpdateDTO;
using ASPNET_SWAGA.Repositories;
using AutoMapper;

namespace ASPNET_SWAGA.Services;

public class OrderService
    : CrudService<Order, OrderDTO, CreateOrderDTO, UpdateOrderDTO, PatchOrderDTO>, IOrderService
{
    private readonly ICartRepository _carts;

    public OrderService(IOrderRepository repository, IMapper mapper, ICartRepository carts)
        : base(repository, mapper)
    {
        _carts = carts;
    }

    protected override Task<ServiceResult> ValidateCreateAsync(CreateOrderDTO dto, CancellationToken ct) =>
        CheckReferencesAsync(dto.IdCart, ct);

    protected override Task<ServiceResult> ValidateUpdateAsync(int id, UpdateOrderDTO dto, CancellationToken ct) =>
        CheckReferencesAsync(dto.IdCart, ct);

    protected override Task<ServiceResult> ValidatePatchAsync(int id, PatchOrderDTO dto, CancellationToken ct) =>
        CheckReferencesAsync(dto.IdCart, ct);
    private async Task<ServiceResult> CheckReferencesAsync(int? idCart, CancellationToken ct)
    {
        if (idCart.HasValue && !await _carts.ExistsAsync(idCart.Value, ct))
            return ServiceResult.Validation("Указанный id корзины не существует.");

        return ServiceResult.Ok();
    }
}
