using System;
using System.Collections.Generic;

namespace HumDo.Infrastructure.Entities;

public partial class language
{
    public int language_id { get; set; }

    public string? iso_code { get; set; }

    public string? name { get; set; }

    public virtual ICollection<user_language> user_languages { get; set; } = new List<user_language>();
}
