namespace ASPNET_SWAGA.Models.DTO
{
    public class CartDTO
    {
        public int CartsId { get; set; }
        public UserDTO? User { get; set; }
        public List<CartitemDTO> Items { get; set; } = new();
    }
}
