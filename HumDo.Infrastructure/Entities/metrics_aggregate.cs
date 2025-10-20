using System;
using System.Collections.Generic;

namespace HumDo.Infrastructure.Entities;

public partial class metrics_aggregate
{
    public long id { get; set; }

    public string? metric_name { get; set; }

    public DateOnly? metric_date { get; set; }

    public double? value { get; set; }

    public string? metadata { get; set; }
}
