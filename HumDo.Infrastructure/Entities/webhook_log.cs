using System;
using System.Collections.Generic;

namespace HumDo.Infrastructure.Entities;

public partial class webhook_log
{
    public long webhook_id { get; set; }

    public int? integration_id { get; set; }

    public string? payload { get; set; }

    public int? status_code { get; set; }

    public DateTimeOffset? delivered_at { get; set; }

    public virtual third_party_integration? integration { get; set; }
}
