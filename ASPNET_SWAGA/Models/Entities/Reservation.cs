namespace ASPNET_SWAGA.Models;

/// <summary>Факт бизнес-операции «резервирование товара»: кто (пользователь), что (товар), сколько и когда.</summary>
public partial class Reservation
{
    public int ReservationsId { get; set; }

    public int IdUser { get; set; }

    public int IdProducts { get; set; }

    public int CountItems { get; set; }

    public DateTime ReservedAt { get; set; }

    /// <summary>null = резервация активна; значение = когда отменена.</summary>
    public DateTime? ReleasedAt { get; set; }

    public virtual User IdUserNavigation { get; set; } = null!;

    public virtual Product IdProductsNavigation { get; set; } = null!;
}
