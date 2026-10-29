using System.ComponentModel.DataAnnotations;

namespace ASPNET_SWAGA.Models.PatchDTO
{
    public class PatchProductDTO
    {
        public int? IdInfoProducts { get; set; }
        public int? IdCategories { get; set; }
        [Range(0, 99999999.99)]
        public decimal? Price { get; set; }
        public string? ImagePath { get; set; }
        [Range(0, int.MaxValue)]
        public int? StockCount { get; set; }
    }
}
