using System;
using System.Collections.Generic;

namespace Udemy_Demo_1.Models;

public partial class Department
{
    public int DepartmentId { get; set; }

    public string DepartmentName { get; set; } = null!;

    public virtual ICollection<UsersDetail> UsersDetails { get; } = new List<UsersDetail>();
}
