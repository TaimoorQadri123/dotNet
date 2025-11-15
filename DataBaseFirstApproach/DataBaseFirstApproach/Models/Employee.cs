using System;
using System.Collections.Generic;

namespace DataBaseFirstApproach.Models;

public partial class Employee
{
    public int EmpId { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Designation { get; set; }

    public decimal? Salary { get; set; }

    public string? City { get; set; }
}
