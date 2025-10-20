using System;
using System.Collections.Generic;

namespace HumDo.Infrastructure.Entities;

public partial class swipe
{
    public Guid swipe_id { get; set; }

    public Guid swiper_id { get; set; }

    public Guid swipee_id { get; set; }

    public short? direction { get; set; }

    public string? source { get; set; }

    public DateTimeOffset? created_at { get; set; }

    public string? context { get; set; }

    public virtual ICollection<swipe_event> swipe_events { get; set; } = new List<swipe_event>();

    public virtual user swipee { get; set; } = null!;

    public virtual user swiper { get; set; } = null!;
}
