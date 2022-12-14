using System;
using System.Collections.Generic;

namespace Udemy_Demo_1.Models;

public partial class UsersProof
{
    public int UserProofId { get; set; }

    public string ProofName { get; set; } = null!;

    public virtual ICollection<UsersDetail> UsersDetails { get; } = new List<UsersDetail>();
}
