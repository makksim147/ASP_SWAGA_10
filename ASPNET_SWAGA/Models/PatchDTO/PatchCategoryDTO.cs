using System.ComponentModel.DataAnnotations;

namespace ASPNET_SWAGA.Models.PatchDTO
{
    public class PatchCategoryDTO
    {
        [StringLength(40, MinimumLength = 1)]
        public string? CategoriesItems { get; set; }
    }
}
