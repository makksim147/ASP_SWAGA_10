using ASPNET_SWAGA.Common;
using ASPNET_SWAGA.Models;
using ASPNET_SWAGA.Models.CreateDTO;
using ASPNET_SWAGA.Models.DTO;
using ASPNET_SWAGA.Models.PatchDTO;
using ASPNET_SWAGA.Models.UpdateDTO;
using ASPNET_SWAGA.Repositories;
using AutoMapper;

namespace ASPNET_SWAGA.Services;

public class CartitemService
    : CrudService<Cartitem, CartitemDTO, CreateCartitemDTO, UpdateCartitemDTO, PatchCartitemDTO>, ICartitemService
{
    private readonly ICartRepository _carts;
    private readonly IProductRepository _products;

    public CartitemService(ICartitemRepository repository, IMapper mapper, ICartRepository carts, IProductRepository products)
        : base(repository, mapper)
    {
        _carts = carts;
        _products = products;
    }

    protected override Task<ServiceResult> ValidateCreateAsync(CreateCartitemDTO dto, CancellationToken ct) =>
        CheckReferencesAsync(dto.IdCart, dto.IdProducts, ct);

    protected override Task<ServiceResult> ValidateUpdateAsync(int id, UpdateCartitemDTO dto, CancellationToken ct) =>
        CheckReferencesAsync(dto.IdCart, dto.IdProducts, ct);

    protected override Task<ServiceResult> ValidatePatchAsync(int id, PatchCartitemDTO dto, CancellationToken ct) =>
        CheckReferencesAsync(dto.IdCart, dto.IdProducts, ct);

    private async Task<ServiceResult> CheckReferencesAsync(int? idCart, int? idProducts, CancellationToken ct)
    {
        if (idCart.HasValue && !await _carts.ExistsAsync(idCart.Value, ct))
            return ServiceResult.Validation("Указанный id корзины не существует.");

        if (idProducts.HasValue && !await _products.ExistsAsync(idProducts.Value, ct))
            return ServiceResult.Validation("Указанный id товара не существует.");

        return ServiceResult.Ok();
    }
}
