using ASPNET_SWAGA.Common;
using ASPNET_SWAGA.Models;
using ASPNET_SWAGA.Models.CreateDTO;
using ASPNET_SWAGA.Models.DTO;
using ASPNET_SWAGA.Models.PatchDTO;
using ASPNET_SWAGA.Models.UpdateDTO;
using ASPNET_SWAGA.Repositories;
using AutoMapper;

namespace ASPNET_SWAGA.Services;

public class ProductService
    : CrudService<Product, ProductDTO, CreateProductDTO, UpdateProductDTO, PatchProductDTO>, IProductService
{
    private readonly IInfoproductRepository _infoproducts;
    private readonly ICategoryRepository _categories;

    public ProductService(IProductRepository repository, IMapper mapper, IInfoproductRepository infoproducts, ICategoryRepository categories)
        : base(repository, mapper)
    {
        _infoproducts = infoproducts;
        _categories = categories;
    }

    protected override Task<ServiceResult> ValidateCreateAsync(CreateProductDTO dto, CancellationToken ct) =>
        CheckReferencesAsync(dto.IdInfoProducts, dto.IdCategories, ct);

    protected override Task<ServiceResult> ValidateUpdateAsync(int id, UpdateProductDTO dto, CancellationToken ct) =>
        CheckReferencesAsync(dto.IdInfoProducts, dto.IdCategories, ct);

    protected override Task<ServiceResult> ValidatePatchAsync(int id, PatchProductDTO dto, CancellationToken ct) =>
        CheckReferencesAsync(dto.IdInfoProducts, dto.IdCategories, ct);

    private async Task<ServiceResult> CheckReferencesAsync(int? idInfoProducts, int? idCategories, CancellationToken ct)
    {
        if (idInfoProducts.HasValue && !await _infoproducts.ExistsAsync(idInfoProducts.Value, ct))
            return ServiceResult.Validation("Указанный id информации о продукте не существует.");

        if (idCategories.HasValue && !await _categories.ExistsAsync(idCategories.Value, ct))
            return ServiceResult.Validation("Указанный id категории не существует.");

        return ServiceResult.Ok();
    }
}
