using System.ComponentModel.DataAnnotations;

namespace ASPNET_SWAGA.Models.UpdateDTO
{
    public class UpdateOrderDTO
    {
        public int IdCart { get; set; }
        public DateOnly? DateOrder { get; set; }
        [Range(0, 99999999.99)]
        public decimal TotalPrice { get; set; }
    }
}
