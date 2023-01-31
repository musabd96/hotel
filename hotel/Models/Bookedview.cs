using System;
using System.Collections.Generic;

namespace hotel.Models;

public partial class Bookedview
{
    public string BookId { get; set; } = null!;

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public int? RoomNr { get; set; }

    public string? Type { get; set; }

    public string? Price { get; set; }

    public string? CheckIn { get; set; }

    public string? CheckOut { get; set; }

    public string? Days { get; set; }

    public string? Status { get; set; }
}
