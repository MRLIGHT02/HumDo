using System;
using System.Collections.Generic;

namespace HumDo.Domain.Entities;

public partial class block
{
    public Guid blocker_id { get; set; }

    public Guid blocked_id { get; set; }

    public string? reason { get; set; }

    public DateTimeOffset? blocked_at { get; set; }

    public virtual user blocked { get; set; } = null!;

    public virtual user blocker { get; set; } = null!;
}
