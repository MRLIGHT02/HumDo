using System;
using System.Collections.Generic;

namespace HumDo.Domain.Entities;

public partial class user_social_link
{
    public long id { get; set; }

    public Guid user_id { get; set; }

    public string? provider { get; set; }

    public string? external_user_id { get; set; }

    public string? url { get; set; }

    public DateTimeOffset? created_at { get; set; }

    public virtual user user { get; set; } = null!;
}
