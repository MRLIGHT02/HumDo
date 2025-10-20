using System;
using System.Collections.Generic;

namespace HumDo.Infrastructure.Entities;

public partial class email_log
{
    public long email_id { get; set; }

    public Guid? user_id { get; set; }

    public string? to_address { get; set; }

    public string? subject { get; set; }

    public string? body_snippet { get; set; }

    public DateTimeOffset? sent_at { get; set; }

    public string? provider_response { get; set; }

    public virtual user? user { get; set; }
}
