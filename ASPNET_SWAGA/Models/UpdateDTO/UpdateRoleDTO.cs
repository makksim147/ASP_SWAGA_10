using System.ComponentModel.DataAnnotations;

namespace ASPNET_SWAGA.Models.UpdateDTO
{
    public class UpdateRoleDTO
    {
        [StringLength(40, MinimumLength = 1)]
        public string Roles { get; set; } = null!;
    }
}
