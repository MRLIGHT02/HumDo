using System;
using System.Collections.Generic;

namespace HumDo.Infrastructure.Entities;

public partial class user_verification
{
    public Guid verification_id { get; set; }

    public Guid user_id { get; set; }

    public string? method { get; set; }

    public string? status { get; set; }

    public string? payload { get; set; }

    public DateTimeOffset? requested_at { get; set; }

    public DateTimeOffset? verified_at { get; set; }

    public virtual user user { get; set; } = null!;
}
