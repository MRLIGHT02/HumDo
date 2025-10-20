using System;
using System.Collections.Generic;

namespace HumDo.Infrastructure.Entities;

public partial class user_photo
{
    public Guid photo_id { get; set; }

    public Guid user_id { get; set; }

    public string storage_key { get; set; } = null!;

    public string? url { get; set; }

    public int? width { get; set; }

    public int? height { get; set; }

    public bool? is_primary { get; set; }

    public bool? is_active { get; set; }

    public DateTimeOffset? uploaded_at { get; set; }

    public virtual user user { get; set; } = null!;
}
