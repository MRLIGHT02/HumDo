using System;
using System.Collections.Generic;

namespace HumDo.Infrastructure.Entities;

public partial class message
{
    public Guid message_id { get; set; }

    public Guid conversation_id { get; set; }

    public Guid sender_id { get; set; }

    public string? body { get; set; }

    public DateTimeOffset? sent_at { get; set; }

    public DateTimeOffset? edited_at { get; set; }

    public bool? is_deleted { get; set; }

    public virtual conversation conversation { get; set; } = null!;

    public virtual ICollection<message_attachment> message_attachments { get; set; } = new List<message_attachment>();

    public virtual ICollection<message_reaction> message_reactions { get; set; } = new List<message_reaction>();

    public virtual ICollection<message_seen_event> message_seen_events { get; set; } = new List<message_seen_event>();

    public virtual ICollection<report> reports { get; set; } = new List<report>();

    public virtual user sender { get; set; } = null!;
}
