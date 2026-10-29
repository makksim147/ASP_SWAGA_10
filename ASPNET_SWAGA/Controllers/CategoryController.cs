using ASPNET_SWAGA.Models.CreateDTO;
using ASPNET_SWAGA.Models.DTO;
using ASPNET_SWAGA.Models.PatchDTO;
using ASPNET_SWAGA.Models.UpdateDTO;
using ASPNET_SWAGA.Services;

namespace ASPNET_SWAGA.Controllers;

public class CategoryController : CrudControllerBase<CategoryDTO, CreateCategoryDTO, UpdateCategoryDTO, PatchCategoryDTO>
{
    public CategoryController(ICategoryService service) : base(service)
    {
    }

    protected override int GetId(CategoryDTO dto) => dto.CategoriesId;
}
