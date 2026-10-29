using System.ComponentModel.DataAnnotations;

namespace ASPNET_SWAGA.Models.CreateDTO
{
    public class CreateInfoproductDTO
    {
        [StringLength(100, MinimumLength = 1)]
        public string NameProduct { get; set; } = null!;
        [StringLength(500)]
        public string? DescriptionProduct { get; set; }
    }
}
