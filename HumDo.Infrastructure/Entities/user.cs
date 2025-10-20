using System;
using System.Collections.Generic;

namespace HumDo.Infrastructure.Entities;

public partial class user
{
    public Guid user_id { get; set; }

    public string email { get; set; } = null!;

    public string password_hash { get; set; } = null!;

    public bool? is_email_confirmed { get; set; }

    public bool? is_phone_confirmed { get; set; }

    public bool? is_active { get; set; }

    public bool? is_deleted { get; set; }

    public DateTimeOffset? created_at { get; set; }

    public DateTimeOffset? last_login_at { get; set; }

    public double? popularity_score { get; set; }

    public virtual ICollection<admin_action> admin_actions { get; set; } = new List<admin_action>();

    public virtual ICollection<block> blockblockeds { get; set; } = new List<block>();

    public virtual ICollection<block> blockblockers { get; set; } = new List<block>();

    public virtual ICollection<boost_session> boost_sessions { get; set; } = new List<boost_session>();

    public virtual ICollection<boost> boosts { get; set; } = new List<boost>();

    public virtual ICollection<conversation_participant> conversation_participants { get; set; } = new List<conversation_participant>();

    public virtual ICollection<conversation> conversations { get; set; } = new List<conversation>();

    public virtual ICollection<daily_user_metric> daily_user_metrics { get; set; } = new List<daily_user_metric>();

    public virtual ICollection<device_fingerprint> device_fingerprints { get; set; } = new List<device_fingerprint>();

    public virtual ICollection<email_log> email_logs { get; set; } = new List<email_log>();

    public virtual ICollection<feature_event> feature_events { get; set; } = new List<feature_event>();

    public virtual ICollection<invoice> invoices { get; set; } = new List<invoice>();

    public virtual ICollection<location> locations { get; set; } = new List<location>();

    public virtual ICollection<login_attempt> login_attempts { get; set; } = new List<login_attempt>();

    public virtual ICollection<match_score> match_scorecandidate_users { get; set; } = new List<match_score>();

    public virtual ICollection<match_score> match_scoreusers { get; set; } = new List<match_score>();

    public virtual ICollection<match> matchuser_aNavigations { get; set; } = new List<match>();

    public virtual ICollection<match> matchuser_bNavigations { get; set; } = new List<match>();

    public virtual ICollection<media_file> media_files { get; set; } = new List<media_file>();

    public virtual ICollection<message_reaction> message_reactions { get; set; } = new List<message_reaction>();

    public virtual ICollection<message_seen_event> message_seen_events { get; set; } = new List<message_seen_event>();

    public virtual ICollection<message> messages { get; set; } = new List<message>();

    public virtual ICollection<moderation_note> moderation_notes { get; set; } = new List<moderation_note>();

    public virtual ICollection<notification> notifications { get; set; } = new List<notification>();

    public virtual ICollection<password_reset> password_resets { get; set; } = new List<password_reset>();

    public virtual ICollection<push_token> push_tokens { get; set; } = new List<push_token>();

    public virtual ICollection<rate_limit> rate_limits { get; set; } = new List<rate_limit>();

    public virtual ICollection<report> reportreported_users { get; set; } = new List<report>();

    public virtual ICollection<report> reportreporters { get; set; } = new List<report>();

    public virtual ICollection<sms_log> sms_logs { get; set; } = new List<sms_log>();

    public virtual ICollection<subscription> subscriptions { get; set; } = new List<subscription>();

    public virtual ICollection<swipe> swipeswipees { get; set; } = new List<swipe>();

    public virtual ICollection<swipe> swipeswipers { get; set; } = new List<swipe>();

    public virtual ICollection<transaction> transactions { get; set; } = new List<transaction>();

    public virtual trust_score? trust_score { get; set; }

    public virtual ICollection<user_flag> user_flags { get; set; } = new List<user_flag>();

    public virtual ICollection<user_interest> user_interests { get; set; } = new List<user_interest>();

    public virtual ICollection<user_language> user_languages { get; set; } = new List<user_language>();

    public virtual ICollection<user_photo> user_photos { get; set; } = new List<user_photo>();

    public virtual user_preference? user_preference { get; set; }

    public virtual user_profile? user_profile { get; set; }

    public virtual ICollection<user_session> user_sessions { get; set; } = new List<user_session>();

    public virtual ICollection<user_social_link> user_social_links { get; set; } = new List<user_social_link>();

    public virtual ICollection<user_verification> user_verifications { get; set; } = new List<user_verification>();
}
