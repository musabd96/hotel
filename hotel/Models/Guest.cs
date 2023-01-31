using System;
using System.Collections.Generic;

namespace hotel.Models;

public partial class Guest
{
    public int GuestsId { get; set; }

    public string? GuestsFirstname { get; set; }

    public string? GuestsLastname { get; set; }

    public string? GuestsEmail { get; set; }

    public string? GuestsMobile { get; set; }

    public virtual ICollection<Booking> Bookings { get; } = new List<Booking>();
}
