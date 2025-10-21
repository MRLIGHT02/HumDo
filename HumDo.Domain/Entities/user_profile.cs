using System;
using System.Collections.Generic;

namespace HumDo.Domain.Entities;

public partial class user_profile
{
    public Guid user_id { get; set; }

    public string? display_name { get; set; }

    public DateOnly? birthdate { get; set; }

    public int? gender_id { get; set; }

    public string? about { get; set; }

    public string? city { get; set; }

    public string? country { get; set; }

    public short? height_cm { get; set; }

    public DateTimeOffset? created_at { get; set; }

    public DateTimeOffset? updated_at { get; set; }

    public virtual gender? gender { get; set; }

    public virtual user user { get; set; } = null!;
}
