using System.ComponentModel.DataAnnotations;

namespace ASPNET_SWAGA.Models.CreateDTO
{
    public class CreateCartitemDTO
    {
        public int IdCart { get; set; }
        public int IdProducts { get; set; }
        [Range(1, int.MaxValue)]
        public int CountItems { get; set; }
    }
}
