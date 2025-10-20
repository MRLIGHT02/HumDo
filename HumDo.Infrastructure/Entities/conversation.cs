using System;
using System.Collections.Generic;

namespace HumDo.Infrastructure.Entities;

public partial class conversation
{
    public Guid conversation_id { get; set; }

    public bool? is_match_based { get; set; }

    public Guid? match_id { get; set; }

    public Guid? created_by { get; set; }

    public DateTimeOffset? created_at { get; set; }

    public bool? is_active { get; set; }

    public virtual ICollection<conversation_participant> conversation_participants { get; set; } = new List<conversation_participant>();

    public virtual user? created_byNavigation { get; set; }

    public virtual match? match { get; set; }

    public virtual ICollection<message> messages { get; set; } = new List<message>();
}
