using System;
using System.Collections.Generic;

namespace HumDo.Infrastructure.Entities;

public partial class device_fingerprint
{
    public Guid fingerprint_id { get; set; }

    public Guid user_id { get; set; }

    public string? fingerprint_hash { get; set; }

    public DateTimeOffset? first_seen_at { get; set; }

    public DateTimeOffset? last_seen_at { get; set; }

    public virtual user user { get; set; } = null!;
}
