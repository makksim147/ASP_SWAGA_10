using System;
using System.Collections.Generic;

namespace ASPNET_SWAGA.Models;

public partial class Role
{
    public int RolesId { get; set; }

    public string Roles { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
