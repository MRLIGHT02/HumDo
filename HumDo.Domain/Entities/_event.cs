using System;
using System.Collections.Generic;

namespace HumDo.Domain.Entities;

public partial class _event
{
    public Guid event_id { get; set; }

    public Guid? user_id { get; set; }

    public string? event_type { get; set; }

    public string? payload { get; set; }

    public DateTimeOffset? created_at { get; set; }
}
