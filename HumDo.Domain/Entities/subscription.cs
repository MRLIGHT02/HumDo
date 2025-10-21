using System;
using System.Collections.Generic;

namespace HumDo.Domain.Entities;

public partial class subscription
{
    public Guid subscription_id { get; set; }

    public Guid user_id { get; set; }

    public int plan_id { get; set; }

    public DateTimeOffset? started_at { get; set; }

    public DateTimeOffset? expires_at { get; set; }

    public bool? is_active { get; set; }

    public bool? auto_renew { get; set; }

    public string? provider_subscription_id { get; set; }

    public virtual plan plan { get; set; } = null!;

    public virtual user user { get; set; } = null!;
}
