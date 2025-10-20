using System;
using System.Collections.Generic;

namespace HumDo.Infrastructure.Entities;

public partial class ip_reputation
{
    public string ip_address { get; set; } = null!;

    public double? score { get; set; }

    public DateTimeOffset? last_checked_at { get; set; }
}
