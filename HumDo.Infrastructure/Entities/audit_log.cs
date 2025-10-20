using System;
using System.Collections.Generic;

namespace HumDo.Infrastructure.Entities;

public partial class audit_log
{
    public long audit_id { get; set; }

    public string? entity_table { get; set; }

    public Guid? entity_id { get; set; }

    public string? action { get; set; }

    public string? performed_by { get; set; }

    public string? details { get; set; }

    public DateTimeOffset? performed_at { get; set; }
}
