using System;
using System.Collections.Generic;

namespace HumDo.Domain.Entities;

public partial class user_language
{
    public Guid user_id { get; set; }

    public int language_id { get; set; }

    public short? fluency_level { get; set; }

    public virtual language language { get; set; } = null!;

    public virtual user user { get; set; } = null!;
}
