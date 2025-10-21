using System;
using System.Collections.Generic;

namespace HumDo.Domain.Entities;

public partial class transaction
{
    public Guid transaction_id { get; set; }

    public Guid user_id { get; set; }

    public long? amount_cents { get; set; }

    public string? currency { get; set; }

    public string? payment_provider { get; set; }

    public string? provider_txn_id { get; set; }

    public string? status { get; set; }

    public string? type { get; set; }

    public DateTimeOffset? created_at { get; set; }

    public virtual ICollection<invoice> invoices { get; set; } = new List<invoice>();

    public virtual user user { get; set; } = null!;
}
