using System.ComponentModel.DataAnnotations;

namespace ASPNET_SWAGA.Models.PatchDTO
{
    public class PatchInfoproductDTO
    {
        [StringLength(100, MinimumLength = 1)]
        public string? NameProduct { get; set; }
        [StringLength(500)]
        public string? DescriptionProduct { get; set; }
    }
}
