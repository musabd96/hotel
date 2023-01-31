using System;
using System.Collections.Generic;

namespace hotel.Models;

public partial class Room
{
    public int RoomsNr { get; set; }

    public string? RoomsType { get; set; }

    public int? RoomsCapacity { get; set; }

    public decimal? RoomsPrice { get; set; }

    public string? RoomsStatus { get; set; }

    public virtual ICollection<Booking> Bookings { get; } = new List<Booking>();
}
