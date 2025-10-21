using System;
using System.Collections.Generic;

namespace HumDo.Domain.Entities;

public partial class third_party_integration
{
    public int integration_id { get; set; }

    public string? name { get; set; }

    public string? type { get; set; }

    public string? config { get; set; }

    public bool? enabled { get; set; }

    public DateTimeOffset? created_at { get; set; }

    public virtual ICollection<webhook_log> webhook_logs { get; set; } = new List<webhook_log>();
}
