namespace ASPNET_SWAGA.Models.DTO
{
    public class OrderDTO
    {
        public int OrdersId { get; set; }
        public int IdCart { get; set; }
        public DateOnly? DateOrder { get; set; }
        public decimal TotalPrice { get; set; }
        public List<OrdersitemDTO> Items { get; set; } = new();
    }
}
