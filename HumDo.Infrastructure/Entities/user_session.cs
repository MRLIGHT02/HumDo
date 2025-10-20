using System;
using System.Collections.Generic;

namespace HumDo.Infrastructure.Entities;

public partial class user_session
{
    public Guid session_id { get; set; }

    public Guid user_id { get; set; }

    public string? device_info { get; set; }

    public string? ip_address { get; set; }

    public DateTimeOffset? created_at { get; set; }

    public DateTimeOffset? expires_at { get; set; }

    public DateTimeOffset? revoked_at { get; set; }

    public bool? is_revoked { get; set; }

    public virtual user user { get; set; } = null!;
}
