using System;
using System.Collections.Generic;

namespace HumDo.Infrastructure.Entities;

public partial class relationship_type
{
    public int relationship_type_id { get; set; }

    public string key { get; set; } = null!;

    public string display_name { get; set; } = null!;
}
