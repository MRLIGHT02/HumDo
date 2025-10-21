using System;
using System.Collections.Generic;

namespace HumDo.Domain.Entities;

public partial class invoice
{
    public Guid invoice_id { get; set; }

    public Guid transaction_id { get; set; }

    public Guid user_id { get; set; }

    public long? amount_cents { get; set; }

    public DateTimeOffset? issued_at { get; set; }

    public DateTimeOffset? paid_at { get; set; }

    public string? details { get; set; }

    public virtual transaction transaction { get; set; } = null!;

    public virtual user user { get; set; } = null!;
}
