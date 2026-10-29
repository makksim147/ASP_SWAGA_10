using System.ComponentModel.DataAnnotations;

namespace ASPNET_SWAGA.Models.UpdateDTO
{
    public class UpdateCategoryDTO
    {
        [StringLength(40, MinimumLength = 1)]
        public string CategoriesItems { get; set; } = null!;
    }
}
