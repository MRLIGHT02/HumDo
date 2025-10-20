using System;
using System.Collections.Generic;

namespace HumDo.Infrastructure.Entities;

public partial class user_interest
{
    public Guid user_id { get; set; }

    public int interest_id { get; set; }

    public DateTimeOffset? added_at { get; set; }

    public virtual interest interest { get; set; } = null!;

    public virtual user user { get; set; } = null!;
}
