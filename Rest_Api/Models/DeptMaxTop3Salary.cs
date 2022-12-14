using System;
using System.Collections.Generic;

namespace Udemy_Demo_1.Models;

public partial class DeptMaxTop3Salary
{
    public decimal Salary { get; set; }

    public int DepartmentId { get; set; }

    public string DepartmentName { get; set; } = null!;
}
