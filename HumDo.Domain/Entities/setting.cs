using System;
using System.Collections.Generic;

namespace HumDo.Domain.Entities;

public partial class setting
{
    public string setting_key { get; set; } = null!;

    public string? value { get; set; }

    public string? description { get; set; }

    public DateTimeOffset? updated_at { get; set; }
}
