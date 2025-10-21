using System;
using System.Collections.Generic;

namespace HumDo.Domain.Entities;

public partial class user_flag
{
    public long id { get; set; }

    public Guid user_id { get; set; }

    public string? flag_type { get; set; }

    public string? flag_data { get; set; }

    public DateTimeOffset? created_at { get; set; }

    public virtual user user { get; set; } = null!;
}
