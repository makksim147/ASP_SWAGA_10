namespace ASPNET_SWAGA.Models.DTO
{
    public class ReservationDTO
    {
        public int ReservationsId { get; set; }
        public UserDTO User { get; set; } = null!;
        public ProductDTO Product { get; set; } = null!;
        public int CountItems { get; set; }
        public DateTime ReservedAt { get; set; }
        public DateTime? ReleasedAt { get; set; }
        public bool IsActive { get; set; }
    }
}
