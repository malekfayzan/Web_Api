using System;
using System.Collections.Generic;

namespace Udemy_Demo_1.Models;

public partial class UsersDetail
{
    public int UserId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateTime RegisterDate { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public string? Email { get; set; }

    public int DepartmentId { get; set; }

    public decimal Salary { get; set; }

    public int UserProofId { get; set; }

    public string UserProofStatus { get; set; } = null!;

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Department Department { get; set; } = null!;

    public virtual UsersProof UserProof { get; set; } = null!;
}
