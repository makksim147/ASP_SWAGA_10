namespace ASPNET_SWAGA.Models.DTO
{
    public class CartitemDTO
    {
        public int CartItemsId { get; set; }
        public int IdCart { get; set; }
        public ProductDTO Product { get; set; } = null!;
        public int CountItems { get; set; }
    }
}
