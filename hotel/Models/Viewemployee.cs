using System;
using System.Collections.Generic;

namespace hotel.Models;

public partial class Viewemployee
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Username { get; set; }

    public string? Email { get; set; }

    public string? Mobile { get; set; }

    public decimal? Salary { get; set; }

    public string? Role { get; set; }

    public string? Status { get; set; }
}
