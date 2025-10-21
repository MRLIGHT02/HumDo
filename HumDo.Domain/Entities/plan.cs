using System;
using System.Collections.Generic;

namespace HumDo.Domain.Entities;

public partial class plan
{
    public int plan_id { get; set; }

    public string plan_key { get; set; } = null!;

    public string? display_name { get; set; }

    public long? price_cents { get; set; }

    public string? currency { get; set; }

    public string? features { get; set; }

    public DateTimeOffset? created_at { get; set; }

    public virtual ICollection<subscription> subscriptions { get; set; } = new List<subscription>();
}
