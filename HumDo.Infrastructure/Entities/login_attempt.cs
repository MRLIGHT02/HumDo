using System;
using System.Collections.Generic;

namespace HumDo.Infrastructure.Entities;

public partial class login_attempt
{
    public long attempt_id { get; set; }

    public Guid? user_id { get; set; }

    public DateTimeOffset? attempted_at { get; set; }

    public string? ip_address { get; set; }

    public string? user_agent { get; set; }

    public bool? was_successful { get; set; }

    public string? failure_reason { get; set; }

    public virtual user? user { get; set; }
}
