using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HumDo.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "api_keys",
                columns: table => new
                {
                    key_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    owner = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    key_hash = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    scopes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    expires_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__api_keys__97DF9ACD3129DC15", x => x.key_id);
                });

            migrationBuilder.CreateTable(
                name: "app_config",
                columns: table => new
                {
                    config_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    env = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    key = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__app_conf__4AD1BFF1244FD124", x => x.config_id);
                });

            migrationBuilder.CreateTable(
                name: "audit_logs",
                columns: table => new
                {
                    audit_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    entity_table = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    entity_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    action = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    performed_by = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    performed_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__audit_lo__5AF33E33035F174E", x => x.audit_id);
                });

            migrationBuilder.CreateTable(
                name: "discount_codes",
                columns: table => new
                {
                    code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    percent_off = table.Column<short>(type: "smallint", nullable: true),
                    max_uses = table.Column<int>(type: "int", nullable: true),
                    expires_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__discount__357D4CF8EB6E96AA", x => x.code);
                });

            migrationBuilder.CreateTable(
                name: "events",
                columns: table => new
                {
                    event_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    event_type = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    payload = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__events__2370F72781499A64", x => x.event_id);
                });

            migrationBuilder.CreateTable(
                name: "genders",
                columns: table => new
                {
                    gender_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    key = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    display_name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__genders__9DF18F87CB3545E9", x => x.gender_id);
                });

            migrationBuilder.CreateTable(
                name: "interests",
                columns: table => new
                {
                    interest_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(120)", unicode: false, maxLength: 120, nullable: false),
                    category = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__interest__0F5A1FAD9646BB75", x => x.interest_id);
                });

            migrationBuilder.CreateTable(
                name: "ip_reputation",
                columns: table => new
                {
                    ip_address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    score = table.Column<double>(type: "float", nullable: true),
                    last_checked_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ip_reput__5376BCC5DA9F0E03", x => x.ip_address);
                });

            migrationBuilder.CreateTable(
                name: "languages",
                columns: table => new
                {
                    language_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    iso_code = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__language__804CF6B370F6169C", x => x.language_id);
                });

            migrationBuilder.CreateTable(
                name: "metrics_aggregates",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    metric_name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    metric_date = table.Column<DateOnly>(type: "date", nullable: true),
                    value = table.Column<double>(type: "float", nullable: true),
                    metadata = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__metrics___3213E83F6CFDD11D", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "notification_objects",
                columns: table => new
                {
                    notification_object_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    entity_type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    entity_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__notifica__F142996CD8E6C5D9", x => x.notification_object_id);
                });

            migrationBuilder.CreateTable(
                name: "plans",
                columns: table => new
                {
                    plan_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    plan_key = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    display_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    price_cents = table.Column<long>(type: "bigint", nullable: true),
                    currency = table.Column<string>(type: "char(3)", unicode: false, fixedLength: true, maxLength: 3, nullable: true),
                    features = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__plans__BE9F8F1D188F583B", x => x.plan_id);
                });

            migrationBuilder.CreateTable(
                name: "relationship_types",
                columns: table => new
                {
                    relationship_type_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    key = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    display_name = table.Column<string>(type: "varchar(120)", unicode: false, maxLength: 120, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__relation__D9975703154C668B", x => x.relationship_type_id);
                });

            migrationBuilder.CreateTable(
                name: "settings",
                columns: table => new
                {
                    setting_key = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updated_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__settings__0DFAC42644B05440", x => x.setting_key);
                });

            migrationBuilder.CreateTable(
                name: "storage_providers",
                columns: table => new
                {
                    provider_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    config = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__storage___00E2131037BB6099", x => x.provider_id);
                });

            migrationBuilder.CreateTable(
                name: "third_party_integrations",
                columns: table => new
                {
                    integration_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    config = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    enabled = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    created_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__third_pa__B403D8878D1EF0BD", x => x.integration_id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    password_hash = table.Column<string>(type: "varchar(1024)", unicode: false, maxLength: 1024, nullable: false),
                    is_email_confirmed = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    is_phone_confirmed = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    is_active = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    created_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    last_login_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    popularity_score = table.Column<double>(type: "float", nullable: true, defaultValue: 0.0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__users__B9BE370FDE77C485", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "webhook_logs",
                columns: table => new
                {
                    webhook_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    integration_id = table.Column<int>(type: "int", nullable: true),
                    payload = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status_code = table.Column<int>(type: "int", nullable: true),
                    delivered_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__webhook___895D8FC70F0B29E7", x => x.webhook_id);
                    table.ForeignKey(
                        name: "FK__webhook_l__integ__40C49C62",
                        column: x => x.integration_id,
                        principalTable: "third_party_integrations",
                        principalColumn: "integration_id");
                });

            migrationBuilder.CreateTable(
                name: "admin_actions",
                columns: table => new
                {
                    action_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    admin_user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    action_type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    target_user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    performed_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__admin_ac__74EFC21719890747", x => x.action_id);
                    table.ForeignKey(
                        name: "FK__admin_act__targe__19AACF41",
                        column: x => x.target_user_id,
                        principalTable: "users",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "blocks",
                columns: table => new
                {
                    blocker_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    blocked_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    reason = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    blocked_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__blocks__638690F3DE6E6612", x => new { x.blocker_id, x.blocked_id });
                    table.ForeignKey(
                        name: "FK__blocks__blocked___55009F39",
                        column: x => x.blocked_id,
                        principalTable: "users",
                        principalColumn: "user_id");
                    table.ForeignKey(
                        name: "FK__blocks__blocker___540C7B00",
                        column: x => x.blocker_id,
                        principalTable: "users",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "boost_sessions",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    activated_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    duration_seconds = table.Column<int>(type: "int", nullable: true),
                    consumed = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    source = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__boost_se__3213E83F3CAFAE18", x => x.id);
                    table.ForeignKey(
                        name: "FK__boost_ses__user___0880433F",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "boosts",
                columns: table => new
                {
                    boost_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    started_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    expires_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    boost_type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    metadata = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__boosts__F709BD14A4627334", x => x.boost_id);
                    table.ForeignKey(
                        name: "FK__boosts__user_id__04AFB25B",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "daily_user_metrics",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    metric_date = table.Column<DateOnly>(type: "date", nullable: true),
                    swipes_sent = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    swipes_received = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    matches_created = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    messages_sent = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    logins = table.Column<int>(type: "int", nullable: true, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__daily_us__3213E83FFA7D6F41", x => x.id);
                    table.ForeignKey(
                        name: "FK__daily_use__user___24285DB4",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "device_fingerprints",
                columns: table => new
                {
                    fingerprint_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fingerprint_hash = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    first_seen_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    last_seen_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__device_f__0695674677BB9D7A", x => x.fingerprint_id);
                    table.ForeignKey(
                        name: "FK__device_fi__user___4959E263",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "email_logs",
                columns: table => new
                {
                    email_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    to_address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    subject = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    body_snippet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sent_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    provider_response = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__email_lo__3FEF87660E08C44E", x => x.email_id);
                    table.ForeignKey(
                        name: "FK__email_log__user___4E1E9780",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "feature_events",
                columns: table => new
                {
                    event_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    feature_key = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    context = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    occurred_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__feature___2370F727F396B1B9", x => x.event_id);
                    table.ForeignKey(
                        name: "FK__feature_e__user___2BC97F7C",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "locations",
                columns: table => new
                {
                    location_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    latitude = table.Column<double>(type: "float", nullable: true),
                    longitude = table.Column<double>(type: "float", nullable: true),
                    accuracy_meters = table.Column<int>(type: "int", nullable: true),
                    recorded_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__location__771831EA3EFE9E31", x => x.location_id);
                    table.ForeignKey(
                        name: "FK_locations_users",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "login_attempts",
                columns: table => new
                {
                    attempt_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    attempted_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    ip_address = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    user_agent = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    was_successful = table.Column<bool>(type: "bit", nullable: true),
                    failure_reason = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__login_at__5621F949F402D3A6", x => x.attempt_id);
                    table.ForeignKey(
                        name: "FK_login_attempts_users",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "match_scores",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    candidate_user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    score = table.Column<double>(type: "float", nullable: true),
                    model_version = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    computed_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__match_sc__3213E83F75DC88FB", x => x.id);
                    table.ForeignKey(
                        name: "FK__match_sco__candi__2FCF1A8A",
                        column: x => x.candidate_user_id,
                        principalTable: "users",
                        principalColumn: "user_id");
                    table.ForeignKey(
                        name: "FK__match_sco__user___2EDAF651",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "matches",
                columns: table => new
                {
                    match_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    user_a = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    user_b = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    mutual_swipe_window = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__matches__9D7FCBA35C4052A6", x => x.match_id);
                    table.ForeignKey(
                        name: "FK__matches__user_a__29221CFB",
                        column: x => x.user_a,
                        principalTable: "users",
                        principalColumn: "user_id");
                    table.ForeignKey(
                        name: "FK__matches__user_b__2A164134",
                        column: x => x.user_b,
                        principalTable: "users",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "media_files",
                columns: table => new
                {
                    media_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    owner_user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    file_name = table.Column<string>(type: "varchar(1024)", unicode: false, maxLength: 1024, nullable: true),
                    mime_type = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    storage_key = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    size_bytes = table.Column<long>(type: "bigint", nullable: true),
                    metadata = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__media_fi__D0A840F4DEAAA6D9", x => x.media_id);
                    table.ForeignKey(
                        name: "FK_media_files_users",
                        column: x => x.owner_user_id,
                        principalTable: "users",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "moderation_notes",
                columns: table => new
                {
                    note_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    admin_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__moderati__CEDD0FA48813711E", x => x.note_id);
                    table.ForeignKey(
                        name: "FK__moderatio__user___2057CCD0",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "notifications",
                columns: table => new
                {
                    notification_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    body = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    payload = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_read = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    created_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__notifica__E059842F51D92713", x => x.notification_id);
                    table.ForeignKey(
                        name: "FK__notificat__user___0E391C95",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "password_resets",
                columns: table => new
                {
                    reset_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    reset_token = table.Column<string>(type: "varchar(512)", unicode: false, maxLength: 512, nullable: true),
                    requested_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    used_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    expires_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__password__40FB05204707803C", x => x.reset_id);
                    table.ForeignKey(
                        name: "FK_password_resets_users",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "push_tokens",
                columns: table => new
                {
                    token_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    platform = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    token = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    device_model = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    last_seen_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__push_tok__CB3C9E1731E47540", x => x.token_id);
                    table.ForeignKey(
                        name: "FK__push_toke__user___15DA3E5D",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "rate_limits",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    key = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    limit_count = table.Column<int>(type: "int", nullable: true),
                    window_seconds = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__rate_lim__3213E83F077AF42B", x => x.id);
                    table.ForeignKey(
                        name: "FK__rate_limi__user___4589517F",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "sms_logs",
                columns: table => new
                {
                    sms_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    to_number = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    message_snippet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sent_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    provider_response = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__sms_logs__72F6EB0E2B2ECA2C", x => x.sms_id);
                    table.ForeignKey(
                        name: "FK__sms_logs__user_i__50FB042B",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "subscriptions",
                columns: table => new
                {
                    subscription_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    plan_id = table.Column<int>(type: "int", nullable: false),
                    started_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    expires_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    auto_renew = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    provider_subscription_id = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__subscrip__863A7EC186F0AAB9", x => x.subscription_id);
                    table.ForeignKey(
                        name: "FK__subscript__plan___73852659",
                        column: x => x.plan_id,
                        principalTable: "plans",
                        principalColumn: "plan_id");
                    table.ForeignKey(
                        name: "FK__subscript__user___72910220",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "swipes",
                columns: table => new
                {
                    swipe_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    swiper_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    swipee_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    direction = table.Column<short>(type: "smallint", nullable: true),
                    source = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    context = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__swipes__07A502BBD549FCF6", x => x.swipe_id);
                    table.ForeignKey(
                        name: "FK__swipes__swipee_i__2180FB33",
                        column: x => x.swipee_id,
                        principalTable: "users",
                        principalColumn: "user_id");
                    table.ForeignKey(
                        name: "FK__swipes__swiper_i__208CD6FA",
                        column: x => x.swiper_id,
                        principalTable: "users",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "transactions",
                columns: table => new
                {
                    transaction_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    amount_cents = table.Column<long>(type: "bigint", nullable: true),
                    currency = table.Column<string>(type: "char(3)", unicode: false, fixedLength: true, maxLength: 3, nullable: true),
                    payment_provider = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    provider_txn_id = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__transact__85C600AF2A2584F8", x => x.transaction_id);
                    table.ForeignKey(
                        name: "FK__transacti__user___793DFFAF",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "trust_scores",
                columns: table => new
                {
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    score = table.Column<double>(type: "float", nullable: true, defaultValue: 0.0),
                    last_computed_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    factors = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__trust_sc__B9BE370F0C97D55A", x => x.user_id);
                    table.ForeignKey(
                        name: "FK__trust_sco__user___671F4F74",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_flags",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    flag_type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    flag_data = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__user_fla__3213E83FA93E0300", x => x.id);
                    table.ForeignKey(
                        name: "FK__user_flag__user___634EBE90",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_interests",
                columns: table => new
                {
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    interest_id = table.Column<int>(type: "int", nullable: false),
                    added_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_interests", x => new { x.user_id, x.interest_id });
                    table.ForeignKey(
                        name: "FK_user_interests_interests",
                        column: x => x.interest_id,
                        principalTable: "interests",
                        principalColumn: "interest_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_interests_users",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_languages",
                columns: table => new
                {
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    language_id = table.Column<int>(type: "int", nullable: false),
                    fluency_level = table.Column<short>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_languages", x => new { x.user_id, x.language_id });
                    table.ForeignKey(
                        name: "FK_user_languages_languages",
                        column: x => x.language_id,
                        principalTable: "languages",
                        principalColumn: "language_id");
                    table.ForeignKey(
                        name: "FK_user_languages_users",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_photos",
                columns: table => new
                {
                    photo_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    storage_key = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: false),
                    url = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    width = table.Column<int>(type: "int", nullable: true),
                    height = table.Column<int>(type: "int", nullable: true),
                    is_primary = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    is_active = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    uploaded_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__user_pho__CB48C83D47F1B958", x => x.photo_id);
                    table.ForeignKey(
                        name: "FK_user_photos_users",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_preferences",
                columns: table => new
                {
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    min_age = table.Column<short>(type: "smallint", nullable: true, defaultValue: (short)18),
                    max_age = table.Column<short>(type: "smallint", nullable: true, defaultValue: (short)99),
                    max_distance_km = table.Column<int>(type: "int", nullable: true, defaultValue: 50),
                    preferred_gender_ids = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    preferred_relationship_ids = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    only_verified = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    updated_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__user_pre__B9BE370F38E8C3AC", x => x.user_id);
                    table.ForeignKey(
                        name: "FK__user_pref__user___5070F446",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_profiles",
                columns: table => new
                {
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    display_name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    birthdate = table.Column<DateOnly>(type: "date", nullable: true),
                    gender_id = table.Column<int>(type: "int", nullable: true),
                    about = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    city = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    country = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    height_cm = table.Column<short>(type: "smallint", nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    updated_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__user_pro__B9BE370FEB38FFD1", x => x.user_id);
                    table.ForeignKey(
                        name: "FK__user_prof__gende__48CFD27E",
                        column: x => x.gender_id,
                        principalTable: "genders",
                        principalColumn: "gender_id");
                    table.ForeignKey(
                        name: "FK__user_prof__user___47DBAE45",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_sessions",
                columns: table => new
                {
                    session_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    device_info = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    ip_address = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    expires_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    revoked_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    is_revoked = table.Column<bool>(type: "bit", nullable: true, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__user_ses__69B13FDC180D6763", x => x.session_id);
                    table.ForeignKey(
                        name: "FK_user_sessions_users",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_social_links",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    provider = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    external_user_id = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    url = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__user_soc__3213E83F80283195", x => x.id);
                    table.ForeignKey(
                        name: "FK_user_social_links_users",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_verifications",
                columns: table => new
                {
                    verification_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    method = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    status = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    payload = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    requested_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    verified_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__user_ver__24F179691350CCE9", x => x.verification_id);
                    table.ForeignKey(
                        name: "FK_user_verifications_users",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "conversations",
                columns: table => new
                {
                    conversation_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    is_match_based = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    match_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    created_by = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    is_active = table.Column<bool>(type: "bit", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__conversa__311E7E9A41874F11", x => x.conversation_id);
                    table.ForeignKey(
                        name: "FK__conversat__creat__3587F3E0",
                        column: x => x.created_by,
                        principalTable: "users",
                        principalColumn: "user_id");
                    table.ForeignKey(
                        name: "FK__conversat__match__3493CFA7",
                        column: x => x.match_id,
                        principalTable: "matches",
                        principalColumn: "match_id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "swipe_events",
                columns: table => new
                {
                    event_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    swipe_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    event_time = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    event_type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    payload = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__swipe_ev__2370F727CEAE44DC", x => x.event_id);
                    table.ForeignKey(
                        name: "FK__swipe_eve__swipe__25518C17",
                        column: x => x.swipe_id,
                        principalTable: "swipes",
                        principalColumn: "swipe_id");
                });

            migrationBuilder.CreateTable(
                name: "invoices",
                columns: table => new
                {
                    invoice_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    transaction_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    amount_cents = table.Column<long>(type: "bigint", nullable: true),
                    issued_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    paid_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    details = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__invoices__F58DFD49F5406A97", x => x.invoice_id);
                    table.ForeignKey(
                        name: "FK__invoices__transa__7D0E9093",
                        column: x => x.transaction_id,
                        principalTable: "transactions",
                        principalColumn: "transaction_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__invoices__user_i__7E02B4CC",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "conversation_participants",
                columns: table => new
                {
                    conversation_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    joined_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    left_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    is_muted = table.Column<bool>(type: "bit", nullable: true, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__conversa__DA859DEA1599C0DC", x => new { x.conversation_id, x.user_id });
                    table.ForeignKey(
                        name: "FK__conversat__conve__3A4CA8FD",
                        column: x => x.conversation_id,
                        principalTable: "conversations",
                        principalColumn: "conversation_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__conversat__user___3B40CD36",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "messages",
                columns: table => new
                {
                    message_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    conversation_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    sender_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    body = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sent_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())"),
                    edited_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: true, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__messages__0BBF6EE60C84DBE0", x => x.message_id);
                    table.ForeignKey(
                        name: "FK__messages__conver__40058253",
                        column: x => x.conversation_id,
                        principalTable: "conversations",
                        principalColumn: "conversation_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__messages__sender__40F9A68C",
                        column: x => x.sender_id,
                        principalTable: "users",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "message_attachments",
                columns: table => new
                {
                    attachment_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    message_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    media_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    attachment_type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__message___B74DF4E23E5FE82B", x => x.attachment_id);
                    table.ForeignKey(
                        name: "FK__message_a__media__46B27FE2",
                        column: x => x.media_id,
                        principalTable: "media_files",
                        principalColumn: "media_id");
                    table.ForeignKey(
                        name: "FK__message_a__messa__45BE5BA9",
                        column: x => x.message_id,
                        principalTable: "messages",
                        principalColumn: "message_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "message_reactions",
                columns: table => new
                {
                    message_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    reactor_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    reaction = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    reacted_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__message___AB3D133EC3C3B4B3", x => new { x.message_id, x.reactor_id, x.reaction });
                    table.ForeignKey(
                        name: "FK__message_r__messa__4A8310C6",
                        column: x => x.message_id,
                        principalTable: "messages",
                        principalColumn: "message_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__message_r__react__4B7734FF",
                        column: x => x.reactor_id,
                        principalTable: "users",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "message_seen_events",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    message_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    seen_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__message___3213E83FF80D6A82", x => x.id);
                    table.ForeignKey(
                        name: "FK__message_s__messa__4F47C5E3",
                        column: x => x.message_id,
                        principalTable: "messages",
                        principalColumn: "message_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__message_s__user___503BEA1C",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "reports",
                columns: table => new
                {
                    report_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    reporter_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    reported_user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    reported_message_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    report_reason = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    evidence = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValue: "open"),
                    created_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__reports__779B7C5820F9B631", x => x.report_id);
                    table.ForeignKey(
                        name: "FK__reports__reporte__58D1301D",
                        column: x => x.reporter_id,
                        principalTable: "users",
                        principalColumn: "user_id");
                    table.ForeignKey(
                        name: "FK__reports__reporte__59C55456",
                        column: x => x.reported_user_id,
                        principalTable: "users",
                        principalColumn: "user_id");
                    table.ForeignKey(
                        name: "FK__reports__reporte__5AB9788F",
                        column: x => x.reported_message_id,
                        principalTable: "messages",
                        principalColumn: "message_id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "report_reviews",
                columns: table => new
                {
                    review_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    report_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    reviewer_admin_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    action_taken = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    reviewed_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, defaultValueSql: "(sysdatetimeoffset())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__report_r__60883D9033C7AE15", x => x.review_id);
                    table.ForeignKey(
                        name: "FK__report_re__repor__5F7E2DAC",
                        column: x => x.report_id,
                        principalTable: "reports",
                        principalColumn: "report_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_admin_actions_target_user_id",
                table: "admin_actions",
                column: "target_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_blocks_blocked_id",
                table: "blocks",
                column: "blocked_id");

            migrationBuilder.CreateIndex(
                name: "IX_boost_sessions_user_id",
                table: "boost_sessions",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_boosts_user_id",
                table: "boosts",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_conversation_participants_user_id",
                table: "conversation_participants",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_conversations_created_by",
                table: "conversations",
                column: "created_by");

            migrationBuilder.CreateIndex(
                name: "IX_conversations_match_id",
                table: "conversations",
                column: "match_id");

            migrationBuilder.CreateIndex(
                name: "IX_daily_user_metrics_user_id",
                table: "daily_user_metrics",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_device_fingerprints_user_id",
                table: "device_fingerprints",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_email_logs_user_id",
                table: "email_logs",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_feature_events_user_id",
                table: "feature_events",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "UQ__genders__DFD83CAF107A7DE4",
                table: "genders",
                column: "key",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__interest__72E12F1B1EA85E85",
                table: "interests",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_invoices_transaction_id",
                table: "invoices",
                column: "transaction_id");

            migrationBuilder.CreateIndex(
                name: "IX_invoices_user_id",
                table: "invoices",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "UQ__language__153DD4A67C4A68AC",
                table: "languages",
                column: "iso_code",
                unique: true,
                filter: "[iso_code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_locations_user_id",
                table: "locations",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_login_attempts_user_id",
                table: "login_attempts",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_match_scores_candidate_user_id",
                table: "match_scores",
                column: "candidate_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_match_scores_user_id",
                table: "match_scores",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_matches_user_a",
                table: "matches",
                column: "user_a");

            migrationBuilder.CreateIndex(
                name: "IX_matches_user_b",
                table: "matches",
                column: "user_b");

            migrationBuilder.CreateIndex(
                name: "IX_media_files_owner_user_id",
                table: "media_files",
                column: "owner_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_message_attachments_media_id",
                table: "message_attachments",
                column: "media_id");

            migrationBuilder.CreateIndex(
                name: "IX_message_attachments_message_id",
                table: "message_attachments",
                column: "message_id");

            migrationBuilder.CreateIndex(
                name: "IX_message_reactions_reactor_id",
                table: "message_reactions",
                column: "reactor_id");

            migrationBuilder.CreateIndex(
                name: "IX_message_seen_events_message_id",
                table: "message_seen_events",
                column: "message_id");

            migrationBuilder.CreateIndex(
                name: "IX_message_seen_events_user_id",
                table: "message_seen_events",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_messages_conversation_id",
                table: "messages",
                column: "conversation_id");

            migrationBuilder.CreateIndex(
                name: "IX_messages_sender_id",
                table: "messages",
                column: "sender_id");

            migrationBuilder.CreateIndex(
                name: "IX_moderation_notes_user_id",
                table: "moderation_notes",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_notifications_user_id",
                table: "notifications",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_password_resets_user_id",
                table: "password_resets",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "UQ__plans__BCFA19D71B7CFEF0",
                table: "plans",
                column: "plan_key",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_push_tokens_user_id",
                table: "push_tokens",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_rate_limits_user_id",
                table: "rate_limits",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "UQ__relation__DFD83CAF16D261A6",
                table: "relationship_types",
                column: "key",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_report_reviews_report_id",
                table: "report_reviews",
                column: "report_id");

            migrationBuilder.CreateIndex(
                name: "IX_reports_reported_message_id",
                table: "reports",
                column: "reported_message_id");

            migrationBuilder.CreateIndex(
                name: "IX_reports_reported_user_id",
                table: "reports",
                column: "reported_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_reports_reporter_id",
                table: "reports",
                column: "reporter_id");

            migrationBuilder.CreateIndex(
                name: "IX_sms_logs_user_id",
                table: "sms_logs",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_subscriptions_plan_id",
                table: "subscriptions",
                column: "plan_id");

            migrationBuilder.CreateIndex(
                name: "IX_subscriptions_user_id",
                table: "subscriptions",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_swipe_events_swipe_id",
                table: "swipe_events",
                column: "swipe_id");

            migrationBuilder.CreateIndex(
                name: "IX_swipes_swipee_id",
                table: "swipes",
                column: "swipee_id");

            migrationBuilder.CreateIndex(
                name: "IX_swipes_swiper_id",
                table: "swipes",
                column: "swiper_id");

            migrationBuilder.CreateIndex(
                name: "IX_transactions_user_id",
                table: "transactions",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_flags_user_id",
                table: "user_flags",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_interests_interest_id",
                table: "user_interests",
                column: "interest_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_languages_language_id",
                table: "user_languages",
                column: "language_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_photos_user_id",
                table: "user_photos",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_profiles_gender_id",
                table: "user_profiles",
                column: "gender_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_sessions_user_id",
                table: "user_sessions",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_social_links_user_id",
                table: "user_social_links",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_verifications_user_id",
                table: "user_verifications",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "UQ__users__AB6E616486528199",
                table: "users",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_webhook_logs_integration_id",
                table: "webhook_logs",
                column: "integration_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "admin_actions");

            migrationBuilder.DropTable(
                name: "api_keys");

            migrationBuilder.DropTable(
                name: "app_config");

            migrationBuilder.DropTable(
                name: "audit_logs");

            migrationBuilder.DropTable(
                name: "blocks");

            migrationBuilder.DropTable(
                name: "boost_sessions");

            migrationBuilder.DropTable(
                name: "boosts");

            migrationBuilder.DropTable(
                name: "conversation_participants");

            migrationBuilder.DropTable(
                name: "daily_user_metrics");

            migrationBuilder.DropTable(
                name: "device_fingerprints");

            migrationBuilder.DropTable(
                name: "discount_codes");

            migrationBuilder.DropTable(
                name: "email_logs");

            migrationBuilder.DropTable(
                name: "events");

            migrationBuilder.DropTable(
                name: "feature_events");

            migrationBuilder.DropTable(
                name: "invoices");

            migrationBuilder.DropTable(
                name: "ip_reputation");

            migrationBuilder.DropTable(
                name: "locations");

            migrationBuilder.DropTable(
                name: "login_attempts");

            migrationBuilder.DropTable(
                name: "match_scores");

            migrationBuilder.DropTable(
                name: "message_attachments");

            migrationBuilder.DropTable(
                name: "message_reactions");

            migrationBuilder.DropTable(
                name: "message_seen_events");

            migrationBuilder.DropTable(
                name: "metrics_aggregates");

            migrationBuilder.DropTable(
                name: "moderation_notes");

            migrationBuilder.DropTable(
                name: "notification_objects");

            migrationBuilder.DropTable(
                name: "notifications");

            migrationBuilder.DropTable(
                name: "password_resets");

            migrationBuilder.DropTable(
                name: "push_tokens");

            migrationBuilder.DropTable(
                name: "rate_limits");

            migrationBuilder.DropTable(
                name: "relationship_types");

            migrationBuilder.DropTable(
                name: "report_reviews");

            migrationBuilder.DropTable(
                name: "settings");

            migrationBuilder.DropTable(
                name: "sms_logs");

            migrationBuilder.DropTable(
                name: "storage_providers");

            migrationBuilder.DropTable(
                name: "subscriptions");

            migrationBuilder.DropTable(
                name: "swipe_events");

            migrationBuilder.DropTable(
                name: "trust_scores");

            migrationBuilder.DropTable(
                name: "user_flags");

            migrationBuilder.DropTable(
                name: "user_interests");

            migrationBuilder.DropTable(
                name: "user_languages");

            migrationBuilder.DropTable(
                name: "user_photos");

            migrationBuilder.DropTable(
                name: "user_preferences");

            migrationBuilder.DropTable(
                name: "user_profiles");

            migrationBuilder.DropTable(
                name: "user_sessions");

            migrationBuilder.DropTable(
                name: "user_social_links");

            migrationBuilder.DropTable(
                name: "user_verifications");

            migrationBuilder.DropTable(
                name: "webhook_logs");

            migrationBuilder.DropTable(
                name: "transactions");

            migrationBuilder.DropTable(
                name: "media_files");

            migrationBuilder.DropTable(
                name: "reports");

            migrationBuilder.DropTable(
                name: "plans");

            migrationBuilder.DropTable(
                name: "swipes");

            migrationBuilder.DropTable(
                name: "interests");

            migrationBuilder.DropTable(
                name: "languages");

            migrationBuilder.DropTable(
                name: "genders");

            migrationBuilder.DropTable(
                name: "third_party_integrations");

            migrationBuilder.DropTable(
                name: "messages");

            migrationBuilder.DropTable(
                name: "conversations");

            migrationBuilder.DropTable(
                name: "matches");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
