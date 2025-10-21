using System;
using System.Collections.Generic;

namespace HumDo.Domain.Entities;

public partial class gender
{
    public int gender_id { get; set; }

    public string key { get; set; } = null!;

    public string display_name { get; set; } = null!;

    public virtual ICollection<user_profile> user_profiles { get; set; } = new List<user_profile>();
}
