using ASPNET_SWAGA.Models.CreateDTO;
using ASPNET_SWAGA.Models.DTO;
using ASPNET_SWAGA.Models.PatchDTO;
using ASPNET_SWAGA.Models.UpdateDTO;
using ASPNET_SWAGA.Services;

namespace ASPNET_SWAGA.Controllers;

public class ProductController : CrudControllerBase<ProductDTO, CreateProductDTO, UpdateProductDTO, PatchProductDTO>
{
    public ProductController(IProductService service) : base(service)
    {
    }

    protected override int GetId(ProductDTO dto) => dto.ProductsId;
}
