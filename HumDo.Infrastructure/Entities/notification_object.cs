using System;
using System.Collections.Generic;

namespace HumDo.Infrastructure.Entities;

public partial class notification_object
{
    public Guid notification_object_id { get; set; }

    public string? entity_type { get; set; }

    public Guid? entity_id { get; set; }

    public DateTimeOffset? created_at { get; set; }
}
