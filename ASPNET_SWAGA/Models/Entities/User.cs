using System;
using System.Collections.Generic;

namespace ASPNET_SWAGA.Models;

public partial class User
{
    public int UsersId { get; set; }

    public string LoginUser { get; set; } = null!;

    public string PasswordUser { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int? IdRoles { get; set; }

    public virtual Cart? Cart { get; set; }

    public virtual Role? IdRolesNavigation { get; set; }

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
