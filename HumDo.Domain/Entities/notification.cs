using System;
using System.Collections.Generic;

namespace HumDo.Domain.Entities;

public partial class notification
{
    public Guid notification_id { get; set; }

    public Guid user_id { get; set; }

    public string? type { get; set; }

    public string? title { get; set; }

    public string? body { get; set; }

    public string? payload { get; set; }

    public bool? is_read { get; set; }

    public DateTimeOffset? created_at { get; set; }

    public virtual user user { get; set; } = null!;
}
