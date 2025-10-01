using System;
using System.Collections.Generic;

namespace ERPAPI.Models;

public partial class Employee
{
    public int Empid { get; set; }

    public string? Empname { get; set; }

    public string? Empposition { get; set; }

    public int? Empsalary { get; set; }

    public string? Empmobile { get; set; }
}
