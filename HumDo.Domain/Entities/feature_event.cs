using System;
using System.Collections.Generic;

namespace HumDo.Domain.Entities;

public partial class feature_event
{
    public long event_id { get; set; }

    public Guid user_id { get; set; }

    public string? feature_key { get; set; }

    public string? context { get; set; }

    public DateTimeOffset? occurred_at { get; set; }

    public virtual user user { get; set; } = null!;
}
