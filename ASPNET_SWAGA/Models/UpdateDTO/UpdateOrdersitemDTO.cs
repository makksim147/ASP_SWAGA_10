using System.ComponentModel.DataAnnotations;

namespace ASPNET_SWAGA.Models.UpdateDTO
{
    public class UpdateOrdersitemDTO
    {
        public int IdOrders { get; set; }
        public int IdProducts { get; set; }
        [Range(1, int.MaxValue)]
        public int CountItem { get; set; }
        [Range(0, 99999999.99)]
        public decimal TotalPrice { get; set; }
    }
}
