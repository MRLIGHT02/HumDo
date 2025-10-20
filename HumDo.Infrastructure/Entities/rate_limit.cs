using System;
using System.Collections.Generic;

namespace HumDo.Infrastructure.Entities;

public partial class rate_limit
{
    public long id { get; set; }

    public Guid? user_id { get; set; }

    public string? key { get; set; }

    public int? limit_count { get; set; }

    public int? window_seconds { get; set; }

    public DateTimeOffset? created_at { get; set; }

    public virtual user? user { get; set; }
}
