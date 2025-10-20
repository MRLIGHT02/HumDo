using System;
using System.Collections.Generic;

namespace HumDo.Infrastructure.Entities;

public partial class push_token
{
    public Guid token_id { get; set; }

    public Guid user_id { get; set; }

    public string? platform { get; set; }

    public string? token { get; set; }

    public string? device_model { get; set; }

    public DateTimeOffset? last_seen_at { get; set; }

    public virtual user user { get; set; } = null!;
}
