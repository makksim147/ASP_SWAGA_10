using System.ComponentModel.DataAnnotations;

namespace ASPNET_SWAGA.Models.CreateDTO
{
    public class CreateRoleDTO
    {
        [StringLength(40, MinimumLength = 1)]
        public string Roles { get; set; } = null!;
    }
}
