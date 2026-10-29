using System.ComponentModel.DataAnnotations;

namespace ASPNET_SWAGA.Models.CreateDTO
{
    public class CreateCategoryDTO
    {
        [StringLength(40, MinimumLength = 1)]
        public string CategoriesItems { get; set; } = null!;
    }
}
