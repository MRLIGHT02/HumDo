using System;
using System.Collections.Generic;

namespace HumDo.Infrastructure.Entities;

public partial class swipe_event
{
    public long event_id { get; set; }

    public Guid swipe_id { get; set; }

    public DateTimeOffset? event_time { get; set; }

    public string? event_type { get; set; }

    public string? payload { get; set; }

    public virtual swipe swipe { get; set; } = null!;
}
