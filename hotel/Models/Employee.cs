using System;
using System.Collections.Generic;

namespace hotel.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string? EmployeeFirstname { get; set; }

    public string? EmployeeLastname { get; set; }

    public string? EmployeeEmail { get; set; }

    public decimal? EmployeeSalary { get; set; }

    public string? EmployeeMobile { get; set; }

    public string? EmployeeStatus { get; set; }

    public int? RoleRoleId { get; set; }

    public virtual ICollection<Booking> Bookings { get; } = new List<Booking>();

    public virtual Role? RoleRole { get; set; }

    public virtual ICollection<Use> Uses { get; } = new List<Use>();
}
