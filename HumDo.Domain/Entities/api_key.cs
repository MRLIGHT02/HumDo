using System;
using System.Collections.Generic;

namespace HumDo.Domain.Entities;

public partial class api_key
{
    public Guid key_id { get; set; }

    public string? owner { get; set; }

    public string? key_hash { get; set; }

    public string? scopes { get; set; }

    public DateTimeOffset? created_at { get; set; }

    public DateTimeOffset? expires_at { get; set; }
}
