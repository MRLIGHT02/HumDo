using System;
using System.Collections.Generic;

namespace HumDo.Domain.Entities;

public partial class interest
{
    public int interest_id { get; set; }

    public string name { get; set; } = null!;

    public string? category { get; set; }

    public DateTimeOffset? created_at { get; set; }

    public virtual ICollection<user_interest> user_interests { get; set; } = new List<user_interest>();
}
