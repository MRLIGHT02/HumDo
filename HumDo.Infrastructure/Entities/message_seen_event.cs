using System;
using System.Collections.Generic;

namespace HumDo.Infrastructure.Entities;

public partial class message_seen_event
{
    public long id { get; set; }

    public Guid message_id { get; set; }

    public Guid user_id { get; set; }

    public DateTimeOffset? seen_at { get; set; }

    public virtual message message { get; set; } = null!;

    public virtual user user { get; set; } = null!;
}
