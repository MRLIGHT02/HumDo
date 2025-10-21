using System;
using System.Collections.Generic;

namespace HumDo.Domain.Entities;

public partial class report_review
{
    public long review_id { get; set; }

    public Guid report_id { get; set; }

    public Guid? reviewer_admin_id { get; set; }

    public string? action_taken { get; set; }

    public string? notes { get; set; }

    public DateTimeOffset? reviewed_at { get; set; }

    public virtual report report { get; set; } = null!;
}
