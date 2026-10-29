namespace ASPNET_SWAGA.Models.DTO
{
    public class OrdersitemDTO
    {
        public int OrderItemsId { get; set; }
        public int IdOrders { get; set; }
        public ProductDTO Product { get; set; } = null!;
        public int CountItem { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
