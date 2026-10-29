namespace ASPNET_SWAGA.Models.DTO
{
    public class ProductDTO
    {
        public int ProductsId { get; set; }
        public InfoproductDTO Info { get; set; } = null!;
        public CategoryDTO Category { get; set; } = null!;
        public decimal Price { get; set; }
        public string? ImagePath { get; set; }
        public int StockCount { get; set; }
    }
}
