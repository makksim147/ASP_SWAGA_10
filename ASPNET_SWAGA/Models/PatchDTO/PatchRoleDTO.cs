using System.ComponentModel.DataAnnotations;

namespace ASPNET_SWAGA.Models.PatchDTO
{
    public class PatchRoleDTO
    {
        [StringLength(40, MinimumLength = 1)]
        public string? Roles { get; set; }
    }
}
