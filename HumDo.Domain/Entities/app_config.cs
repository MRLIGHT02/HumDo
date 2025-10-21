using System;
using System.Collections.Generic;

namespace HumDo.Domain.Entities;

public partial class app_config
{
    public int config_id { get; set; }

    public string? env { get; set; }

    public string? key { get; set; }

    public string? value { get; set; }

    public DateTimeOffset? created_at { get; set; }
}
