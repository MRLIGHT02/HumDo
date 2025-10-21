using System;
using System.Collections.Generic;

namespace HumDo.Domain.Entities;

public partial class match
{
    public Guid match_id { get; set; }

    public Guid user_a { get; set; }

    public Guid user_b { get; set; }

    public DateTimeOffset? created_at { get; set; }

    public string? mutual_swipe_window { get; set; }

    public bool? is_active { get; set; }

    public virtual ICollection<conversation> conversations { get; set; } = new List<conversation>();

    public virtual user user_aNavigation { get; set; } = null!;

    public virtual user user_bNavigation { get; set; } = null!;
}
