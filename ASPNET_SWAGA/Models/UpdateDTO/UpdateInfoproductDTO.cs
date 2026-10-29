using System.ComponentModel.DataAnnotations;

namespace ASPNET_SWAGA.Models.UpdateDTO
{
    public class UpdateInfoproductDTO
    {
        [StringLength(100, MinimumLength = 1)]
        public string NameProduct { get; set; } = null!;
        [StringLength(500)]
        public string? DescriptionProduct { get; set; }
    }
}
