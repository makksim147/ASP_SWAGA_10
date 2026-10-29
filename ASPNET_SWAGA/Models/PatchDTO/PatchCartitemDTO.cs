using System.ComponentModel.DataAnnotations;

namespace ASPNET_SWAGA.Models.PatchDTO
{
    public class PatchCartitemDTO
    {
        public int? IdCart { get; set; }
        public int? IdProducts { get; set; }
        [Range(1, int.MaxValue)]
        public int? CountItems { get; set; }
    }
}
