using System;
using System.Collections.Generic;

namespace HumDo.Infrastructure.Entities;

public partial class message_attachment
{
    public Guid attachment_id { get; set; }

    public Guid message_id { get; set; }

    public Guid media_id { get; set; }

    public string? attachment_type { get; set; }

    public DateTimeOffset? created_at { get; set; }

    public virtual media_file media { get; set; } = null!;

    public virtual message message { get; set; } = null!;
}
