using System;
using System.Collections.Generic;

namespace HumDo.Domain.Entities;

public partial class message_reaction
{
    public Guid message_id { get; set; }

    public Guid reactor_id { get; set; }

    public string reaction { get; set; } = null!;

    public DateTimeOffset? reacted_at { get; set; }

    public virtual message message { get; set; } = null!;

    public virtual user reactor { get; set; } = null!;
}
