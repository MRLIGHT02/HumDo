using System;
using System.Collections.Generic;

namespace HumDo.Infrastructure.Entities;

public partial class daily_user_metric
{
    public long id { get; set; }

    public Guid user_id { get; set; }

    public DateOnly? metric_date { get; set; }

    public int? swipes_sent { get; set; }

    public int? swipes_received { get; set; }

    public int? matches_created { get; set; }

    public int? messages_sent { get; set; }

    public int? logins { get; set; }

    public virtual user user { get; set; } = null!;
}
