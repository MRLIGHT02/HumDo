using System;
using System.Collections.Generic;

namespace HumDo.Infrastructure.Entities;

public partial class user_preference
{
    public Guid user_id { get; set; }

    public short? min_age { get; set; }

    public short? max_age { get; set; }

    public int? max_distance_km { get; set; }

    public string? preferred_gender_ids { get; set; }

    public string? preferred_relationship_ids { get; set; }

    public bool? only_verified { get; set; }

    public DateTimeOffset? updated_at { get; set; }

    public virtual user user { get; set; } = null!;
}
