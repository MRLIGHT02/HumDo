using System;
using System.Collections.Generic;

namespace HumDo.Domain.Entities;

public partial class location
{
    public long location_id { get; set; }

    public Guid user_id { get; set; }

    public double? latitude { get; set; }

    public double? longitude { get; set; }

    public int? accuracy_meters { get; set; }

    public DateTimeOffset? recorded_at { get; set; }

    public virtual user user { get; set; } = null!;
}
