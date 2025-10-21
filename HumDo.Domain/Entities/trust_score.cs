using System;
using System.Collections.Generic;

namespace HumDo.Domain.Entities;

public partial class trust_score
{
    public Guid user_id { get; set; }

    public double? score { get; set; }

    public DateTimeOffset? last_computed_at { get; set; }

    public string? factors { get; set; }

    public virtual user user { get; set; } = null!;
}
