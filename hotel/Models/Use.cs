using System;
using System.Collections.Generic;

namespace hotel.Models;

public partial class Use
{
    public int UsesId { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public int EmployeeEmployeeId { get; set; }

    public virtual Employee EmployeeEmployee { get; set; } = null!;
}
