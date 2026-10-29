using ASPNET_SWAGA.Models;
using ASPNET_SWAGA.Models.CreateDTO;
using ASPNET_SWAGA.Models.DTO;
using ASPNET_SWAGA.Models.PatchDTO;
using ASPNET_SWAGA.Models.UpdateDTO;
using ASPNET_SWAGA.Repositories;
using AutoMapper;

namespace ASPNET_SWAGA.Services;

public class CategoryService
    : CrudService<Category, CategoryDTO, CreateCategoryDTO, UpdateCategoryDTO, PatchCategoryDTO>, ICategoryService
{
    public CategoryService(ICategoryRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }
}
