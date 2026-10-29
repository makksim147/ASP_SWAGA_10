using System.ComponentModel.DataAnnotations;

namespace ASPNET_SWAGA.Models.CreateDTO
{
    public class CreateUserDTO
    {
        [StringLength(40, MinimumLength = 1)]
        public string LoginUser { get; set; } = null!;
        [StringLength(255, MinimumLength = 1)]
        public string PasswordUser { get; set; } = null!;
        [EmailAddress, StringLength(255)]
        public string Email { get; set; } = null!;
        public int? IdRoles { get; set; }
    }
}
