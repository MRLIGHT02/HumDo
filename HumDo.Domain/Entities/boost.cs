using System;
using System.Collections.Generic;

namespace HumDo.Domain.Entities;

public partial class boost
{
    public Guid boost_id { get; set; }

    public Guid user_id { get; set; }

    public DateTimeOffset? started_at { get; set; }

    public DateTimeOffset? expires_at { get; set; }

    public string? boost_type { get; set; }

    public string? metadata { get; set; }

    public virtual user user { get; set; } = null!;
}
