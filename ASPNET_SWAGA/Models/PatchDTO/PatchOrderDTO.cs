using System.ComponentModel.DataAnnotations;

namespace ASPNET_SWAGA.Models.PatchDTO
{
    public class PatchOrderDTO
    {
        public int? IdCart { get; set; }
        public DateOnly? DateOrder { get; set; }
        [Range(0, 99999999.99)]
        public decimal? TotalPrice { get; set; }
    }
}
