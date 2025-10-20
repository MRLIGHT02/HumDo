using System;
using System.Collections.Generic;

namespace HumDo.Infrastructure.Entities;

public partial class media_file
{
    public Guid media_id { get; set; }

    public Guid? owner_user_id { get; set; }

    public string? file_name { get; set; }

    public string? mime_type { get; set; }

    public string? storage_key { get; set; }

    public long? size_bytes { get; set; }

    public string? metadata { get; set; }

    public DateTimeOffset? created_at { get; set; }

    public virtual ICollection<message_attachment> message_attachments { get; set; } = new List<message_attachment>();

    public virtual user? owner_user { get; set; }
}
