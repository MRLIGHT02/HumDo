using System;
using System.Collections.Generic;

namespace HumDo.Domain.Entities;

public partial class conversation_participant
{
    public Guid conversation_id { get; set; }

    public Guid user_id { get; set; }

    public DateTimeOffset? joined_at { get; set; }

    public DateTimeOffset? left_at { get; set; }

    public bool? is_muted { get; set; }

    public virtual conversation conversation { get; set; } = null!;

    public virtual user user { get; set; } = null!;
}
