using System;
using System.Collections.Generic;

namespace HumDo.Domain.Entities;

public partial class match_score
{
    public long id { get; set; }

    public Guid user_id { get; set; }

    public Guid candidate_user_id { get; set; }

    public double? score { get; set; }

    public string? model_version { get; set; }

    public DateTimeOffset? computed_at { get; set; }

    public virtual user candidate_user { get; set; } = null!;

    public virtual user user { get; set; } = null!;
}
