using System;
using System.Collections.Generic;

namespace hotel.Models;

public partial class Roomsview
{
    public string? RoomsType { get; set; }

    public decimal? Available { get; set; }

    public decimal? Booked { get; set; }

    public decimal? CheckIn { get; set; }

    public decimal? CheckOut { get; set; }

    public decimal? RoomService { get; set; }

    public long Total { get; set; }
}
