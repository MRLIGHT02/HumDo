using System;
using System.Collections.Generic;

namespace HumDo.Infrastructure.Entities;

public partial class admin_action
{
    public long action_id { get; set; }

    public Guid? admin_user_id { get; set; }

    public string? action_type { get; set; }

    public Guid? target_user_id { get; set; }

    public string? details { get; set; }

    public DateTimeOffset? performed_at { get; set; }

    public virtual user? target_user { get; set; }
}
