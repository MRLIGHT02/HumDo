using System;
using System.Collections.Generic;

namespace HumDo.Infrastructure.Entities;

public partial class report
{
    public Guid report_id { get; set; }

    public Guid reporter_id { get; set; }

    public Guid reported_user_id { get; set; }

    public Guid? reported_message_id { get; set; }

    public string? report_reason { get; set; }

    public string? evidence { get; set; }

    public string? status { get; set; }

    public DateTimeOffset? created_at { get; set; }

    public virtual ICollection<report_review> report_reviews { get; set; } = new List<report_review>();

    public virtual message? reported_message { get; set; }

    public virtual user reported_user { get; set; } = null!;

    public virtual user reporter { get; set; } = null!;
}
