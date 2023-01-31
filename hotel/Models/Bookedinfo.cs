using System;
using System.Collections.Generic;

namespace hotel.Models;

public partial class Bookedinfo
{
    public string BookingId { get; set; } = null!;

    public int? RoomsRoomsNr { get; set; }

    public string? BookingCheckin { get; set; }

    public string? BookingCheckout { get; set; }

    public string? BookingDays { get; set; }

    public string? BookingPrice { get; set; }

    public int? GuestsGuestsId { get; set; }

    public int? EmployeeEmployeeId { get; set; }

    public int GuestsId { get; set; }

    public string? GuestsFirstname { get; set; }

    public string? GuestsLastname { get; set; }

    public string? GuestsEmail { get; set; }

    public string? GuestsMobile { get; set; }

    public int RoomsNr { get; set; }

    public string? RoomsType { get; set; }

    public int? RoomsCapacity { get; set; }

    public decimal? RoomsPrice { get; set; }

    public string? RoomsStatus { get; set; }
}
