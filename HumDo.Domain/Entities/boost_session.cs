using System;
using System.Collections.Generic;

namespace HumDo.Domain.Entities;

public partial class boost_session
{
    public long id { get; set; }

    public Guid user_id { get; set; }

    public DateTimeOffset? activated_at { get; set; }

    public int? duration_seconds { get; set; }

    public bool? consumed { get; set; }

    public string? source { get; set; }

    public virtual user user { get; set; } = null!;
}
