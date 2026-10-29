namespace ASPNET_SWAGA.Models.DTO
{
    public class UserDTO
    {
        public int UsersId { get; set; }
        public string LoginUser { get; set; } = null!;
        public string Email { get; set; } = null!;
        public RoleDTO? Role { get; set; }
    }
}
