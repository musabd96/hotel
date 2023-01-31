using System;
using System.Collections.Generic;

namespace hotel.Models;

public partial class Dashboardview
{
    public int RoomNr { get; set; }

    public string? Type { get; set; }

    public string? CheckIn { get; set; }

    public string? CheckOut { get; set; }

    public string? Days { get; set; }

    public string? Status { get; set; }
}
