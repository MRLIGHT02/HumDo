using System;
using System.Collections.Generic;
using HumDo.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace HumDo.Infrastructure.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<_event> events { get; set; }

    public virtual DbSet<admin_action> admin_actions { get; set; }

    public virtual DbSet<api_key> api_keys { get; set; }

    public virtual DbSet<app_config> app_configs { get; set; }

    public virtual DbSet<audit_log> audit_logs { get; set; }

    public virtual DbSet<block> blocks { get; set; }

    public virtual DbSet<boost> boosts { get; set; }

    public virtual DbSet<boost_session> boost_sessions { get; set; }

    public virtual DbSet<conversation> conversations { get; set; }

    public virtual DbSet<conversation_participant> conversation_participants { get; set; }

    public virtual DbSet<daily_user_metric> daily_user_metrics { get; set; }

    public virtual DbSet<device_fingerprint> device_fingerprints { get; set; }

    public virtual DbSet<discount_code> discount_codes { get; set; }

    public virtual DbSet<email_log> email_logs { get; set; }

    public virtual DbSet<feature_event> feature_events { get; set; }

    public virtual DbSet<gender> genders { get; set; }

    public virtual DbSet<interest> interests { get; set; }

    public virtual DbSet<invoice> invoices { get; set; }

    public virtual DbSet<ip_reputation> ip_reputations { get; set; }

    public virtual DbSet<language> languages { get; set; }

    public virtual DbSet<location> locations { get; set; }

    public virtual DbSet<login_attempt> login_attempts { get; set; }

    public virtual DbSet<match> matches { get; set; }

    public virtual DbSet<match_score> match_scores { get; set; }

    public virtual DbSet<media_file> media_files { get; set; }

    public virtual DbSet<message> messages { get; set; }

    public virtual DbSet<message_attachment> message_attachments { get; set; }

    public virtual DbSet<message_reaction> message_reactions { get; set; }

    public virtual DbSet<message_seen_event> message_seen_events { get; set; }

    public virtual DbSet<metrics_aggregate> metrics_aggregates { get; set; }

    public virtual DbSet<moderation_note> moderation_notes { get; set; }

    public virtual DbSet<notification> notifications { get; set; }

    public virtual DbSet<notification_object> notification_objects { get; set; }

    public virtual DbSet<password_reset> password_resets { get; set; }

    public virtual DbSet<plan> plans { get; set; }

    public virtual DbSet<push_token> push_tokens { get; set; }

    public virtual DbSet<rate_limit> rate_limits { get; set; }

    public virtual DbSet<relationship_type> relationship_types { get; set; }

    public virtual DbSet<report> reports { get; set; }

    public virtual DbSet<report_review> report_reviews { get; set; }

    public virtual DbSet<setting> settings { get; set; }

    public virtual DbSet<sms_log> sms_logs { get; set; }

    public virtual DbSet<storage_provider> storage_providers { get; set; }

    public virtual DbSet<subscription> subscriptions { get; set; }

    public virtual DbSet<swipe> swipes { get; set; }

    public virtual DbSet<swipe_event> swipe_events { get; set; }

    public virtual DbSet<third_party_integration> third_party_integrations { get; set; }

    public virtual DbSet<transaction> transactions { get; set; }

    public virtual DbSet<trust_score> trust_scores { get; set; }

    public virtual DbSet<user> users { get; set; }

    public virtual DbSet<user_flag> user_flags { get; set; }

    public virtual DbSet<user_interest> user_interests { get; set; }

    public virtual DbSet<user_language> user_languages { get; set; }

    public virtual DbSet<user_photo> user_photos { get; set; }

    public virtual DbSet<user_preference> user_preferences { get; set; }

    public virtual DbSet<user_profile> user_profiles { get; set; }

    public virtual DbSet<user_session> user_sessions { get; set; }

    public virtual DbSet<user_social_link> user_social_links { get; set; }

    public virtual DbSet<user_verification> user_verifications { get; set; }

    public virtual DbSet<webhook_log> webhook_logs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=HumDoDb;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<_event>(entity =>
        {
            entity.HasKey(e => e.event_id).HasName("PK__events__2370F72781499A64");

            entity.Property(e => e.event_id).ValueGeneratedNever();
            entity.Property(e => e.created_at).HasDefaultValueSql("(sysdatetimeoffset())");
            entity.Property(e => e.event_type).HasMaxLength(200);
        });

        modelBuilder.Entity<admin_action>(entity =>
        {
            entity.HasKey(e => e.action_id).HasName("PK__admin_ac__74EFC21719890747");

            entity.Property(e => e.action_type).HasMaxLength(100);
            entity.Property(e => e.performed_at).HasDefaultValueSql("(sysdatetimeoffset())");

            entity.HasOne(d => d.target_user).WithMany(p => p.admin_actions)
                .HasForeignKey(d => d.target_user_id)
                .HasConstraintName("FK__admin_act__targe__19AACF41");
        });

        modelBuilder.Entity<api_key>(entity =>
        {
            entity.HasKey(e => e.key_id).HasName("PK__api_keys__97DF9ACD3129DC15");

            entity.Property(e => e.key_id).ValueGeneratedNever();
            entity.Property(e => e.created_at).HasDefaultValueSql("(sysdatetimeoffset())");
            entity.Property(e => e.key_hash).HasMaxLength(512);
            entity.Property(e => e.owner).HasMaxLength(200);
        });

        modelBuilder.Entity<app_config>(entity =>
        {
            entity.HasKey(e => e.config_id).HasName("PK__app_conf__4AD1BFF1244FD124");

            entity.ToTable("app_config");

            entity.Property(e => e.created_at).HasDefaultValueSql("(sysdatetimeoffset())");
            entity.Property(e => e.env).HasMaxLength(50);
            entity.Property(e => e.key).HasMaxLength(200);
        });

        modelBuilder.Entity<audit_log>(entity =>
        {
            entity.HasKey(e => e.audit_id).HasName("PK__audit_lo__5AF33E33035F174E");

            entity.Property(e => e.action).HasMaxLength(50);
            entity.Property(e => e.entity_table).HasMaxLength(200);
            entity.Property(e => e.performed_at).HasDefaultValueSql("(sysdatetimeoffset())");
            entity.Property(e => e.performed_by).HasMaxLength(200);
        });

        modelBuilder.Entity<block>(entity =>
        {
            entity.HasKey(e => new { e.blocker_id, e.blocked_id }).HasName("PK__blocks__638690F3DE6E6612");

            entity.Property(e => e.blocked_at).HasDefaultValueSql("(sysdatetimeoffset())");
            entity.Property(e => e.reason).HasMaxLength(255);

            entity.HasOne(d => d.blocked).WithMany(p => p.blockblockeds)
                .HasForeignKey(d => d.blocked_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__blocks__blocked___55009F39");

            entity.HasOne(d => d.blocker).WithMany(p => p.blockblockers)
                .HasForeignKey(d => d.blocker_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__blocks__blocker___540C7B00");
        });

        modelBuilder.Entity<boost>(entity =>
        {
            entity.HasKey(e => e.boost_id).HasName("PK__boosts__F709BD14A4627334");

            entity.Property(e => e.boost_id).ValueGeneratedNever();
            entity.Property(e => e.boost_type).HasMaxLength(50);
            entity.Property(e => e.started_at).HasDefaultValueSql("(sysdatetimeoffset())");

            entity.HasOne(d => d.user).WithMany(p => p.boosts)
                .HasForeignKey(d => d.user_id)
                .HasConstraintName("FK__boosts__user_id__04AFB25B");
        });

        modelBuilder.Entity<boost_session>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__boost_se__3213E83F3CAFAE18");

            entity.Property(e => e.activated_at).HasDefaultValueSql("(sysdatetimeoffset())");
            entity.Property(e => e.consumed).HasDefaultValue(false);
            entity.Property(e => e.source).HasMaxLength(100);

            entity.HasOne(d => d.user).WithMany(p => p.boost_sessions)
                .HasForeignKey(d => d.user_id)
                .HasConstraintName("FK__boost_ses__user___0880433F");
        });

        modelBuilder.Entity<conversation>(entity =>
        {
            entity.HasKey(e => e.conversation_id).HasName("PK__conversa__311E7E9A41874F11");

            entity.Property(e => e.conversation_id).ValueGeneratedNever();
            entity.Property(e => e.created_at).HasDefaultValueSql("(sysdatetimeoffset())");
            entity.Property(e => e.is_active).HasDefaultValue(true);
            entity.Property(e => e.is_match_based).HasDefaultValue(true);

            entity.HasOne(d => d.created_byNavigation).WithMany(p => p.conversations)
                .HasForeignKey(d => d.created_by)
                .HasConstraintName("FK__conversat__creat__3587F3E0");

            entity.HasOne(d => d.match).WithMany(p => p.conversations)
                .HasForeignKey(d => d.match_id)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__conversat__match__3493CFA7");
        });

        modelBuilder.Entity<conversation_participant>(entity =>
        {
            entity.HasKey(e => new { e.conversation_id, e.user_id }).HasName("PK__conversa__DA859DEA1599C0DC");

            entity.Property(e => e.is_muted).HasDefaultValue(false);
            entity.Property(e => e.joined_at).HasDefaultValueSql("(sysdatetimeoffset())");

            entity.HasOne(d => d.conversation).WithMany(p => p.conversation_participants)
                .HasForeignKey(d => d.conversation_id)
                .HasConstraintName("FK__conversat__conve__3A4CA8FD");

            entity.HasOne(d => d.user).WithMany(p => p.conversation_participants)
                .HasForeignKey(d => d.user_id)
                .HasConstraintName("FK__conversat__user___3B40CD36");
        });

        modelBuilder.Entity<daily_user_metric>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__daily_us__3213E83FFA7D6F41");

            entity.Property(e => e.logins).HasDefaultValue(0);
            entity.Property(e => e.matches_created).HasDefaultValue(0);
            entity.Property(e => e.messages_sent).HasDefaultValue(0);
            entity.Property(e => e.swipes_received).HasDefaultValue(0);
            entity.Property(e => e.swipes_sent).HasDefaultValue(0);

            entity.HasOne(d => d.user).WithMany(p => p.daily_user_metrics)
                .HasForeignKey(d => d.user_id)
                .HasConstraintName("FK__daily_use__user___24285DB4");
        });

        modelBuilder.Entity<device_fingerprint>(entity =>
        {
            entity.HasKey(e => e.fingerprint_id).HasName("PK__device_f__0695674677BB9D7A");

            entity.Property(e => e.fingerprint_id).ValueGeneratedNever();
            entity.Property(e => e.fingerprint_hash).HasMaxLength(512);
            entity.Property(e => e.first_seen_at).HasDefaultValueSql("(sysdatetimeoffset())");
            entity.Property(e => e.last_seen_at).HasDefaultValueSql("(sysdatetimeoffset())");

            entity.HasOne(d => d.user).WithMany(p => p.device_fingerprints)
                .HasForeignKey(d => d.user_id)
                .HasConstraintName("FK__device_fi__user___4959E263");
        });

        modelBuilder.Entity<discount_code>(entity =>
        {
            entity.HasKey(e => e.code).HasName("PK__discount__357D4CF8EB6E96AA");

            entity.Property(e => e.code).HasMaxLength(100);
            entity.Property(e => e.created_at).HasDefaultValueSql("(sysdatetimeoffset())");
            entity.Property(e => e.description).HasMaxLength(255);
        });

        modelBuilder.Entity<email_log>(entity =>
        {
            entity.HasKey(e => e.email_id).HasName("PK__email_lo__3FEF87660E08C44E");

            entity.Property(e => e.subject).HasMaxLength(500);
            entity.Property(e => e.to_address).HasMaxLength(255);

            entity.HasOne(d => d.user).WithMany(p => p.email_logs)
                .HasForeignKey(d => d.user_id)
                .HasConstraintName("FK__email_log__user___4E1E9780");
        });

        modelBuilder.Entity<feature_event>(entity =>
        {
            entity.HasKey(e => e.event_id).HasName("PK__feature___2370F727F396B1B9");

            entity.Property(e => e.feature_key).HasMaxLength(200);
            entity.Property(e => e.occurred_at).HasDefaultValueSql("(sysdatetimeoffset())");

            entity.HasOne(d => d.user).WithMany(p => p.feature_events)
                .HasForeignKey(d => d.user_id)
                .HasConstraintName("FK__feature_e__user___2BC97F7C");
        });

        modelBuilder.Entity<gender>(entity =>
        {
            entity.HasKey(e => e.gender_id).HasName("PK__genders__9DF18F87CB3545E9");

            entity.HasIndex(e => e.key, "UQ__genders__DFD83CAF107A7DE4").IsUnique();

            entity.Property(e => e.display_name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.key)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<interest>(entity =>
        {
            entity.HasKey(e => e.interest_id).HasName("PK__interest__0F5A1FAD9646BB75");

            entity.HasIndex(e => e.name, "UQ__interest__72E12F1B1EA85E85").IsUnique();

            entity.Property(e => e.category)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.created_at).HasDefaultValueSql("(sysdatetimeoffset())");
            entity.Property(e => e.name)
                .HasMaxLength(120)
                .IsUnicode(false);
        });

        modelBuilder.Entity<invoice>(entity =>
        {
            entity.HasKey(e => e.invoice_id).HasName("PK__invoices__F58DFD49F5406A97");

            entity.Property(e => e.invoice_id).ValueGeneratedNever();
            entity.Property(e => e.issued_at).HasDefaultValueSql("(sysdatetimeoffset())");

            entity.HasOne(d => d.transaction).WithMany(p => p.invoices)
                .HasForeignKey(d => d.transaction_id)
                .HasConstraintName("FK__invoices__transa__7D0E9093");

            entity.HasOne(d => d.user).WithMany(p => p.invoices)
                .HasForeignKey(d => d.user_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__invoices__user_i__7E02B4CC");
        });

        modelBuilder.Entity<ip_reputation>(entity =>
        {
            entity.HasKey(e => e.ip_address).HasName("PK__ip_reput__5376BCC5DA9F0E03");

            entity.ToTable("ip_reputation");

            entity.Property(e => e.ip_address).HasMaxLength(100);
        });

        modelBuilder.Entity<language>(entity =>
        {
            entity.HasKey(e => e.language_id).HasName("PK__language__804CF6B370F6169C");

            entity.HasIndex(e => e.iso_code, "UQ__language__153DD4A67C4A68AC").IsUnique();

            entity.Property(e => e.iso_code)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<location>(entity =>
        {
            entity.HasKey(e => e.location_id).HasName("PK__location__771831EA3EFE9E31");

            entity.Property(e => e.recorded_at).HasDefaultValueSql("(sysdatetimeoffset())");

            entity.HasOne(d => d.user).WithMany(p => p.locations)
                .HasForeignKey(d => d.user_id)
                .HasConstraintName("FK_locations_users");
        });

        modelBuilder.Entity<login_attempt>(entity =>
        {
            entity.HasKey(e => e.attempt_id).HasName("PK__login_at__5621F949F402D3A6");

            entity.Property(e => e.attempted_at).HasDefaultValueSql("(sysdatetimeoffset())");
            entity.Property(e => e.failure_reason)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.ip_address)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.user_agent)
                .HasMaxLength(1000)
                .IsUnicode(false);

            entity.HasOne(d => d.user).WithMany(p => p.login_attempts)
                .HasForeignKey(d => d.user_id)
                .HasConstraintName("FK_login_attempts_users");
        });

        modelBuilder.Entity<match>(entity =>
        {
            entity.HasKey(e => e.match_id).HasName("PK__matches__9D7FCBA35C4052A6");

            entity.Property(e => e.match_id).ValueGeneratedNever();
            entity.Property(e => e.created_at).HasDefaultValueSql("(sysdatetimeoffset())");
            entity.Property(e => e.is_active).HasDefaultValue(true);

            entity.HasOne(d => d.user_aNavigation).WithMany(p => p.matchuser_aNavigations)
                .HasForeignKey(d => d.user_a)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__matches__user_a__29221CFB");

            entity.HasOne(d => d.user_bNavigation).WithMany(p => p.matchuser_bNavigations)
                .HasForeignKey(d => d.user_b)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__matches__user_b__2A164134");
        });

        modelBuilder.Entity<match_score>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__match_sc__3213E83F75DC88FB");

            entity.Property(e => e.computed_at).HasDefaultValueSql("(sysdatetimeoffset())");
            entity.Property(e => e.model_version).HasMaxLength(50);

            entity.HasOne(d => d.candidate_user).WithMany(p => p.match_scorecandidate_users)
                .HasForeignKey(d => d.candidate_user_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__match_sco__candi__2FCF1A8A");

            entity.HasOne(d => d.user).WithMany(p => p.match_scoreusers)
                .HasForeignKey(d => d.user_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__match_sco__user___2EDAF651");
        });

        modelBuilder.Entity<media_file>(entity =>
        {
            entity.HasKey(e => e.media_id).HasName("PK__media_fi__D0A840F4DEAAA6D9");

            entity.Property(e => e.media_id).ValueGeneratedNever();
            entity.Property(e => e.created_at).HasDefaultValueSql("(sysdatetimeoffset())");
            entity.Property(e => e.file_name)
                .HasMaxLength(1024)
                .IsUnicode(false);
            entity.Property(e => e.mime_type)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.storage_key)
                .HasMaxLength(1000)
                .IsUnicode(false);

            entity.HasOne(d => d.owner_user).WithMany(p => p.media_files)
                .HasForeignKey(d => d.owner_user_id)
                .HasConstraintName("FK_media_files_users");
        });

        modelBuilder.Entity<message>(entity =>
        {
            entity.HasKey(e => e.message_id).HasName("PK__messages__0BBF6EE60C84DBE0");

            entity.Property(e => e.message_id).ValueGeneratedNever();
            entity.Property(e => e.is_deleted).HasDefaultValue(false);
            entity.Property(e => e.sent_at).HasDefaultValueSql("(sysdatetimeoffset())");

            entity.HasOne(d => d.conversation).WithMany(p => p.messages)
                .HasForeignKey(d => d.conversation_id)
                .HasConstraintName("FK__messages__conver__40058253");

            entity.HasOne(d => d.sender).WithMany(p => p.messages)
                .HasForeignKey(d => d.sender_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__messages__sender__40F9A68C");
        });

        modelBuilder.Entity<message_attachment>(entity =>
        {
            entity.HasKey(e => e.attachment_id).HasName("PK__message___B74DF4E23E5FE82B");

            entity.Property(e => e.attachment_id).ValueGeneratedNever();
            entity.Property(e => e.attachment_type).HasMaxLength(50);
            entity.Property(e => e.created_at).HasDefaultValueSql("(sysdatetimeoffset())");

            entity.HasOne(d => d.media).WithMany(p => p.message_attachments)
                .HasForeignKey(d => d.media_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__message_a__media__46B27FE2");

            entity.HasOne(d => d.message).WithMany(p => p.message_attachments)
                .HasForeignKey(d => d.message_id)
                .HasConstraintName("FK__message_a__messa__45BE5BA9");
        });

        modelBuilder.Entity<message_reaction>(entity =>
        {
            entity.HasKey(e => new { e.message_id, e.reactor_id, e.reaction }).HasName("PK__message___AB3D133EC3C3B4B3");

            entity.Property(e => e.reaction).HasMaxLength(50);
            entity.Property(e => e.reacted_at).HasDefaultValueSql("(sysdatetimeoffset())");

            entity.HasOne(d => d.message).WithMany(p => p.message_reactions)
                .HasForeignKey(d => d.message_id)
                .HasConstraintName("FK__message_r__messa__4A8310C6");

            entity.HasOne(d => d.reactor).WithMany(p => p.message_reactions)
                .HasForeignKey(d => d.reactor_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__message_r__react__4B7734FF");
        });

        modelBuilder.Entity<message_seen_event>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__message___3213E83FF80D6A82");

            entity.Property(e => e.seen_at).HasDefaultValueSql("(sysdatetimeoffset())");

            entity.HasOne(d => d.message).WithMany(p => p.message_seen_events)
                .HasForeignKey(d => d.message_id)
                .HasConstraintName("FK__message_s__messa__4F47C5E3");

            entity.HasOne(d => d.user).WithMany(p => p.message_seen_events)
                .HasForeignKey(d => d.user_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__message_s__user___503BEA1C");
        });

        modelBuilder.Entity<metrics_aggregate>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__metrics___3213E83F6CFDD11D");

            entity.Property(e => e.metric_name).HasMaxLength(200);
        });

        modelBuilder.Entity<moderation_note>(entity =>
        {
            entity.HasKey(e => e.note_id).HasName("PK__moderati__CEDD0FA48813711E");

            entity.Property(e => e.created_at).HasDefaultValueSql("(sysdatetimeoffset())");

            entity.HasOne(d => d.user).WithMany(p => p.moderation_notes)
                .HasForeignKey(d => d.user_id)
                .HasConstraintName("FK__moderatio__user___2057CCD0");
        });

        modelBuilder.Entity<notification>(entity =>
        {
            entity.HasKey(e => e.notification_id).HasName("PK__notifica__E059842F51D92713");

            entity.Property(e => e.notification_id).ValueGeneratedNever();
            entity.Property(e => e.created_at).HasDefaultValueSql("(sysdatetimeoffset())");
            entity.Property(e => e.is_read).HasDefaultValue(false);
            entity.Property(e => e.title).HasMaxLength(255);
            entity.Property(e => e.type).HasMaxLength(100);

            entity.HasOne(d => d.user).WithMany(p => p.notifications)
                .HasForeignKey(d => d.user_id)
                .HasConstraintName("FK__notificat__user___0E391C95");
        });

        modelBuilder.Entity<notification_object>(entity =>
        {
            entity.HasKey(e => e.notification_object_id).HasName("PK__notifica__F142996CD8E6C5D9");

            entity.Property(e => e.notification_object_id).ValueGeneratedNever();
            entity.Property(e => e.created_at).HasDefaultValueSql("(sysdatetimeoffset())");
            entity.Property(e => e.entity_type).HasMaxLength(100);
        });

        modelBuilder.Entity<password_reset>(entity =>
        {
            entity.HasKey(e => e.reset_id).HasName("PK__password__40FB05204707803C");

            entity.Property(e => e.reset_id).ValueGeneratedNever();
            entity.Property(e => e.requested_at).HasDefaultValueSql("(sysdatetimeoffset())");
            entity.Property(e => e.reset_token)
                .HasMaxLength(512)
                .IsUnicode(false);

            entity.HasOne(d => d.user).WithMany(p => p.password_resets)
                .HasForeignKey(d => d.user_id)
                .HasConstraintName("FK_password_resets_users");
        });

        modelBuilder.Entity<plan>(entity =>
        {
            entity.HasKey(e => e.plan_id).HasName("PK__plans__BE9F8F1D188F583B");

            entity.HasIndex(e => e.plan_key, "UQ__plans__BCFA19D71B7CFEF0").IsUnique();

            entity.Property(e => e.created_at).HasDefaultValueSql("(sysdatetimeoffset())");
            entity.Property(e => e.currency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.display_name).HasMaxLength(255);
            entity.Property(e => e.plan_key).HasMaxLength(100);
        });

        modelBuilder.Entity<push_token>(entity =>
        {
            entity.HasKey(e => e.token_id).HasName("PK__push_tok__CB3C9E1731E47540");

            entity.Property(e => e.token_id).ValueGeneratedNever();
            entity.Property(e => e.device_model).HasMaxLength(200);
            entity.Property(e => e.last_seen_at).HasDefaultValueSql("(sysdatetimeoffset())");
            entity.Property(e => e.platform).HasMaxLength(50);
            entity.Property(e => e.token).HasMaxLength(2000);

            entity.HasOne(d => d.user).WithMany(p => p.push_tokens)
                .HasForeignKey(d => d.user_id)
                .HasConstraintName("FK__push_toke__user___15DA3E5D");
        });

        modelBuilder.Entity<rate_limit>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__rate_lim__3213E83F077AF42B");

            entity.Property(e => e.created_at).HasDefaultValueSql("(sysdatetimeoffset())");
            entity.Property(e => e.key).HasMaxLength(200);

            entity.HasOne(d => d.user).WithMany(p => p.rate_limits)
                .HasForeignKey(d => d.user_id)
                .HasConstraintName("FK__rate_limi__user___4589517F");
        });

        modelBuilder.Entity<relationship_type>(entity =>
        {
            entity.HasKey(e => e.relationship_type_id).HasName("PK__relation__D9975703154C668B");

            entity.HasIndex(e => e.key, "UQ__relation__DFD83CAF16D261A6").IsUnique();

            entity.Property(e => e.display_name)
                .HasMaxLength(120)
                .IsUnicode(false);
            entity.Property(e => e.key)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<report>(entity =>
        {
            entity.HasKey(e => e.report_id).HasName("PK__reports__779B7C5820F9B631");

            entity.Property(e => e.report_id).ValueGeneratedNever();
            entity.Property(e => e.created_at).HasDefaultValueSql("(sysdatetimeoffset())");
            entity.Property(e => e.report_reason).HasMaxLength(255);
            entity.Property(e => e.status)
                .HasMaxLength(50)
                .HasDefaultValue("open");

            entity.HasOne(d => d.reported_message).WithMany(p => p.reports)
                .HasForeignKey(d => d.reported_message_id)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__reports__reporte__5AB9788F");

            entity.HasOne(d => d.reported_user).WithMany(p => p.reportreported_users)
                .HasForeignKey(d => d.reported_user_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__reports__reporte__59C55456");

            entity.HasOne(d => d.reporter).WithMany(p => p.reportreporters)
                .HasForeignKey(d => d.reporter_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__reports__reporte__58D1301D");
        });

        modelBuilder.Entity<report_review>(entity =>
        {
            entity.HasKey(e => e.review_id).HasName("PK__report_r__60883D9033C7AE15");

            entity.Property(e => e.action_taken).HasMaxLength(100);
            entity.Property(e => e.reviewed_at).HasDefaultValueSql("(sysdatetimeoffset())");

            entity.HasOne(d => d.report).WithMany(p => p.report_reviews)
                .HasForeignKey(d => d.report_id)
                .HasConstraintName("FK__report_re__repor__5F7E2DAC");
        });

        modelBuilder.Entity<setting>(entity =>
        {
            entity.HasKey(e => e.setting_key).HasName("PK__settings__0DFAC42644B05440");

            entity.Property(e => e.setting_key).HasMaxLength(200);
            entity.Property(e => e.updated_at).HasDefaultValueSql("(sysdatetimeoffset())");
        });

        modelBuilder.Entity<sms_log>(entity =>
        {
            entity.HasKey(e => e.sms_id).HasName("PK__sms_logs__72F6EB0E2B2ECA2C");

            entity.Property(e => e.to_number).HasMaxLength(50);

            entity.HasOne(d => d.user).WithMany(p => p.sms_logs)
                .HasForeignKey(d => d.user_id)
                .HasConstraintName("FK__sms_logs__user_i__50FB042B");
        });

        modelBuilder.Entity<storage_provider>(entity =>
        {
            entity.HasKey(e => e.provider_id).HasName("PK__storage___00E2131037BB6099");

            entity.Property(e => e.created_at).HasDefaultValueSql("(sysdatetimeoffset())");
            entity.Property(e => e.name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.type)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<subscription>(entity =>
        {
            entity.HasKey(e => e.subscription_id).HasName("PK__subscrip__863A7EC186F0AAB9");

            entity.Property(e => e.subscription_id).ValueGeneratedNever();
            entity.Property(e => e.auto_renew).HasDefaultValue(true);
            entity.Property(e => e.is_active).HasDefaultValue(true);
            entity.Property(e => e.provider_subscription_id).HasMaxLength(255);
            entity.Property(e => e.started_at).HasDefaultValueSql("(sysdatetimeoffset())");

            entity.HasOne(d => d.plan).WithMany(p => p.subscriptions)
                .HasForeignKey(d => d.plan_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__subscript__plan___73852659");

            entity.HasOne(d => d.user).WithMany(p => p.subscriptions)
                .HasForeignKey(d => d.user_id)
                .HasConstraintName("FK__subscript__user___72910220");
        });

        modelBuilder.Entity<swipe>(entity =>
        {
            entity.HasKey(e => e.swipe_id).HasName("PK__swipes__07A502BBD549FCF6");

            entity.Property(e => e.swipe_id).ValueGeneratedNever();
            entity.Property(e => e.created_at).HasDefaultValueSql("(sysdatetimeoffset())");
            entity.Property(e => e.source).HasMaxLength(50);

            entity.HasOne(d => d.swipee).WithMany(p => p.swipeswipees)
                .HasForeignKey(d => d.swipee_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__swipes__swipee_i__2180FB33");

            entity.HasOne(d => d.swiper).WithMany(p => p.swipeswipers)
                .HasForeignKey(d => d.swiper_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__swipes__swiper_i__208CD6FA");
        });

        modelBuilder.Entity<swipe_event>(entity =>
        {
            entity.HasKey(e => e.event_id).HasName("PK__swipe_ev__2370F727CEAE44DC");

            entity.Property(e => e.event_time).HasDefaultValueSql("(sysdatetimeoffset())");
            entity.Property(e => e.event_type).HasMaxLength(50);

            entity.HasOne(d => d.swipe).WithMany(p => p.swipe_events)
                .HasForeignKey(d => d.swipe_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__swipe_eve__swipe__25518C17");
        });

        modelBuilder.Entity<third_party_integration>(entity =>
        {
            entity.HasKey(e => e.integration_id).HasName("PK__third_pa__B403D8878D1EF0BD");

            entity.Property(e => e.created_at).HasDefaultValueSql("(sysdatetimeoffset())");
            entity.Property(e => e.enabled).HasDefaultValue(true);
            entity.Property(e => e.name).HasMaxLength(200);
            entity.Property(e => e.type).HasMaxLength(100);
        });

        modelBuilder.Entity<transaction>(entity =>
        {
            entity.HasKey(e => e.transaction_id).HasName("PK__transact__85C600AF2A2584F8");

            entity.Property(e => e.transaction_id).ValueGeneratedNever();
            entity.Property(e => e.created_at).HasDefaultValueSql("(sysdatetimeoffset())");
            entity.Property(e => e.currency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.payment_provider).HasMaxLength(100);
            entity.Property(e => e.provider_txn_id).HasMaxLength(255);
            entity.Property(e => e.status).HasMaxLength(50);
            entity.Property(e => e.type).HasMaxLength(50);

            entity.HasOne(d => d.user).WithMany(p => p.transactions)
                .HasForeignKey(d => d.user_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__transacti__user___793DFFAF");
        });

        modelBuilder.Entity<trust_score>(entity =>
        {
            entity.HasKey(e => e.user_id).HasName("PK__trust_sc__B9BE370F0C97D55A");

            entity.Property(e => e.user_id).ValueGeneratedNever();
            entity.Property(e => e.score).HasDefaultValue(0.0);

            entity.HasOne(d => d.user).WithOne(p => p.trust_score)
                .HasForeignKey<trust_score>(d => d.user_id)
                .HasConstraintName("FK__trust_sco__user___671F4F74");
        });

        modelBuilder.Entity<user>(entity =>
        {
            entity.HasKey(e => e.user_id).HasName("PK__users__B9BE370FDE77C485");

            entity.HasIndex(e => e.email, "UQ__users__AB6E616486528199").IsUnique();

            entity.Property(e => e.user_id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.created_at).HasDefaultValueSql("(sysdatetimeoffset())");
            entity.Property(e => e.email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.is_active).HasDefaultValue(true);
            entity.Property(e => e.is_deleted).HasDefaultValue(false);
            entity.Property(e => e.is_email_confirmed).HasDefaultValue(false);
            entity.Property(e => e.is_phone_confirmed).HasDefaultValue(false);
            entity.Property(e => e.password_hash)
                .HasMaxLength(1024)
                .IsUnicode(false);
            entity.Property(e => e.popularity_score).HasDefaultValue(0.0);
        });

        modelBuilder.Entity<user_flag>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__user_fla__3213E83FA93E0300");

            entity.Property(e => e.created_at).HasDefaultValueSql("(sysdatetimeoffset())");
            entity.Property(e => e.flag_type).HasMaxLength(100);

            entity.HasOne(d => d.user).WithMany(p => p.user_flags)
                .HasForeignKey(d => d.user_id)
                .HasConstraintName("FK__user_flag__user___634EBE90");
        });

        modelBuilder.Entity<user_interest>(entity =>
        {
            entity.HasKey(e => new { e.user_id, e.interest_id });

            entity.Property(e => e.added_at).HasDefaultValueSql("(sysdatetimeoffset())");

            entity.HasOne(d => d.interest).WithMany(p => p.user_interests)
                .HasForeignKey(d => d.interest_id)
                .HasConstraintName("FK_user_interests_interests");

            entity.HasOne(d => d.user).WithMany(p => p.user_interests)
                .HasForeignKey(d => d.user_id)
                .HasConstraintName("FK_user_interests_users");
        });

        modelBuilder.Entity<user_language>(entity =>
        {
            entity.HasKey(e => new { e.user_id, e.language_id });

            entity.HasOne(d => d.language).WithMany(p => p.user_languages)
                .HasForeignKey(d => d.language_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_user_languages_languages");

            entity.HasOne(d => d.user).WithMany(p => p.user_languages)
                .HasForeignKey(d => d.user_id)
                .HasConstraintName("FK_user_languages_users");
        });

        modelBuilder.Entity<user_photo>(entity =>
        {
            entity.HasKey(e => e.photo_id).HasName("PK__user_pho__CB48C83D47F1B958");

            entity.Property(e => e.photo_id).ValueGeneratedNever();
            entity.Property(e => e.is_active).HasDefaultValue(true);
            entity.Property(e => e.is_primary).HasDefaultValue(false);
            entity.Property(e => e.storage_key)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.uploaded_at).HasDefaultValueSql("(sysdatetimeoffset())");
            entity.Property(e => e.url)
                .HasMaxLength(1000)
                .IsUnicode(false);

            entity.HasOne(d => d.user).WithMany(p => p.user_photos)
                .HasForeignKey(d => d.user_id)
                .HasConstraintName("FK_user_photos_users");
        });

        modelBuilder.Entity<user_preference>(entity =>
        {
            entity.HasKey(e => e.user_id).HasName("PK__user_pre__B9BE370F38E8C3AC");

            entity.Property(e => e.user_id).ValueGeneratedNever();
            entity.Property(e => e.max_age).HasDefaultValue((short)99);
            entity.Property(e => e.max_distance_km).HasDefaultValue(50);
            entity.Property(e => e.min_age).HasDefaultValue((short)18);
            entity.Property(e => e.only_verified).HasDefaultValue(false);
            entity.Property(e => e.updated_at).HasDefaultValueSql("(sysdatetimeoffset())");

            entity.HasOne(d => d.user).WithOne(p => p.user_preference)
                .HasForeignKey<user_preference>(d => d.user_id)
                .HasConstraintName("FK__user_pref__user___5070F446");
        });

        modelBuilder.Entity<user_profile>(entity =>
        {
            entity.HasKey(e => e.user_id).HasName("PK__user_pro__B9BE370FEB38FFD1");

            entity.Property(e => e.user_id).ValueGeneratedNever();
            entity.Property(e => e.about).IsUnicode(false);
            entity.Property(e => e.city)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.country)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.created_at).HasDefaultValueSql("(sysdatetimeoffset())");
            entity.Property(e => e.display_name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.updated_at).HasDefaultValueSql("(sysdatetimeoffset())");

            entity.HasOne(d => d.gender).WithMany(p => p.user_profiles)
                .HasForeignKey(d => d.gender_id)
                .HasConstraintName("FK__user_prof__gende__48CFD27E");

            entity.HasOne(d => d.user).WithOne(p => p.user_profile)
                .HasForeignKey<user_profile>(d => d.user_id)
                .HasConstraintName("FK__user_prof__user___47DBAE45");
        });

        modelBuilder.Entity<user_session>(entity =>
        {
            entity.HasKey(e => e.session_id).HasName("PK__user_ses__69B13FDC180D6763");

            entity.Property(e => e.session_id).ValueGeneratedNever();
            entity.Property(e => e.created_at).HasDefaultValueSql("(sysdatetimeoffset())");
            entity.Property(e => e.device_info)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.ip_address)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.is_revoked).HasDefaultValue(false);

            entity.HasOne(d => d.user).WithMany(p => p.user_sessions)
                .HasForeignKey(d => d.user_id)
                .HasConstraintName("FK_user_sessions_users");
        });

        modelBuilder.Entity<user_social_link>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__user_soc__3213E83F80283195");

            entity.Property(e => e.created_at).HasDefaultValueSql("(sysdatetimeoffset())");
            entity.Property(e => e.external_user_id)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.provider)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.url)
                .HasMaxLength(1000)
                .IsUnicode(false);

            entity.HasOne(d => d.user).WithMany(p => p.user_social_links)
                .HasForeignKey(d => d.user_id)
                .HasConstraintName("FK_user_social_links_users");
        });

        modelBuilder.Entity<user_verification>(entity =>
        {
            entity.HasKey(e => e.verification_id).HasName("PK__user_ver__24F179691350CCE9");

            entity.Property(e => e.verification_id).ValueGeneratedNever();
            entity.Property(e => e.method)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.requested_at).HasDefaultValueSql("(sysdatetimeoffset())");
            entity.Property(e => e.status)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.user).WithMany(p => p.user_verifications)
                .HasForeignKey(d => d.user_id)
                .HasConstraintName("FK_user_verifications_users");
        });

        modelBuilder.Entity<webhook_log>(entity =>
        {
            entity.HasKey(e => e.webhook_id).HasName("PK__webhook___895D8FC70F0B29E7");

            entity.HasOne(d => d.integration).WithMany(p => p.webhook_logs)
                .HasForeignKey(d => d.integration_id)
                .HasConstraintName("FK__webhook_l__integ__40C49C62");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
