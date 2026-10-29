using System.ComponentModel.DataAnnotations;

namespace ASPNET_SWAGA.Models.PatchDTO
{
    public class PatchUserDTO
    {
        [StringLength(40, MinimumLength = 1)]
        public string? LoginUser { get; set; }
        [StringLength(255, MinimumLength = 1)]
        public string? PasswordUser { get; set; }
        [EmailAddress, StringLength(255)]
        public string? Email { get; set; }
        public int? IdRoles { get; set; }
    }
}
