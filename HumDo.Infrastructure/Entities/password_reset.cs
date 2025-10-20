using System;
using System.Collections.Generic;

namespace HumDo.Infrastructure.Entities;

public partial class password_reset
{
    public Guid reset_id { get; set; }

    public Guid user_id { get; set; }

    public string? reset_token { get; set; }

    public DateTimeOffset? requested_at { get; set; }

    public DateTimeOffset? used_at { get; set; }

    public DateTimeOffset? expires_at { get; set; }

    public virtual user user { get; set; } = null!;
}
