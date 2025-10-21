using System;
using System.Collections.Generic;

namespace HumDo.Domain.Entities;

public partial class discount_code
{
    public string code { get; set; } = null!;

    public string? description { get; set; }

    public short? percent_off { get; set; }

    public int? max_uses { get; set; }

    public DateTimeOffset? expires_at { get; set; }

    public DateTimeOffset? created_at { get; set; }
}
