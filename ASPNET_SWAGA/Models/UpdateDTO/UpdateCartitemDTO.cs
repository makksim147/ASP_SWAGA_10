using System.ComponentModel.DataAnnotations;

namespace ASPNET_SWAGA.Models.UpdateDTO
{
    public class UpdateCartitemDTO
    {
        public int IdCart { get; set; }
        public int IdProducts { get; set; }
        [Range(1, int.MaxValue)]
        public int CountItems { get; set; }
    }
}
