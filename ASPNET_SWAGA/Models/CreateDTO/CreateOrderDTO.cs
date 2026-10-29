using System.ComponentModel.DataAnnotations;

namespace ASPNET_SWAGA.Models.CreateDTO
{
    public class CreateOrderDTO
    {
        public int IdCart { get; set; }
        public DateOnly? DateOrder { get; set; }
        [Range(0, 99999999.99)]
        public decimal TotalPrice { get; set; }
    }
}
