using System;
using System.Collections.Generic;

namespace HumDo.Domain.Entities;

public partial class storage_provider
{
    public int provider_id { get; set; }

    public string? name { get; set; }

    public string? type { get; set; }

    public string? config { get; set; }

    public DateTimeOffset? created_at { get; set; }
}
