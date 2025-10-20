using System;
using System.Collections.Generic;

namespace HumDo.Infrastructure.Entities;

public partial class sms_log
{
    public long sms_id { get; set; }

    public Guid? user_id { get; set; }

    public string? to_number { get; set; }

    public string? message_snippet { get; set; }

    public DateTimeOffset? sent_at { get; set; }

    public string? provider_response { get; set; }

    public virtual user? user { get; set; }
}
