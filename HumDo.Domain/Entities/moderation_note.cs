using System;
using System.Collections.Generic;

namespace HumDo.Domain.Entities;

public partial class moderation_note
{
    public long note_id { get; set; }

    public Guid user_id { get; set; }

    public Guid? admin_id { get; set; }

    public string? note { get; set; }

    public DateTimeOffset? created_at { get; set; }

    public virtual user user { get; set; } = null!;
}
