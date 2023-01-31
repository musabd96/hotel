using System;
using System.Collections.Generic;

namespace hotel.Models;

public partial class Booking
{
    public string BookingId { get; set; } = null!;

    public int? RoomsRoomsNr { get; set; }

    public string? BookingCheckin { get; set; }

    public string? BookingCheckout { get; set; }

    public string? BookingDays { get; set; }

    public string? BookingPrice { get; set; }

    public int? GuestsGuestsId { get; set; }

    public int? EmployeeEmployeeId { get; set; }

    public virtual Employee? EmployeeEmployee { get; set; }

    public virtual Guest? GuestsGuests { get; set; }

    public virtual Room? RoomsRoomsNrNavigation { get; set; }
}
