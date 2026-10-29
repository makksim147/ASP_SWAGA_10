using ASPNET_SWAGA.Common;
using ASPNET_SWAGA.Models;
using ASPNET_SWAGA.Models.CreateDTO;
using ASPNET_SWAGA.Models.DTO;
using ASPNET_SWAGA.Models.PatchDTO;
using ASPNET_SWAGA.Models.UpdateDTO;
using ASPNET_SWAGA.Repositories;
using AutoMapper;

namespace ASPNET_SWAGA.Services;

public class OrdersitemService
    : CrudService<Ordersitem, OrdersitemDTO, CreateOrdersitemDTO, UpdateOrdersitemDTO, PatchOrdersitemDTO>, IOrdersitemService
{
    private readonly IOrderRepository _orders;
    private readonly IProductRepository _products;

    public OrdersitemService(IOrdersitemRepository repository, IMapper mapper, IOrderRepository orders, IProductRepository products)
        : base(repository, mapper)
    {
        _orders = orders;
        _products = products;
    }

    protected override Task<ServiceResult> ValidateCreateAsync(CreateOrdersitemDTO dto, CancellationToken ct) =>
        CheckReferencesAsync(dto.IdOrders, dto.IdProducts, ct);

    protected override Task<ServiceResult> ValidateUpdateAsync(int id, UpdateOrdersitemDTO dto, CancellationToken ct) =>
        CheckReferencesAsync(dto.IdOrders, dto.IdProducts, ct);

    protected override Task<ServiceResult> ValidatePatchAsync(int id, PatchOrdersitemDTO dto, CancellationToken ct) =>
        CheckReferencesAsync(dto.IdOrders, dto.IdProducts, ct);

    private async Task<ServiceResult> CheckReferencesAsync(int? idOrders, int? idProducts, CancellationToken ct)
    {
        if (idOrders.HasValue && !await _orders.ExistsAsync(idOrders.Value, ct))
            return ServiceResult.Validation("Указанный id заказа не существует.");

        if (idProducts.HasValue && !await _products.ExistsAsync(idProducts.Value, ct))
            return ServiceResult.Validation("Указанный id товара не существует.");

        return ServiceResult.Ok();
    }
}
