using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace tmss.Migrations
{
    public partial class Inital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AbpAuditLogs",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(nullable: true),
                    UserId = table.Column<long>(nullable: true),
                    ServiceName = table.Column<string>(maxLength: 256, nullable: true),
                    MethodName = table.Column<string>(maxLength: 256, nullable: true),
                    Parameters = table.Column<string>(maxLength: 1024, nullable: true),
                    ReturnValue = table.Column<string>(nullable: true),
                    ExecutionTime = table.Column<DateTime>(nullable: false),
                    ExecutionDuration = table.Column<int>(nullable: false),
                    ClientIpAddress = table.Column<string>(maxLength: 64, nullable: true),
                    ClientName = table.Column<string>(maxLength: 128, nullable: true),
                    BrowserInfo = table.Column<string>(maxLength: 512, nullable: true),
                    Exception = table.Column<string>(maxLength: 2000, nullable: true),
                    ImpersonatorUserId = table.Column<long>(nullable: true),
                    ImpersonatorTenantId = table.Column<int>(nullable: true),
                    CustomData = table.Column<string>(maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpAuditLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AbpBackgroundJobs",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    JobType = table.Column<string>(maxLength: 512, nullable: false),
                    JobArgs = table.Column<string>(maxLength: 1048576, nullable: false),
                    TryCount = table.Column<short>(nullable: false),
                    NextTryTime = table.Column<DateTime>(nullable: false),
                    LastTryTime = table.Column<DateTime>(nullable: true),
                    IsAbandoned = table.Column<bool>(nullable: false),
                    Priority = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpBackgroundJobs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AbpDynamicParameters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParameterName = table.Column<string>(nullable: true),
                    InputType = table.Column<string>(nullable: true),
                    Permission = table.Column<string>(nullable: true),
                    TenantId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpDynamicParameters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AbpEditions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 32, nullable: false),
                    DisplayName = table.Column<string>(maxLength: 64, nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    ExpiringEditionId = table.Column<int>(nullable: true),
                    DailyPrice = table.Column<decimal>(nullable: true),
                    WeeklyPrice = table.Column<decimal>(nullable: true),
                    MonthlyPrice = table.Column<decimal>(nullable: true),
                    AnnualPrice = table.Column<decimal>(nullable: true),
                    TrialDayCount = table.Column<int>(nullable: true),
                    WaitingDayAfterExpire = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpEditions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AbpEntityChangeSets",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrowserInfo = table.Column<string>(maxLength: 512, nullable: true),
                    ClientIpAddress = table.Column<string>(maxLength: 64, nullable: true),
                    ClientName = table.Column<string>(maxLength: 128, nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    ExtensionData = table.Column<string>(nullable: true),
                    ImpersonatorTenantId = table.Column<int>(nullable: true),
                    ImpersonatorUserId = table.Column<long>(nullable: true),
                    Reason = table.Column<string>(maxLength: 256, nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    UserId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpEntityChangeSets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AbpLanguages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    DisplayName = table.Column<string>(maxLength: 64, nullable: false),
                    Icon = table.Column<string>(maxLength: 128, nullable: true),
                    IsDisabled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpLanguages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AbpLanguageTexts",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    LanguageName = table.Column<string>(maxLength: 128, nullable: false),
                    Source = table.Column<string>(maxLength: 128, nullable: false),
                    Key = table.Column<string>(maxLength: 256, nullable: false),
                    Value = table.Column<string>(maxLength: 67108864, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpLanguageTexts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AbpNotifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    NotificationName = table.Column<string>(maxLength: 96, nullable: false),
                    Data = table.Column<string>(maxLength: 1048576, nullable: true),
                    DataTypeName = table.Column<string>(maxLength: 512, nullable: true),
                    EntityTypeName = table.Column<string>(maxLength: 250, nullable: true),
                    EntityTypeAssemblyQualifiedName = table.Column<string>(maxLength: 512, nullable: true),
                    EntityId = table.Column<string>(maxLength: 96, nullable: true),
                    Severity = table.Column<byte>(nullable: false),
                    UserIds = table.Column<string>(maxLength: 131072, nullable: true),
                    ExcludedUserIds = table.Column<string>(maxLength: 131072, nullable: true),
                    TenantIds = table.Column<string>(maxLength: 131072, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpNotifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AbpNotificationSubscriptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    UserId = table.Column<long>(nullable: false),
                    NotificationName = table.Column<string>(maxLength: 96, nullable: true),
                    EntityTypeName = table.Column<string>(maxLength: 250, nullable: true),
                    EntityTypeAssemblyQualifiedName = table.Column<string>(maxLength: 512, nullable: true),
                    EntityId = table.Column<string>(maxLength: 96, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpNotificationSubscriptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AbpOrganizationUnitRoles",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    RoleId = table.Column<int>(nullable: false),
                    OrganizationUnitId = table.Column<long>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpOrganizationUnitRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AbpOrganizationUnits",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    ParentId = table.Column<long>(nullable: true),
                    Code = table.Column<string>(maxLength: 95, nullable: false),
                    DisplayName = table.Column<string>(maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpOrganizationUnits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpOrganizationUnits_AbpOrganizationUnits_ParentId",
                        column: x => x.ParentId,
                        principalTable: "AbpOrganizationUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AbpPersistedGrants",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 200, nullable: false),
                    Type = table.Column<string>(maxLength: 50, nullable: false),
                    SubjectId = table.Column<string>(maxLength: 200, nullable: true),
                    ClientId = table.Column<string>(maxLength: 200, nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    Expiration = table.Column<DateTime>(nullable: true),
                    Data = table.Column<string>(maxLength: 50000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpPersistedGrants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AbpTenantNotifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    NotificationName = table.Column<string>(maxLength: 96, nullable: false),
                    Data = table.Column<string>(maxLength: 1048576, nullable: true),
                    DataTypeName = table.Column<string>(maxLength: 512, nullable: true),
                    EntityTypeName = table.Column<string>(maxLength: 250, nullable: true),
                    EntityTypeAssemblyQualifiedName = table.Column<string>(maxLength: 512, nullable: true),
                    EntityId = table.Column<string>(maxLength: 96, nullable: true),
                    Severity = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpTenantNotifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AbpUserAccounts",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    UserId = table.Column<long>(nullable: false),
                    UserLinkId = table.Column<long>(nullable: true),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    EmailAddress = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpUserAccounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AbpUserLoginAttempts",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(nullable: true),
                    TenancyName = table.Column<string>(maxLength: 64, nullable: true),
                    UserId = table.Column<long>(nullable: true),
                    UserNameOrEmailAddress = table.Column<string>(maxLength: 256, nullable: true),
                    ClientIpAddress = table.Column<string>(maxLength: 64, nullable: true),
                    ClientName = table.Column<string>(maxLength: 128, nullable: true),
                    BrowserInfo = table.Column<string>(maxLength: 512, nullable: true),
                    Result = table.Column<byte>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpUserLoginAttempts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AbpUserNotifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TenantId = table.Column<int>(nullable: true),
                    UserId = table.Column<long>(nullable: false),
                    TenantNotificationId = table.Column<Guid>(nullable: false),
                    State = table.Column<int>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpUserNotifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AbpUsers",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    AuthenticationSource = table.Column<string>(maxLength: 64, nullable: true),
                    UserName = table.Column<string>(maxLength: 256, nullable: false),
                    TenantId = table.Column<int>(nullable: true),
                    EmailAddress = table.Column<string>(maxLength: 256, nullable: false),
                    Name = table.Column<string>(maxLength: 64, nullable: false),
                    Surname = table.Column<string>(maxLength: 64, nullable: false),
                    Password = table.Column<string>(maxLength: 128, nullable: false),
                    EmailConfirmationCode = table.Column<string>(maxLength: 328, nullable: true),
                    PasswordResetCode = table.Column<string>(maxLength: 328, nullable: true),
                    LockoutEndDateUtc = table.Column<DateTime>(nullable: true),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    IsLockoutEnabled = table.Column<bool>(nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 32, nullable: true),
                    IsPhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(maxLength: 128, nullable: true),
                    IsTwoFactorEnabled = table.Column<bool>(nullable: false),
                    IsEmailConfirmed = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: false),
                    NormalizedEmailAddress = table.Column<string>(maxLength: 256, nullable: false),
                    ConcurrencyStamp = table.Column<string>(maxLength: 128, nullable: true),
                    ProfilePictureId = table.Column<Guid>(nullable: true),
                    ShouldChangePasswordOnNextLogin = table.Column<bool>(nullable: false),
                    SignInTokenExpireTimeUtc = table.Column<DateTime>(nullable: true),
                    SignInToken = table.Column<string>(nullable: true),
                    GoogleAuthenticatorKey = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpUsers_AbpUsers_CreatorUserId",
                        column: x => x.CreatorUserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AbpUsers_AbpUsers_DeleterUserId",
                        column: x => x.DeleterUserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AbpUsers_AbpUsers_LastModifierUserId",
                        column: x => x.LastModifierUserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AbpWebhookEvents",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    WebhookName = table.Column<string>(nullable: false),
                    Data = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    TenantId = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletionTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpWebhookEvents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AbpWebhookSubscriptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    WebhookUri = table.Column<string>(nullable: false),
                    Secret = table.Column<string>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Webhooks = table.Column<string>(nullable: true),
                    Headers = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpWebhookSubscriptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppBinaryObjects",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TenantId = table.Column<int>(nullable: true),
                    Bytes = table.Column<byte[]>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppBinaryObjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppChatMessages",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(nullable: false),
                    TenantId = table.Column<int>(nullable: true),
                    TargetUserId = table.Column<long>(nullable: false),
                    TargetTenantId = table.Column<int>(nullable: true),
                    Message = table.Column<string>(maxLength: 4096, nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    Side = table.Column<int>(nullable: false),
                    ReadState = table.Column<int>(nullable: false),
                    ReceiverReadState = table.Column<int>(nullable: false),
                    SharedMessageId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppChatMessages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppFriendships",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(nullable: false),
                    TenantId = table.Column<int>(nullable: true),
                    FriendUserId = table.Column<long>(nullable: false),
                    FriendTenantId = table.Column<int>(nullable: true),
                    FriendUserName = table.Column<string>(maxLength: 256, nullable: false),
                    FriendTenancyName = table.Column<string>(nullable: true),
                    FriendProfilePictureId = table.Column<Guid>(nullable: true),
                    State = table.Column<int>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppFriendships", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppInvoices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceNo = table.Column<string>(nullable: true),
                    InvoiceDate = table.Column<DateTime>(nullable: false),
                    TenantLegalName = table.Column<string>(nullable: true),
                    TenantAddress = table.Column<string>(nullable: true),
                    TenantTaxNo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppInvoices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppSubscriptionPaymentsExtensionData",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubscriptionPaymentId = table.Column<long>(nullable: false),
                    Key = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppSubscriptionPaymentsExtensionData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUserDelegations",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    SourceUserId = table.Column<long>(nullable: false),
                    TargetUserId = table.Column<long>(nullable: false),
                    TenantId = table.Column<int>(nullable: true),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserDelegations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstGenDealer",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Code = table.Column<string>(maxLength: 50, nullable: false),
                    AccountNo = table.Column<string>(maxLength: 50, nullable: true),
                    Bank = table.Column<string>(maxLength: 50, nullable: true),
                    BankAddress = table.Column<string>(maxLength: 2000, nullable: true),
                    VnName = table.Column<string>(nullable: true),
                    EnName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(maxLength: 2000, nullable: true),
                    Abbreviation = table.Column<string>(maxLength: 50, nullable: true),
                    ContactPerson = table.Column<string>(maxLength: 50, nullable: true),
                    Phone = table.Column<string>(maxLength: 25, nullable: true),
                    Status = table.Column<string>(maxLength: 50, nullable: true),
                    Fax = table.Column<string>(maxLength: 25, nullable: true),
                    Description = table.Column<string>(maxLength: 250, nullable: true),
                    IsSpecial = table.Column<string>(maxLength: 1, nullable: true),
                    Ordering = table.Column<decimal>(type: "numeric(10, 0)", nullable: true),
                    ProvinceId = table.Column<decimal>(type: "numeric(12, 0)", nullable: true),
                    DealerParentsId = table.Column<decimal>(type: "numeric(12, 0)", nullable: true),
                    DealerTypeId = table.Column<decimal>(type: "numeric(4, 0)", nullable: true),
                    TaxCode = table.Column<string>(maxLength: 50, nullable: true),
                    IsSumDealer = table.Column<string>(maxLength: 1, nullable: true),
                    DealerGroupId = table.Column<decimal>(type: "numeric(12, 0)", nullable: true),
                    BiServer = table.Column<string>(maxLength: 50, nullable: true),
                    TfsAmount = table.Column<decimal>(type: "numeric(12, 0)", nullable: true),
                    PartLeadtime = table.Column<decimal>(type: "numeric(18, 0)", nullable: true),
                    IpAddress = table.Column<string>(maxLength: 50, nullable: true),
                    Islexus = table.Column<string>(maxLength: 1, nullable: true),
                    IsSellLexusPart = table.Column<string>(maxLength: 1, nullable: true),
                    IsDlrSales = table.Column<string>(maxLength: 1, nullable: true),
                    RecievingAddress = table.Column<string>(maxLength: 2000, nullable: true),
                    DlrFooter = table.Column<string>(maxLength: 2000, nullable: true),
                    IsPrint = table.Column<string>(maxLength: 1, nullable: true),
                    PasswordSearchVin = table.Column<string>(maxLength: 50, nullable: true),
                    PortRegion = table.Column<decimal>(type: "numeric(8, 0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstGenDealer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstGenProvince",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Code = table.Column<string>(maxLength: 50, nullable: false),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    Ordering = table.Column<decimal>(type: "numeric(4, 0)", nullable: true),
                    Status = table.Column<string>(maxLength: 1, nullable: false),
                    RegionId = table.Column<decimal>(type: "numeric(8, 0)", nullable: false),
                    PopulationAmount = table.Column<decimal>(type: "numeric(12, 0)", nullable: true),
                    SquareAmount = table.Column<decimal>(type: "numeric(12, 2)", nullable: true),
                    DealerId = table.Column<decimal>(type: "numeric(8, 0)", nullable: true),
                    SubRegionId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstGenProvince", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstInvoicePlanLeadTime",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    DayAmount = table.Column<decimal>(type: "numeric(18, 0)", nullable: true),
                    Description = table.Column<string>(maxLength: 50, nullable: true),
                    HoldbackAmount = table.Column<decimal>(type: "numeric(18, 0)", nullable: true),
                    Region = table.Column<string>(maxLength: 50, nullable: true),
                    TransportationTypesId = table.Column<decimal>(type: "numeric(18, 0)", nullable: true),
                    FromDealerId = table.Column<decimal>(type: "numeric(18, 0)", nullable: true),
                    Status = table.Column<string>(maxLength: 50, nullable: true),
                    Ordering = table.Column<decimal>(type: "numeric(4, 0)", nullable: true),
                    ToDealerId = table.Column<decimal>(type: "numeric(18, 0)", nullable: false),
                    RegionId = table.Column<decimal>(type: "numeric(12, 0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstInvoicePlanLeadTime", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstSleAccessories",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 50, nullable: true),
                    UnitId = table.Column<long>(nullable: true),
                    AtyId = table.Column<long>(nullable: true),
                    Ordering = table.Column<int>(nullable: true),
                    Status = table.Column<string>(maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstSleAccessories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstSleAccessoryPackage",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Code = table.Column<string>(maxLength: 50, nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 50, nullable: true),
                    DealerId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstSleAccessoryPackage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstSleAccessoryTypes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Code = table.Column<string>(maxLength: 50, nullable: true),
                    Name = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstSleAccessoryTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstSleAction",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstSleAction", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstSleActivity",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 255, nullable: true),
                    Description = table.Column<string>(maxLength: 255, nullable: true),
                    Tenantid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstSleActivity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstSleActivityStatus",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Code = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstSleActivityStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstSleAgeRange",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Code = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstSleAgeRange", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstSleAppActivity",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Code = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstSleAppActivity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstSleAppPlace",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Code = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstSleAppPlace", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstSleArea",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Ordering = table.Column<decimal>(nullable: true),
                    YardId = table.Column<long>(nullable: false),
                    IsNoneAssignment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstSleArea", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstSleAudio",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Status = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 50, nullable: true),
                    Ordering = table.Column<decimal>(type: "numeric(4, 0)", nullable: true),
                    DealerId = table.Column<decimal>(type: "numeric(8, 0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstSleAudio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstSleBank",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    BankCode = table.Column<string>(maxLength: 50, nullable: true),
                    BankName = table.Column<string>(maxLength: 255, nullable: false),
                    Address = table.Column<string>(maxLength: 50, nullable: true),
                    BankTypeId = table.Column<decimal>(type: "numeric(4, 0)", nullable: true),
                    Status = table.Column<string>(maxLength: 1, nullable: true),
                    Ordering = table.Column<decimal>(type: "numeric(4, 0)", nullable: true),
                    DealerId = table.Column<decimal>(type: "numeric(8, 0)", nullable: true),
                    AccountNumber = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstSleBank", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstSleColorGradesProduction",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Ordering = table.Column<decimal>(type: "numeric(4, 0)", nullable: true),
                    ColorId = table.Column<decimal>(type: "numeric(8, 0)", nullable: true),
                    ProduceId = table.Column<decimal>(type: "numeric(8, 0)", nullable: true),
                    Status = table.Column<string>(maxLength: 1, nullable: true),
                    DealerId = table.Column<decimal>(type: "numeric(8, 0)", nullable: true),
                    Description = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstSleColorGradesProduction", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstSleColors",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    HexCode = table.Column<string>(nullable: true),
                    VnName = table.Column<string>(nullable: true),
                    EnName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Ordering = table.Column<decimal>(nullable: true),
                    OrderingRpt = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstSleColors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstSleCommissionSource",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstSleCommissionSource", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstSleContactBy",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Code = table.Column<string>(maxLength: 255, nullable: true),
                    Description = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstSleContactBy", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstSleCustomerType",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Code = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstSleCustomerType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstSleDayOff",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Year = table.Column<decimal>(type: "numeric(4, 0)", nullable: false),
                    Month = table.Column<decimal>(type: "numeric(2, 0)", nullable: false),
                    DayOff = table.Column<DateTime>(type: "date", nullable: false),
                    CalendarCode = table.Column<string>(maxLength: 25, nullable: false),
                    Status = table.Column<string>(maxLength: 1, nullable: true),
                    Ordering = table.Column<decimal>(type: "numeric(4, 0)", nullable: true),
                    DealerId = table.Column<decimal>(type: "numeric(8, 0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstSleDayOff", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstSleDealerAddressReceiveVehicle",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    DealerId = table.Column<decimal>(type: "numeric(18, 0)", nullable: true),
                    Address = table.Column<string>(maxLength: 2000, nullable: true),
                    Status = table.Column<string>(maxLength: 20, nullable: true),
                    OtherDealerId = table.Column<decimal>(type: "numeric(18, 0)", nullable: true),
                    Ordering = table.Column<decimal>(type: "numeric(4, 0)", nullable: true),
                    Priority = table.Column<decimal>(type: "numeric(4, 0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstSleDealerAddressReceiveVehicle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstSleDealerGroup",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    GroupName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Ordering = table.Column<decimal>(type: "numeric(18, 0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstSleDealerGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstSleDeliveryPlace",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Code = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstSleDeliveryPlace", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstSleExpectedDelTiming",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Code = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstSleExpectedDelTiming", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstSleFAR",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Code = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstSleFAR", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstSleFinanceSaleCampaign",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 255, nullable: true),
                    DealerId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstSleFinanceSaleCampaign", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstSleGender",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Code = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstSleGender", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstSleGradeProduction",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    ProductionCode = table.Column<string>(maxLength: 50, nullable: false),
                    EnName = table.Column<string>(maxLength: 50, nullable: true),
                    VnName = table.Column<string>(maxLength: 50, nullable: true),
                    Ordering = table.Column<decimal>(type: "numeric(4, 0)", nullable: true),
                    IsHasAudio = table.Column<string>(maxLength: 50, nullable: true),
                    CbuCkd = table.Column<string>(maxLength: 50, nullable: true),
                    ShortModel = table.Column<string>(maxLength: 50, nullable: false),
                    Wmi = table.Column<string>(maxLength: 50, nullable: true),
                    Vds = table.Column<string>(maxLength: 50, nullable: true),
                    FullModel = table.Column<string>(maxLength: 50, nullable: false),
                    Barcode = table.Column<string>(maxLength: 50, nullable: true),
                    GasolineTypeId = table.Column<decimal>(type: "numeric(12, 0)", nullable: true),
                    GradeId = table.Column<decimal>(type: "numeric(12, 0)", nullable: true),
                    FromDate = table.Column<DateTime>(type: "date", nullable: true),
                    ToDate = table.Column<DateTime>(type: "date", nullable: true),
                    IsFirmColor = table.Column<string>(maxLength: 50, nullable: true),
                    FrameNoLength = table.Column<decimal>(type: "numeric(12, 0)", nullable: true),
                    ManYear = table.Column<decimal>(type: "numeric(4, 0)", nullable: true),
                    Capacity = table.Column<decimal>(type: "numeric(12, 0)", nullable: true),
                    Length = table.Column<decimal>(type: "numeric(12, 0)", nullable: true),
                    Width = table.Column<decimal>(type: "numeric(12, 0)", nullable: true),
                    Height = table.Column<decimal>(type: "numeric(12, 0)", nullable: true),
                    Weight = table.Column<decimal>(type: "numeric(12, 0)", nullable: true),
                    TireSize = table.Column<decimal>(type: "numeric(12, 0)", nullable: true),
                    Payload = table.Column<decimal>(type: "numeric(12, 0)", nullable: true),
                    PullingWeight = table.Column<decimal>(type: "numeric(12, 0)", nullable: true),
                    SeatNoStanding = table.Column<decimal>(type: "numeric(6, 0)", nullable: true),
                    SeatNoLying = table.Column<decimal>(type: "numeric(6, 0)", nullable: true),
                    SeatNo = table.Column<decimal>(type: "numeric(12, 0)", nullable: true),
                    CaseSize = table.Column<string>(maxLength: 50, nullable: true),
                    BaseLength = table.Column<string>(maxLength: 50, nullable: true),
                    Status = table.Column<string>(maxLength: 50, nullable: true),
                    FloId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstSleGradeProduction", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstSleGrades",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    MarketingCode = table.Column<string>(maxLength: 25, nullable: false),
                    ProductionCode = table.Column<string>(maxLength: 50, nullable: true),
                    EnName = table.Column<string>(maxLength: 50, nullable: true),
                    VnName = table.Column<string>(maxLength: 50, nullable: true),
                    Determiner = table.Column<string>(maxLength: 50, nullable: true),
                    Status = table.Column<string>(maxLength: 1, nullable: true),
                    Ordering = table.Column<decimal>(type: "numeric(4, 0)", nullable: true),
                    IsHasAudio = table.Column<string>(maxLength: 1, nullable: true),
                    CbuCkd = table.Column<string>(maxLength: 50, nullable: true),
                    ShortModel = table.Column<string>(maxLength: 50, nullable: true),
                    Wmi = table.Column<string>(maxLength: 50, nullable: true),
                    Vds = table.Column<string>(maxLength: 50, nullable: true),
                    GasolineTypeId = table.Column<decimal>(type: "numeric(8, 0)", nullable: true),
                    ModelId = table.Column<decimal>(type: "numeric(8, 0)", nullable: false),
                    FloormatId = table.Column<decimal>(type: "numeric(12, 0)", nullable: true),
                    FromDate = table.Column<DateTime>(type: "date", nullable: true),
                    ToDate = table.Column<DateTime>(type: "date", nullable: true),
                    FullModel = table.Column<string>(maxLength: 50, nullable: true),
                    Barcode = table.Column<string>(maxLength: 50, nullable: true),
                    IsFirmColor = table.Column<string>(maxLength: 1, nullable: true),
                    IsHasFloormat = table.Column<string>(maxLength: 1, nullable: true),
                    PriceAmount = table.Column<decimal>(type: "numeric(18, 0)", nullable: true),
                    IsShowDeliveryPlan = table.Column<string>(maxLength: 1, nullable: true),
                    OrderPrice = table.Column<decimal>(type: "numeric(18, 0)", nullable: true),
                    DealerId = table.Column<decimal>(type: "numeric(8, 0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstSleGrades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstSleHobby",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Code = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstSleHobby", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstSleHotness",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Description = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstSleHotness", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstSleInsurance",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Code = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstSleInsurance", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstSleInsuranceCompany",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Code = table.Column<string>(maxLength: 50, nullable: false),
                    VnName = table.Column<string>(maxLength: 255, nullable: false),
                    EnName = table.Column<string>(maxLength: 50, nullable: true),
                    ContactPerson = table.Column<string>(maxLength: 50, nullable: true),
                    Address = table.Column<string>(maxLength: 2000, nullable: true),
                    Tel = table.Column<string>(maxLength: 50, nullable: true),
                    Fax = table.Column<string>(maxLength: 50, nullable: true),
                    TaxCode = table.Column<string>(maxLength: 50, nullable: true),
                    IsActive = table.Column<string>(maxLength: 1, nullable: false),
                    BankNo = table.Column<string>(maxLength: 50, nullable: true),
                    Status = table.Column<string>(maxLength: 50, nullable: true),
                    Ordering = table.Column<decimal>(type: "numeric(4, 0)", nullable: true),
                    DealerId = table.Column<decimal>(type: "numeric(18, 0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstSleInsuranceCompany", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstSleInsuranceDoctype",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    DlrId = table.Column<decimal>(type: "numeric(38, 0)", nullable: true),
                    DoctypeCode = table.Column<string>(maxLength: 30, nullable: true),
                    DoctypeName = table.Column<string>(maxLength: 50, nullable: true),
                    Deleteflag = table.Column<string>(maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstSleInsuranceDoctype", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstSleInsuranceEmployee",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    DlrId = table.Column<long>(nullable: true),
                    DeleteFlag = table.Column<string>(maxLength: 1, nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Tel = table.Column<string>(maxLength: 20, nullable: true),
                    InrComId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstSleInsuranceEmployee", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstSleInsuranceSaleCampaign",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 255, nullable: true),
                    DealerId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstSleInsuranceSaleCampaign", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstSleInsuranceTIProduct",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstSleInsuranceTIProduct", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstSleInsuranceType",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstSleInsuranceType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstSleInteriorColorGradesProduction",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Ordering = table.Column<decimal>(type: "numeric(4, 0)", nullable: true),
                    ColorId = table.Column<decimal>(type: "numeric(12, 0)", nullable: true),
                    ProduceId = table.Column<decimal>(type: "numeric(15, 0)", nullable: true),
                    Description = table.Column<string>(maxLength: 50, nullable: true),
                    Status = table.Column<string>(maxLength: 50, nullable: true),
                    DealerId = table.Column<decimal>(type: "numeric(18, 0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstSleInteriorColorGradesProduction", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstSleLocation",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Code = table.Column<string>(maxLength: 50, nullable: false),
                    LocationRow = table.Column<decimal>(type: "numeric(4, 0)", nullable: true),
                    Description = table.Column<string>(maxLength: 50, nullable: true),
                    AreaId = table.Column<decimal>(type: "numeric(12, 0)", nullable: true),
                    YardId = table.Column<decimal>(type: "numeric(18, 0)", nullable: false),
                    LocationColumn = table.Column<decimal>(type: "numeric(4, 0)", nullable: true),
                    Priority = table.Column<decimal>(type: "numeric(6, 0)", nullable: true),
                    Status = table.Column<string>(maxLength: 50, nullable: true),
                    Ordering = table.Column<decimal>(type: "numeric(4, 0)", nullable: true),
                    DealerId = table.Column<decimal>(type: "numeric(18, 0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstSleLocation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstSleLogisticCompany",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Code = table.Column<string>(maxLength: 50, nullable: false),
                    VnName = table.Column<string>(maxLength: 2000, nullable: false),
                    EnName = table.Column<string>(maxLength: 2000, nullable: false),
                    TaxCode = table.Column<string>(maxLength: 50, nullable: true),
                    BankNo = table.Column<string>(maxLength: 50, nullable: true),
                    Tel = table.Column<string>(maxLength: 50, nullable: true),
                    Fax = table.Column<string>(maxLength: 50, nullable: true),
                    Address = table.Column<string>(maxLength: 2000, nullable: true),
                    ContactPerson = table.Column<string>(maxLength: 2000, nullable: true),
                    Description = table.Column<string>(maxLength: 50, nullable: true),
                    OwnerType = table.Column<string>(maxLength: 50, nullable: true),
                    Status = table.Column<string>(maxLength: 50, nullable: false),
                    Ordering = table.Column<decimal>(type: "numeric(4, 0)", nullable: true),
                    DealerId = table.Column<decimal>(type: "numeric(18, 0)", nullable: true),
                    LogisticsNumTofs = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstSleLogisticCompany", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstSleLookUp",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Code = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    Status = table.Column<string>(maxLength: 1, nullable: false),
                    Description = table.Column<string>(maxLength: 255, nullable: true),
                    Ordering = table.Column<decimal>(type: "numeric(4, 0)", nullable: true),
                    Value = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstSleLookUp", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstSleMake",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(maxLength: 255, nullable: true),
                    Code = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstSleMake", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstSleMaritalStatus",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Code = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstSleMaritalStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstSleMeanTransportation",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 50, nullable: true),
                    Ordering = table.Column<decimal>(type: "numeric(4, 0)", nullable: true),
                    Status = table.Column<string>(maxLength: 1, nullable: true),
                    Day = table.Column<decimal>(type: "numeric(18, 0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstSleMeanTransportation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstSleModel",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    MarketingCode = table.Column<string>(nullable: true),
                    ProductionCode = table.Column<string>(maxLength: 50, nullable: true),
                    EnName = table.Column<string>(maxLength: 50, nullable: true),
                    VnName = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 50, nullable: true),
                    Status = table.Column<string>(maxLength: 50, nullable: false),
                    Ordering = table.Column<decimal>(type: "numeric(4, 0)", nullable: true),
                    OrderingRpt = table.Column<decimal>(type: "numeric(18, 0)", nullable: true),
                    MakeId = table.Column<decimal>(type: "numeric(18, 0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstSleModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstSleMoney",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    GradeProductionId = table.Column<decimal>(type: "numeric(8, 0)", nullable: false),
                    ColorId = table.Column<decimal>(type: "numeric(8, 0)", nullable: false),
                    InteriorColorId = table.Column<decimal>(type: "numeric(8, 0)", nullable: true),
                    PriceAmount = table.Column<long>(nullable: true),
                    OrderPriceAmount = table.Column<long>(nullable: true),
                    Status = table.Column<string>(maxLength: 1, nullable: true),
                    Ordering = table.Column<decimal>(type: "numeric(4, 0)", nullable: true),
                    CreatedBy = table.Column<decimal>(type: "numeric(8, 0)", nullable: true),
                    DealerId = table.Column<decimal>(type: "numeric(8, 0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstSleMoney", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstSleOccupation",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Code = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstSleOccupation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstSlePaymentType",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Code = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstSlePaymentType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstSlePetrol",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    QuantityAmount = table.Column<decimal>(type: "numeric(10, 2)", nullable: true),
                    Remark = table.Column<string>(maxLength: 50, nullable: true),
                    GradeProducesId = table.Column<decimal>(type: "numeric(18, 0)", nullable: false),
                    Status = table.Column<string>(maxLength: 50, nullable: true),
                    Ordering = table.Column<decimal>(type: "numeric(4, 0)", nullable: true),
                    DealerId = table.Column<decimal>(type: "numeric(18, 0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstSlePetrol", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstSlePlanDeliveryLeadtime",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    FromDealerId = table.Column<decimal>(type: "numeric(12, 0)", nullable: true),
                    ToDealerId = table.Column<decimal>(type: "numeric(12, 0)", nullable: true),
                    TransportationTypesId = table.Column<decimal>(type: "numeric(12, 0)", nullable: true),
                    DayAmount = table.Column<decimal>(type: "numeric(4, 1)", nullable: true),
                    TimeAmount = table.Column<decimal>(type: "numeric(4, 1)", nullable: true),
                    FromExceptionAmount = table.Column<decimal>(type: "numeric(4, 1)", nullable: true),
                    ToExceptionAmount = table.Column<decimal>(type: "numeric(4, 1)", nullable: true),
                    Status = table.Column<string>(maxLength: 50, nullable: true),
                    Ordering = table.Column<decimal>(type: "numeric(4, 0)", nullable: true),
                    DealerId = table.Column<decimal>(type: "numeric(18, 0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstSlePlanDeliveryLeadtime", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstSlePPMPackage",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 255, nullable: true),
                    DealerId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstSlePPMPackage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstSlePromotion",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Code = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstSlePromotion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstSlePurpose",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Code = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstSlePurpose", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstSleReasonOfChanges",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Code = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstSleReasonOfChanges", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstSleReasonofLost",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Code = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 255, nullable: true),
                    TypeId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstSleReasonofLost", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstSleReasonOfLostType",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Code = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstSleReasonOfLostType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstSleReasonOfNA",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    Code = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstSleReasonOfNA", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstSleReference",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Code = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstSleReference", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstSleRelationship",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Code = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstSleRelationship", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstSleRoute",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Code = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstSleRoute", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstSleSalesPerson",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Tenantid = table.Column<int>(nullable: false),
                    SaleManagerId = table.Column<long>(nullable: true),
                    UserId = table.Column<long>(nullable: true),
                    SaleTeamId = table.Column<decimal>(type: "numeric(18, 0)", nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    Birthday = table.Column<DateTime>(nullable: true),
                    Position = table.Column<string>(nullable: true),
                    Abbreviation = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Ordering = table.Column<decimal>(type: "numeric(18, 0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstSleSalesPerson", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstSleSalesStage",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Code = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstSleSalesStage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstSleSalesTeam",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    SalesGroupId = table.Column<decimal>(type: "numeric(18, 0)", nullable: true),
                    TeamName = table.Column<string>(maxLength: 255, nullable: true),
                    Ordering = table.Column<decimal>(type: "numeric(18, 0)", nullable: true),
                    Status = table.Column<string>(maxLength: 1, nullable: true),
                    ManagerName = table.Column<string>(maxLength: 100, nullable: true),
                    Description = table.Column<string>(maxLength: 255, nullable: true),
                    ReportName = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstSleSalesTeam", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstSleSocialChannel",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Code = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstSleSocialChannel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstSleSource",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Code = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstSleSource", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstSleSourceOfInfo",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Code = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstSleSourceOfInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstSleSupporter",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    FullName = table.Column<string>(maxLength: 255, nullable: true),
                    Position = table.Column<string>(maxLength: 255, nullable: true),
                    GenderId = table.Column<int>(nullable: false),
                    Dealerid = table.Column<int>(nullable: false),
                    Email = table.Column<string>(maxLength: 255, nullable: true),
                    Phone = table.Column<string>(maxLength: 100, nullable: true),
                    Description = table.Column<string>(maxLength: 2000, nullable: true),
                    Tenantid = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstSleSupporter", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstSleTestDrivePlace",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 255, nullable: true),
                    Description = table.Column<string>(maxLength: 255, nullable: true),
                    DealerId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstSleTestDrivePlace", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstSleTestDriveRoute",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 255, nullable: true),
                    Description = table.Column<string>(maxLength: 255, nullable: true),
                    DealerId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstSleTestDriveRoute", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstSleTestDriveStall",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 255, nullable: true),
                    Description = table.Column<string>(maxLength: 255, nullable: true),
                    DealerId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstSleTestDriveStall", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstSleTestDriveVehicle",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 255, nullable: true),
                    DealerId = table.Column<long>(nullable: true),
                    ModelId = table.Column<long>(nullable: true),
                    GradeId = table.Column<long>(nullable: true),
                    ColorId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstSleTestDriveVehicle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstSleTFSProduct",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Code = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstSleTFSProduct", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstSleTransportationType",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 50, nullable: true),
                    MeanTransportationId = table.Column<decimal>(type: "numeric(8, 0)", nullable: false),
                    Status = table.Column<string>(maxLength: 1, nullable: false),
                    Ordering = table.Column<decimal>(type: "numeric(4, 0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstSleTransportationType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstSleTripRequest",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstSleTripRequest", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstSleTruck",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    RegisterNo = table.Column<string>(maxLength: 20, nullable: false),
                    DriverName = table.Column<string>(maxLength: 50, nullable: true),
                    DriverPhone = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 50, nullable: true),
                    LogisticCompanyId = table.Column<decimal>(type: "numeric(8, 0)", nullable: false),
                    TransportationTypeId = table.Column<decimal>(type: "numeric(8, 0)", nullable: false),
                    Status = table.Column<string>(maxLength: 1, nullable: false),
                    Ordering = table.Column<decimal>(type: "numeric(4, 0)", nullable: true),
                    ProductionYear = table.Column<decimal>(type: "numeric(4, 0)", nullable: true),
                    DealerId = table.Column<decimal>(type: "numeric(8, 0)", nullable: true),
                    OwnerType = table.Column<string>(maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstSleTruck", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstSleUnit",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    VnName = table.Column<string>(maxLength: 50, nullable: true),
                    EnName = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstSleUnit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstSleVehiclePrice",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    GradeProductionId = table.Column<decimal>(type: "numeric(8, 0)", nullable: true),
                    ColorId = table.Column<decimal>(type: "numeric(8, 0)", nullable: true),
                    InteriorColorId = table.Column<decimal>(type: "numeric(8, 0)", nullable: true),
                    PriceAmount = table.Column<long>(nullable: true),
                    OrderPriceAmount = table.Column<long>(nullable: true),
                    Ordering = table.Column<decimal>(type: "numeric(4, 0)", nullable: true),
                    Status = table.Column<string>(maxLength: 1, nullable: true),
                    DealerId = table.Column<decimal>(type: "numeric(8, 0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstSleVehiclePrice", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstSleYard",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Code = table.Column<string>(maxLength: 50, nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Address = table.Column<string>(maxLength: 255, nullable: true),
                    Status = table.Column<string>(maxLength: 1, nullable: false),
                    Ordering = table.Column<decimal>(type: "numeric(4, 0)", nullable: true),
                    YardLocationId = table.Column<decimal>(type: "numeric(4, 0)", nullable: false),
                    Description = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstSleYard", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalesContract",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    DealerId = table.Column<decimal>(nullable: true),
                    ContractNo = table.Column<string>(maxLength: 50, nullable: false),
                    ContractType = table.Column<string>(maxLength: 10, nullable: true),
                    WodDate = table.Column<DateTime>(type: "date", nullable: true),
                    PaymentTypeId = table.Column<decimal>(type: "numeric(8, 0)", nullable: true),
                    FleetId = table.Column<decimal>(type: "numeric(18, 0)", nullable: true),
                    IsSaleForDealer = table.Column<long>(nullable: true),
                    DealerBuyId = table.Column<decimal>(type: "numeric(18, 0)", nullable: true),
                    DealerOutletId = table.Column<decimal>(type: "numeric(18, 0)", nullable: true),
                    SalesPersonId = table.Column<decimal>(type: "numeric(8, 0)", nullable: true),
                    OrderAmount = table.Column<decimal>(type: "numeric(18, 0)", nullable: true),
                    StatusId = table.Column<decimal>(type: "numeric(8, 0)", nullable: true),
                    CustomerTypeId = table.Column<decimal>(type: "numeric(8, 0)", nullable: true),
                    CustomerPurposeId = table.Column<decimal>(type: "numeric(8, 0)", nullable: true),
                    CustomerDemandId = table.Column<decimal>(type: "numeric(8, 0)", nullable: true),
                    CustomerId = table.Column<decimal>(type: "numeric(15, 0)", nullable: false),
                    CustomerLastName = table.Column<string>(maxLength: 85, nullable: true),
                    CustomerFirstName = table.Column<string>(maxLength: 85, nullable: true),
                    CustomerMidName = table.Column<string>(maxLength: 85, nullable: true),
                    CustomerTel1 = table.Column<string>(maxLength: 20, nullable: true),
                    CustomerTel2 = table.Column<string>(maxLength: 20, nullable: true),
                    CustomerAddress = table.Column<string>(maxLength: 255, nullable: true),
                    ProvinceId = table.Column<decimal>(type: "numeric(5, 0)", nullable: false),
                    DistrictId = table.Column<decimal>(type: "numeric(5, 0)", nullable: false),
                    GenderId = table.Column<decimal>(type: "numeric(5, 0)", nullable: false),
                    CustomerDOBDate = table.Column<DateTime>(type: "date", nullable: true),
                    IDCard = table.Column<decimal>(type: "numeric(15, 0)", nullable: false),
                    IsContact = table.Column<long>(nullable: true),
                    CustomerDrivingLicense = table.Column<decimal>(type: "numeric(15, 0)", nullable: false),
                    CustomerEmail = table.Column<string>(maxLength: 20, nullable: true),
                    CustomerOccupationId = table.Column<decimal>(type: "numeric(5, 0)", nullable: false),
                    CustomerIncomeRangeId = table.Column<decimal>(type: "numeric(5, 0)", nullable: false),
                    CustomerHobbyId = table.Column<decimal>(type: "numeric(5, 0)", nullable: false),
                    CustomerSocialId1Type = table.Column<string>(maxLength: 20, nullable: true),
                    CustomerSocialId1Name = table.Column<string>(maxLength: 20, nullable: true),
                    CustomerSocialId2Type = table.Column<string>(maxLength: 20, nullable: true),
                    CustomerSocialId2Name = table.Column<string>(maxLength: 20, nullable: true),
                    CustomerMaritalStatusId = table.Column<decimal>(type: "numeric(5, 0)", nullable: false),
                    CustomerFavoriteId = table.Column<decimal>(type: "numeric(5, 0)", nullable: false),
                    CustomerSpecialDate1 = table.Column<DateTime>(type: "date", nullable: true),
                    CustomerNote1 = table.Column<string>(maxLength: 255, nullable: true),
                    CustomerSpecialDate2 = table.Column<DateTime>(type: "date", nullable: true),
                    CustomerNote2 = table.Column<string>(maxLength: 255, nullable: true),
                    CustomerRemark = table.Column<string>(maxLength: 255, nullable: true),
                    ContactDrivingLicense = table.Column<decimal>(type: "numeric(15, 0)", nullable: false),
                    ContactEmail = table.Column<string>(maxLength: 20, nullable: true),
                    ContactOccupationId = table.Column<decimal>(type: "numeric(5, 0)", nullable: false),
                    ContactIncomeRangeId = table.Column<decimal>(type: "numeric(5, 0)", nullable: false),
                    ContactHobbyId = table.Column<decimal>(type: "numeric(5, 0)", nullable: false),
                    ContactSocialId1Type = table.Column<string>(maxLength: 20, nullable: true),
                    ContactSocialId1Name = table.Column<string>(maxLength: 20, nullable: true),
                    ContactSocialId2Type = table.Column<string>(maxLength: 20, nullable: true),
                    ContactSocialId2Name = table.Column<string>(maxLength: 20, nullable: true),
                    ContactMaritalStatusId = table.Column<decimal>(type: "numeric(5, 0)", nullable: false),
                    ContactFavoriteId = table.Column<decimal>(type: "numeric(5, 0)", nullable: false),
                    ContactSpecialDate1 = table.Column<DateTime>(type: "date", nullable: true),
                    ContactNote1 = table.Column<string>(maxLength: 255, nullable: true),
                    ContactSpecialDate2 = table.Column<DateTime>(type: "date", nullable: true),
                    ContactNote2 = table.Column<string>(maxLength: 255, nullable: true),
                    ContactRemark = table.Column<string>(maxLength: 255, nullable: true),
                    BusinessTypeId = table.Column<decimal>(type: "numeric(5, 0)", nullable: false),
                    CompanyName = table.Column<string>(maxLength: 255, nullable: true),
                    RepresLastName = table.Column<string>(maxLength: 85, nullable: true),
                    RepresFirstName = table.Column<string>(maxLength: 85, nullable: true),
                    RepresMidName = table.Column<string>(maxLength: 85, nullable: true),
                    Title = table.Column<string>(maxLength: 85, nullable: true),
                    RoleId = table.Column<decimal>(type: "numeric(5, 0)", nullable: false),
                    TaxCode = table.Column<decimal>(type: "numeric(15, 0)", nullable: false),
                    Fax = table.Column<decimal>(type: "numeric(20, 0)", nullable: false),
                    CompanyTel = table.Column<string>(maxLength: 20, nullable: true),
                    CompanyBussinessArea = table.Column<string>(maxLength: 255, nullable: true),
                    CompanySizeId = table.Column<decimal>(type: "numeric(5, 0)", nullable: false),
                    YearlyRevenue = table.Column<decimal>(type: "numeric(15, 0)", nullable: false),
                    CompanyWebsite = table.Column<string>(maxLength: 255, nullable: true),
                    CompanySocialId1Type = table.Column<string>(maxLength: 20, nullable: true),
                    CompanySocialId1Name = table.Column<string>(maxLength: 20, nullable: true),
                    CompanySocialId2Type = table.Column<string>(maxLength: 20, nullable: true),
                    CompanySocialId2Name = table.Column<string>(maxLength: 20, nullable: true),
                    CompanyMaritalStatusId = table.Column<decimal>(type: "numeric(5, 0)", nullable: false),
                    CompanyFavoriteId = table.Column<decimal>(type: "numeric(5, 0)", nullable: false),
                    CompanySpecialDate1 = table.Column<DateTime>(type: "date", nullable: true),
                    CompanyNote1 = table.Column<string>(maxLength: 255, nullable: true),
                    CompanySpecialDate2 = table.Column<DateTime>(type: "date", nullable: true),
                    CompanyNote2 = table.Column<string>(maxLength: 255, nullable: true),
                    CompanyRemark = table.Column<string>(maxLength: 255, nullable: true),
                    ContactId = table.Column<decimal>(type: "numeric(15, 0)", nullable: false),
                    ContactLastName = table.Column<string>(maxLength: 85, nullable: true),
                    ContactFirstName = table.Column<string>(maxLength: 85, nullable: true),
                    ContactMidName = table.Column<string>(maxLength: 85, nullable: true),
                    ContactRelationshipId = table.Column<decimal>(type: "numeric(5, 0)", nullable: false),
                    ContactTel1 = table.Column<string>(maxLength: 20, nullable: true),
                    ContactTel2 = table.Column<string>(maxLength: 20, nullable: true),
                    ContactRoleId = table.Column<decimal>(type: "numeric(5, 0)", nullable: false),
                    ContactCompanyRoleId = table.Column<decimal>(type: "numeric(5, 0)", nullable: false),
                    ContactAddress = table.Column<string>(maxLength: 255, nullable: true),
                    ContactProvinceId = table.Column<decimal>(type: "numeric(5, 0)", nullable: false),
                    ContactDistrictId = table.Column<decimal>(type: "numeric(5, 0)", nullable: false),
                    ContactGenderId = table.Column<decimal>(type: "numeric(5, 0)", nullable: false),
                    ContactDOBDate = table.Column<DateTime>(type: "date", nullable: true),
                    PhotoAttachUrl = table.Column<string>(maxLength: 255, nullable: true),
                    TenantId = table.Column<int>(nullable: false),
                    BankAccount = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesContract", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalesContractDetail",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    ContractId = table.Column<decimal>(type: "numeric(15, 0)", nullable: false),
                    SalesVehicleId = table.Column<decimal>(type: "numeric(20, 0)", nullable: true),
                    OrderPrice = table.Column<decimal>(type: "numeric(12, 0)", nullable: true),
                    CommissionPrice = table.Column<decimal>(type: "numeric(12, 0)", nullable: true),
                    DiscountPrice = table.Column<decimal>(type: "numeric(12, 0)", nullable: true),
                    SalesDate = table.Column<DateTime>(type: "date", nullable: true),
                    DealerRemarkForSales = table.Column<string>(maxLength: 512, nullable: true),
                    DealerRemarkForCs = table.Column<string>(maxLength: 255, nullable: true),
                    CancelledDate = table.Column<DateTime>(type: "date", nullable: true),
                    CancelledTypeId = table.Column<decimal>(type: "numeric(6, 0)", nullable: true),
                    CancelledReason = table.Column<string>(maxLength: 512, nullable: true),
                    AudioId = table.Column<decimal>(type: "numeric(8, 0)", nullable: true),
                    Amount = table.Column<decimal>(type: "numeric(18, 0)", nullable: true),
                    TmvRemark = table.Column<string>(maxLength: 255, nullable: true),
                    BankId = table.Column<decimal>(type: "numeric(8, 0)", nullable: true),
                    CustomerContactId = table.Column<decimal>(type: "numeric(8, 0)", nullable: true),
                    ContactName = table.Column<string>(maxLength: 55, nullable: true),
                    ContactTel = table.Column<string>(maxLength: 25, nullable: true),
                    ContactAddress = table.Column<string>(maxLength: 255, nullable: true),
                    InvoiceName = table.Column<string>(maxLength: 255, nullable: true),
                    InvoiceAddress = table.Column<string>(maxLength: 255, nullable: true),
                    DeliveryDate = table.Column<DateTime>(type: "date", nullable: true),
                    DeliveryRemark = table.Column<string>(maxLength: 2500, nullable: true),
                    InvoiceNo = table.Column<string>(maxLength: 80, nullable: true),
                    InvoiceDate = table.Column<DateTime>(type: "date", nullable: true),
                    StatusId = table.Column<decimal>(type: "numeric(4, 0)", nullable: true),
                    Ordering = table.Column<decimal>(type: "numeric(4, 0)", nullable: true),
                    ContractVehicleRemark = table.Column<string>(maxLength: 500, nullable: true),
                    VehilceType = table.Column<string>(maxLength: 20, nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesContractDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalesFilter",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    FieldName = table.Column<string>(maxLength: 80, nullable: false),
                    FieldDescription = table.Column<string>(maxLength: 80, nullable: false),
                    Ordering = table.Column<decimal>(type: "numeric(4, 0)", nullable: true),
                    FormId = table.Column<string>(maxLength: 255, nullable: true),
                    Status = table.Column<string>(maxLength: 1, nullable: true),
                    DearlerId = table.Column<decimal>(type: "numeric(18, 0)", nullable: true),
                    IsDateField = table.Column<string>(maxLength: 1, nullable: true),
                    FormType = table.Column<string>(maxLength: 18, nullable: true),
                    TableDefined = table.Column<string>(nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesFilter", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalesFilterDetail",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Condition = table.Column<string>(maxLength: 20, nullable: true),
                    Value = table.Column<string>(maxLength: 50, nullable: true),
                    Connective = table.Column<string>(maxLength: 3, nullable: true),
                    UserFilterDefineId = table.Column<decimal>(type: "numeric(12, 0)", nullable: false),
                    Status = table.Column<string>(maxLength: 1, nullable: true),
                    Ordering = table.Column<decimal>(type: "numeric(4, 0)", nullable: true),
                    DealerId = table.Column<decimal>(type: "numeric(18, 0)", nullable: true),
                    FilterId = table.Column<decimal>(type: "numeric(8, 0)", nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesFilterDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalesProposal",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    DealerId = table.Column<decimal>(type: "numeric(8, 0)", nullable: false),
                    ProposalNo = table.Column<string>(maxLength: 50, nullable: true),
                    ContractType = table.Column<string>(maxLength: 10, nullable: true),
                    WodDate = table.Column<DateTime>(nullable: true),
                    PaymentTypeId = table.Column<decimal>(type: "numeric(8, 0)", nullable: false),
                    FleetId = table.Column<decimal>(type: "numeric(18, 0)", nullable: false),
                    IsSaleForDealer = table.Column<long>(nullable: false),
                    DealerBuyId = table.Column<decimal>(type: "numeric(18, 0)", nullable: false),
                    DealerOutletId = table.Column<decimal>(type: "numeric(18, 0)", nullable: false),
                    SalesPersonId = table.Column<decimal>(type: "numeric(8, 0)", nullable: false),
                    OrderAmount = table.Column<decimal>(type: "numeric(18, 0)", nullable: false),
                    StatusId = table.Column<decimal>(type: "numeric(18, 0)", nullable: false),
                    CustomerTypeId = table.Column<decimal>(type: "numeric(8, 0)", nullable: false),
                    CustomerPurposeId = table.Column<decimal>(type: "numeric(8, 0)", nullable: false),
                    CustomerDemandId = table.Column<decimal>(type: "numeric(8, 0)", nullable: false),
                    CustomerId = table.Column<decimal>(type: "numeric(15, 0)", nullable: false),
                    CustomerLastName = table.Column<string>(maxLength: 85, nullable: true),
                    CustomerFirstName = table.Column<string>(maxLength: 85, nullable: true),
                    CustomerMidName = table.Column<string>(maxLength: 85, nullable: true),
                    CustomerTel1 = table.Column<string>(maxLength: 20, nullable: true),
                    CustomerTel2 = table.Column<string>(maxLength: 20, nullable: true),
                    CustomerAddress = table.Column<string>(maxLength: 255, nullable: true),
                    ProvinceId = table.Column<decimal>(type: "numeric(5, 0)", nullable: false),
                    DistrictId = table.Column<decimal>(type: "numeric(5, 0)", nullable: false),
                    GenderId = table.Column<decimal>(type: "numeric(5, 0)", nullable: false),
                    CustomerDOBDate = table.Column<DateTime>(nullable: true),
                    IDCard = table.Column<decimal>(type: "numeric(15, 0)", nullable: false),
                    IsContact = table.Column<long>(nullable: false),
                    CustomerDrivingLicense = table.Column<decimal>(type: "numeric(15, 0)", nullable: false),
                    CustomerEmail = table.Column<string>(maxLength: 20, nullable: true),
                    CustomerOccupationId = table.Column<decimal>(type: "numeric(5, 0)", nullable: false),
                    CustomerIncomeRangeId = table.Column<decimal>(type: "numeric(5, 0)", nullable: false),
                    CustomerHobbyId = table.Column<decimal>(type: "numeric(5, 0)", nullable: false),
                    CustomerSocialId1Type = table.Column<string>(maxLength: 20, nullable: true),
                    CustomerSocialId1Name = table.Column<string>(maxLength: 20, nullable: true),
                    CustomerSocialId2Type = table.Column<string>(maxLength: 20, nullable: true),
                    CustomerSocialId2Name = table.Column<string>(maxLength: 20, nullable: true),
                    CustomerMaritalStatusId = table.Column<decimal>(type: "numeric(5, 0)", nullable: false),
                    CustomerFavoriteId = table.Column<decimal>(type: "numeric(5, 0)", nullable: false),
                    CustomerSpecialDate1 = table.Column<DateTime>(nullable: true),
                    CustomerNote1 = table.Column<string>(maxLength: 255, nullable: true),
                    CustomerSpecialDate2 = table.Column<DateTime>(nullable: true),
                    CustomerNote2 = table.Column<string>(maxLength: 255, nullable: true),
                    CustomerRemark = table.Column<string>(maxLength: 255, nullable: true),
                    ContactDrivingLicense = table.Column<decimal>(type: "numeric(15, 0)", nullable: false),
                    ContactEmail = table.Column<string>(maxLength: 20, nullable: true),
                    ContactOccupationId = table.Column<decimal>(type: "numeric(5, 0)", nullable: false),
                    ContactIncomeRangeId = table.Column<decimal>(type: "numeric(5, 0)", nullable: false),
                    ContactHobbyId = table.Column<decimal>(type: "numeric(5, 0)", nullable: false),
                    ContactSocialId1Type = table.Column<string>(maxLength: 20, nullable: true),
                    ContactSocialId1Name = table.Column<string>(maxLength: 20, nullable: true),
                    ContactSocialId2Type = table.Column<string>(maxLength: 20, nullable: true),
                    ContactSocialId2Name = table.Column<string>(maxLength: 20, nullable: true),
                    ContactMaritalStatusId = table.Column<decimal>(type: "numeric(5, 0)", nullable: false),
                    ContactFavoriteId = table.Column<decimal>(type: "numeric(5, 0)", nullable: false),
                    ContactSpecialDate1 = table.Column<DateTime>(nullable: true),
                    ContactNote1 = table.Column<string>(maxLength: 255, nullable: true),
                    ContactSpecialDate2 = table.Column<DateTime>(nullable: true),
                    ContactRemark = table.Column<string>(maxLength: 255, nullable: true),
                    BusinessTypeId = table.Column<decimal>(type: "numeric(5, 0)", nullable: false),
                    CompanyName = table.Column<string>(maxLength: 255, nullable: true),
                    RepresLastName = table.Column<string>(maxLength: 255, nullable: true),
                    RepresFirstName = table.Column<string>(maxLength: 255, nullable: true),
                    RepresMidName = table.Column<string>(maxLength: 255, nullable: true),
                    Title = table.Column<string>(maxLength: 255, nullable: true),
                    RoleId = table.Column<decimal>(type: "numeric(5, 0)", nullable: false),
                    TaxCode = table.Column<decimal>(type: "numeric(15, 0)", nullable: false),
                    Fax = table.Column<decimal>(type: "numeric(20, 0)", nullable: false),
                    CompanyTel = table.Column<string>(maxLength: 20, nullable: true),
                    CompanyBussinessArea = table.Column<string>(maxLength: 255, nullable: true),
                    CompanySizeId = table.Column<decimal>(type: "numeric(5, 0)", nullable: false),
                    YearlyRevenue = table.Column<decimal>(type: "numeric(15, 0)", nullable: false),
                    CompanyWebsite = table.Column<string>(maxLength: 255, nullable: true),
                    CompanySocialId1Type = table.Column<string>(maxLength: 20, nullable: true),
                    CompanySocialId1Name = table.Column<string>(maxLength: 20, nullable: true),
                    CompanySocialId2Type = table.Column<string>(maxLength: 20, nullable: true),
                    CompanySocialId2Name = table.Column<string>(maxLength: 20, nullable: true),
                    CompanyMaritalStatusId = table.Column<decimal>(type: "numeric(5, 0)", nullable: false),
                    CompanyFavoriteId = table.Column<decimal>(type: "numeric(5, 0)", nullable: false),
                    CompanySpecialDate1 = table.Column<DateTime>(nullable: true),
                    CompanyNote1 = table.Column<string>(maxLength: 255, nullable: true),
                    CompanySpecialDate2 = table.Column<DateTime>(nullable: true),
                    CompanyNote2 = table.Column<string>(maxLength: 255, nullable: true),
                    CompanyRemark = table.Column<string>(maxLength: 255, nullable: true),
                    ContactId = table.Column<decimal>(type: "numeric(15, 0)", nullable: false),
                    ContactLastName = table.Column<string>(maxLength: 85, nullable: true),
                    ContactFirstName = table.Column<string>(maxLength: 85, nullable: true),
                    ContactMidName = table.Column<string>(maxLength: 85, nullable: true),
                    ContactRelationshipId = table.Column<decimal>(type: "numeric(5, 0)", nullable: false),
                    ContactTel1 = table.Column<string>(maxLength: 20, nullable: true),
                    ContactTel2 = table.Column<string>(maxLength: 20, nullable: true),
                    ContactRoleId = table.Column<decimal>(type: "numeric(5, 0)", nullable: false),
                    ContactCompanyRoleId = table.Column<decimal>(type: "numeric(5, 0)", nullable: false),
                    ContactAddress = table.Column<string>(maxLength: 255, nullable: true),
                    ContactProvinceId = table.Column<decimal>(type: "numeric(5, 0)", nullable: false),
                    ContactDistrictId = table.Column<decimal>(type: "numeric(5, 0)", nullable: false),
                    ContactGenderId = table.Column<decimal>(type: "numeric(5, 0)", nullable: false),
                    ContactDOBDate = table.Column<DateTime>(nullable: true),
                    PhotoAttachUrl = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesProposal", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalesProposalAccessories",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    SalesProposalVehicleId = table.Column<decimal>(type: "numeric(18, 0)", nullable: true),
                    AccessoriesPackageId = table.Column<decimal>(type: "numeric(18, 0)", nullable: true),
                    AccessoriesId = table.Column<decimal>(type: "numeric(18, 0)", nullable: true),
                    AccessoriesUnitId = table.Column<decimal>(type: "numeric(18, 0)", nullable: true),
                    Purchase = table.Column<int>(nullable: true),
                    AccessoriesQuantity = table.Column<decimal>(type: "numeric(15, 0)", nullable: true),
                    AccessoriesPerUnitAmount = table.Column<decimal>(type: "numeric(15, 0)", nullable: true),
                    AccessoriesAmount = table.Column<decimal>(type: "numeric(15, 0)", nullable: true),
                    AccessoriesDiscount = table.Column<decimal>(type: "numeric(15, 0)", nullable: true),
                    TotalAccessoriesAmount = table.Column<decimal>(type: "numeric(15, 0)", nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesProposalAccessories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalesProposalCommission",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    SalesProposalId = table.Column<decimal>(type: "numeric(18, 0)", nullable: true),
                    SalesProposalVehicleId = table.Column<decimal>(type: "numeric(18, 0)", nullable: true),
                    CommissionAmount = table.Column<decimal>(type: "numeric(15, 0)", nullable: true),
                    AddCommissionAmount = table.Column<decimal>(type: "numeric(15, 0)", nullable: true),
                    ReceiverLastName = table.Column<string>(maxLength: 85, nullable: true),
                    ReceiverFirstName = table.Column<string>(maxLength: 85, nullable: true),
                    ReceiverMidName = table.Column<string>(maxLength: 85, nullable: true),
                    GenderId = table.Column<decimal>(type: "numeric(5, 0)", nullable: true),
                    ReceiverPhoneNo = table.Column<string>(maxLength: 20, nullable: true),
                    SourceId = table.Column<decimal>(type: "numeric(5, 0)", nullable: true),
                    ToyotaId = table.Column<decimal>(type: "numeric(15, 0)", nullable: true),
                    DealerId = table.Column<decimal>(type: "numeric(15, 0)", nullable: true),
                    ReceivePaymentTypeId = table.Column<decimal>(type: "numeric(15, 0)", nullable: true),
                    BankId = table.Column<decimal>(type: "numeric(15, 0)", nullable: true),
                    BankAccount = table.Column<decimal>(type: "numeric(20, 0)", nullable: true),
                    BankName = table.Column<string>(maxLength: 85, nullable: true),
                    TenantId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesProposalCommission", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalesProposalFuelControl",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    SalesProposalVehicleId = table.Column<decimal>(type: "numeric(18, 0)", nullable: true),
                    FuelDeliveryDate = table.Column<DateTime>(nullable: true),
                    FuelTypeId = table.Column<decimal>(type: "numeric(5, 0)", nullable: true),
                    FuelId = table.Column<decimal>(type: "numeric(15, 0)", nullable: true),
                    FuelUnitId = table.Column<decimal>(type: "numeric(15, 0)", nullable: true),
                    FuelQuantityId = table.Column<decimal>(type: "numeric(15, 0)", nullable: true),
                    StockLocation = table.Column<string>(maxLength: 155, nullable: true),
                    ReceiverName = table.Column<string>(maxLength: 155, nullable: true),
                    ReceiverPhoneNo = table.Column<string>(maxLength: 155, nullable: true),
                    ReceiverRemark = table.Column<string>(maxLength: 155, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesProposalFuelControl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalesProposalVehicle",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    ModelId = table.Column<decimal>(type: "numeric(15, 0)", nullable: true),
                    GradeId = table.Column<decimal>(type: "numeric(15, 0)", nullable: true),
                    EColorId = table.Column<decimal>(type: "numeric(15, 0)", nullable: true),
                    IColorId = table.Column<decimal>(type: "numeric(15, 0)", nullable: true),
                    VehicleTypeId = table.Column<decimal>(type: "numeric(5, 0)", nullable: true),
                    SalesVehicleId = table.Column<decimal>(type: "numeric(18, 0)", nullable: true),
                    SalesProposalId = table.Column<decimal>(type: "numeric(18, 0)", nullable: true),
                    FleetId = table.Column<decimal>(type: "numeric(15, 0)", nullable: true),
                    OrderPrice = table.Column<decimal>(type: "numeric(18, 0)", nullable: true),
                    DiscountAmount = table.Column<decimal>(type: "numeric(18, 0)", nullable: true),
                    AccessoriesPromoAmount = table.Column<decimal>(type: "numeric(18, 0)", nullable: true),
                    InsurancePromoAmount = table.Column<decimal>(type: "numeric(18, 0)", nullable: true),
                    PMPackPromoAmount = table.Column<decimal>(type: "numeric(18, 0)", nullable: true),
                    OtherPromoAmount = table.Column<decimal>(type: "numeric(18, 0)", nullable: true),
                    AccessoriesReqAmount = table.Column<decimal>(type: "numeric(18, 0)", nullable: true),
                    InsuranceReqAmount = table.Column<decimal>(type: "numeric(18, 0)", nullable: true),
                    PMPackReqAmount = table.Column<decimal>(type: "numeric(18, 0)", nullable: true),
                    OverPolicyAmount = table.Column<decimal>(type: "numeric(18, 0)", nullable: true),
                    ComissionAmount = table.Column<decimal>(type: "numeric(18, 0)", nullable: true),
                    OriginalEstDeliveryDate = table.Column<DateTime>(nullable: true),
                    ProductionYear = table.Column<decimal>(type: "numeric(5, 0)", nullable: true),
                    NewEstDeliveryDate = table.Column<DateTime>(nullable: true),
                    ReasonId = table.Column<decimal>(type: "numeric(5, 0)", nullable: true),
                    DetailReason = table.Column<string>(maxLength: 255, nullable: true),
                    DepositAmount = table.Column<decimal>(type: "numeric(18, 0)", nullable: true),
                    DepositDate = table.Column<DateTime>(nullable: true),
                    _1stPaymentAmount = table.Column<decimal>(name: "1stPaymentAmount", type: "numeric(18, 0)", nullable: true),
                    _1stPaymentDate = table.Column<DateTime>(name: "1stPaymentDate", type: "date", nullable: true),
                    _2ndPaymentAmount = table.Column<decimal>(name: "2ndPaymentAmount", type: "numeric(18, 0)", nullable: true),
                    _2ndPaymentDate = table.Column<DateTime>(name: "2ndPaymentDate", type: "date", nullable: true),
                    _3rdPaymentAmount = table.Column<decimal>(name: "3rdPaymentAmount", type: "numeric(18, 0)", nullable: true),
                    _3rdPaymentDate = table.Column<DateTime>(name: "3rdPaymentDate", type: "date", nullable: true),
                    _4thPaymentAmount = table.Column<decimal>(name: "4thPaymentAmount", type: "numeric(18, 0)", nullable: true),
                    _4thPaymentDate = table.Column<DateTime>(name: "4thPaymentDate", type: "date", nullable: true),
                    OtherServiceAmount = table.Column<decimal>(type: "numeric(18, 0)", nullable: true),
                    Remark = table.Column<string>(maxLength: 255, nullable: true),
                    SaleCampaignId = table.Column<decimal>(type: "numeric(5, 0)", nullable: true),
                    SalesDate = table.Column<DateTime>(nullable: true),
                    InvoiceNo = table.Column<string>(maxLength: 55, nullable: true),
                    DeliveryDate = table.Column<DateTime>(nullable: true),
                    DeliveryTime = table.Column<DateTime>(nullable: true),
                    DeliveryLocation = table.Column<string>(maxLength: 255, nullable: true),
                    AccessoriesAtDelivery = table.Column<string>(maxLength: 600, nullable: true),
                    GiftAtDelivery = table.Column<string>(maxLength: 600, nullable: true),
                    IsDeliveryId = table.Column<decimal>(type: "numeric(1, 0)", nullable: true),
                    IsOwnerId = table.Column<decimal>(type: "numeric(1, 0)", nullable: true),
                    DateToDelivery = table.Column<DateTime>(nullable: true),
                    PlateNumber = table.Column<string>(maxLength: 60, nullable: true),
                    VRExpiryDate = table.Column<DateTime>(nullable: true),
                    DeliveryRemark = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesProposalVehicle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalesUserFilterDefine",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    UserId = table.Column<decimal>(type: "numeric(12, 0)", nullable: false),
                    Ordering = table.Column<decimal>(type: "numeric(6, 0)", nullable: true),
                    Status = table.Column<string>(maxLength: 1, nullable: true),
                    FormId = table.Column<string>(maxLength: 255, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesUserFilterDefine", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalesVehicleAssignment",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    SalesVehicleId = table.Column<decimal>(type: "numeric(20, 0)", nullable: false),
                    SalesDealerId = table.Column<decimal>(type: "numeric(12, 0)", nullable: false),
                    DealerRequestColorId = table.Column<decimal>(type: "numeric(18, 0)", nullable: false),
                    DealerColorDeadlineDate = table.Column<DateTime>(nullable: true),
                    DealerColorDeadlineTime = table.Column<string>(nullable: true),
                    AssignmentDate = table.Column<DateTime>(nullable: true),
                    AssigmentChangeFromDealerID = table.Column<decimal>(type: "numeric(6, 0)", nullable: false),
                    AssignmentChangeRemark = table.Column<string>(maxLength: 255, nullable: true),
                    AssignmentAllocationMonthDate = table.Column<DateTime>(nullable: true),
                    AssignmentChangeDate = table.Column<DateTime>(nullable: true),
                    AssignmentPaymentDeadlineDate = table.Column<DateTime>(nullable: true),
                    PaymentInvoiceRequestDate = table.Column<DateTime>(nullable: true),
                    PaymentInvoiceNo = table.Column<string>(maxLength: 50, nullable: true),
                    PaymentBy = table.Column<string>(maxLength: 50, nullable: true),
                    PaymentActualInvoiceDate = table.Column<DateTime>(nullable: true),
                    PaymentDelayReason = table.Column<string>(maxLength: 255, nullable: true),
                    PaymentInvoiceVnAmount = table.Column<decimal>(type: "numeric(12, 0)", nullable: false),
                    PaymentInvoiceUsdAmount = table.Column<decimal>(type: "numeric(12, 2)", nullable: false),
                    PaymentTfsInvoiceVnAmount = table.Column<decimal>(type: "numeric(18, 0)", nullable: false),
                    PaymentTfsProcess = table.Column<string>(maxLength: 50, nullable: true),
                    PaymentDeferDate = table.Column<DateTime>(nullable: true),
                    PaymentFleetPrice = table.Column<decimal>(type: "numeric(12, 0)", nullable: false),
                    PaymentFleetCustomer = table.Column<string>(maxLength: 255, nullable: true),
                    PaymentSendingDate = table.Column<DateTime>(nullable: true),
                    SalesDate = table.Column<DateTime>(nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesVehicleAssignment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalesVehicleCustoms",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    SalesVehicleId = table.Column<decimal>(type: "numeric(20, 0)", nullable: false),
                    TmapInvoiceNo = table.Column<string>(maxLength: 50, nullable: true),
                    BillNo = table.Column<string>(maxLength: 50, nullable: true),
                    CustomStartPlanDate = table.Column<DateTime>(nullable: true),
                    CustomStartActualDate = table.Column<DateTime>(nullable: true),
                    CustomSheetNo = table.Column<string>(maxLength: 50, nullable: true),
                    VrCheckActualDate = table.Column<DateTime>(nullable: true),
                    VRCertificateReceiveDate = table.Column<DateTime>(nullable: true),
                    PriceConsultDate = table.Column<DateTime>(nullable: true),
                    TmvOcSignDate = table.Column<DateTime>(nullable: true),
                    CustomeOcSignDate = table.Column<DateTime>(nullable: true),
                    OriginDocumentPlanDate = table.Column<DateTime>(nullable: true),
                    CustomCompleteActualDate = table.Column<DateTime>(nullable: true),
                    LatestDocumentPlanDate = table.Column<DateTime>(nullable: true),
                    DocumentDeliveryDate = table.Column<DateTime>(nullable: true),
                    CustomActualLeadtime = table.Column<decimal>(type: "numeric(8, 0)", nullable: false),
                    VrCertificateLeadtime = table.Column<decimal>(type: "numeric(8, 0)", nullable: false),
                    CustomRemark = table.Column<string>(maxLength: 500, nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesVehicleCustoms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalesVehicleLogisticSwap",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    SalesVehicleId = table.Column<decimal>(type: "numeric(20, 0)", nullable: false),
                    DestinationId = table.Column<decimal>(type: "numeric(12, 0)", nullable: false),
                    RouteId = table.Column<decimal>(type: "numeric(12, 0)", nullable: false),
                    AssignChangeDate = table.Column<DateTime>(nullable: true),
                    TransportationCost = table.Column<decimal>(type: "numeric(15, 0)", nullable: false),
                    Reason = table.Column<string>(maxLength: 100, nullable: true),
                    DispatchPlanDate = table.Column<DateTime>(nullable: true),
                    DispatchActualDate = table.Column<DateTime>(nullable: true),
                    LogisticCompanyId = table.Column<decimal>(type: "numeric(12, 0)", nullable: false),
                    TruckTypeId = table.Column<decimal>(type: "numeric(12, 0)", nullable: false),
                    TruckRegisterNo = table.Column<string>(maxLength: 20, nullable: true),
                    DestinationArrivalPlanDate = table.Column<DateTime>(nullable: true),
                    DestinationArrivalActualDate = table.Column<DateTime>(nullable: true),
                    ArrivalDelayId = table.Column<decimal>(type: "numeric(12, 0)", nullable: false),
                    ArrivalDelayReason = table.Column<string>(maxLength: 500, nullable: true),
                    Remark = table.Column<string>(maxLength: 500, nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesVehicleLogisticSwap", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalesVehicleMaintenance",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    SalesVehicleId = table.Column<decimal>(type: "numeric(20, 0)", nullable: false),
                    MaintenanceStockDay = table.Column<decimal>(type: "numeric(5, 0)", nullable: false),
                    PlanMaintenanceDateList = table.Column<string>(nullable: true),
                    ActualMaintenanceDateList = table.Column<string>(nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesVehicleMaintenance", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalesVehiclePio",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    SalesVehicleId = table.Column<decimal>(type: "numeric(20, 0)", nullable: false),
                    PlanInstallDate = table.Column<DateTime>(nullable: true),
                    PlanInstallTime = table.Column<decimal>(type: "numeric(12, 0)", nullable: false),
                    ActualInstallDate = table.Column<DateTime>(nullable: true),
                    ActualInstallTime = table.Column<decimal>(type: "numeric(12, 0)", nullable: false),
                    BeginInstallTime = table.Column<decimal>(type: "numeric(12, 0)", nullable: false),
                    PioMember = table.Column<string>(maxLength: 100, nullable: true),
                    Floormat = table.Column<bool>(nullable: false),
                    OwnerManual = table.Column<bool>(nullable: false),
                    YardId = table.Column<decimal>(type: "numeric(12, 0)", nullable: false),
                    PackingLotId = table.Column<decimal>(type: "numeric(12, 0)", nullable: false),
                    PioPay = table.Column<string>(maxLength: 100, nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesVehiclePio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalesVehicleProduction",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    SalesVehicleId = table.Column<decimal>(type: "numeric(20, 0)", nullable: false),
                    AudioId = table.Column<decimal>(type: "numeric(18, 0)", nullable: false),
                    PaintInTime = table.Column<decimal>(type: "numeric(12, 0)", nullable: false),
                    PaintInDate = table.Column<DateTime>(nullable: true),
                    SequenceNo = table.Column<string>(maxLength: 50, nullable: true),
                    CcrLotNo = table.Column<string>(maxLength: 50, nullable: true),
                    CcrNoInLot = table.Column<string>(maxLength: 50, nullable: true),
                    TmssNo = table.Column<string>(maxLength: 255, nullable: true),
                    CcrBodyNo = table.Column<string>(maxLength: 50, nullable: true),
                    CcrAIn = table.Column<string>(maxLength: 50, nullable: true),
                    CcrAOut = table.Column<string>(maxLength: 50, nullable: true),
                    KeyCode = table.Column<string>(maxLength: 50, nullable: true),
                    QcDriverNo = table.Column<string>(maxLength: 50, nullable: true),
                    QcPassengerNo = table.Column<string>(maxLength: 50, nullable: true),
                    QcEngineNo = table.Column<string>(maxLength: 50, nullable: true),
                    QcTransmissionNo = table.Column<string>(maxLength: 50, nullable: true),
                    SideAirbagLh = table.Column<string>(maxLength: 255, nullable: true),
                    SideAirbagRh = table.Column<string>(maxLength: 255, nullable: true),
                    KneeAirbag = table.Column<string>(maxLength: 255, nullable: true),
                    QcAxleNo = table.Column<string>(maxLength: 50, nullable: true),
                    QcLineOffShift = table.Column<string>(maxLength: 1, nullable: true),
                    LineOffDate = table.Column<DateTime>(nullable: true),
                    OriginalLineOffPlanDate = table.Column<DateTime>(nullable: true),
                    OriginalLineOffPlanTime = table.Column<decimal>(type: "numeric(12, 0)", nullable: false),
                    LatestLineOffPlanDate = table.Column<DateTime>(nullable: true),
                    PdiPlanArrivalDate = table.Column<DateTime>(nullable: true),
                    PdiPlanArrivalTime = table.Column<decimal>(type: "numeric(12, 0)", nullable: false),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesVehicleProduction", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalesVehiclesDamage",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    SalesVehicleId = table.Column<decimal>(type: "numeric(20, 0)", nullable: false),
                    DamageStatusId = table.Column<decimal>(type: "numeric(12, 0)", nullable: false),
                    DamagePlace = table.Column<string>(maxLength: 255, nullable: true),
                    DamageFoundDate = table.Column<DateTime>(nullable: true),
                    DamageReasonDamageReason = table.Column<string>(maxLength: 255, nullable: true),
                    DamageRepaireDate = table.Column<DateTime>(nullable: true),
                    DamageRepaireCost = table.Column<decimal>(type: "numeric(12, 0)", nullable: false),
                    DamageInsuranceCompanyId = table.Column<decimal>(type: "numeric(12, 0)", nullable: false),
                    DamageClaimDate = table.Column<DateTime>(nullable: true),
                    DamageFinishingDate = table.Column<DateTime>(nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesVehiclesDamage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AbpDynamicParameterValues",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(nullable: false),
                    TenantId = table.Column<int>(nullable: true),
                    DynamicParameterId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpDynamicParameterValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpDynamicParameterValues_AbpDynamicParameters_DynamicParameterId",
                        column: x => x.DynamicParameterId,
                        principalTable: "AbpDynamicParameters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AbpEntityDynamicParameters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntityFullName = table.Column<string>(nullable: true),
                    DynamicParameterId = table.Column<int>(nullable: false),
                    TenantId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpEntityDynamicParameters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpEntityDynamicParameters_AbpDynamicParameters_DynamicParameterId",
                        column: x => x.DynamicParameterId,
                        principalTable: "AbpDynamicParameters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AbpFeatures",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(maxLength: 2000, nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    EditionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpFeatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpFeatures_AbpEditions_EditionId",
                        column: x => x.EditionId,
                        principalTable: "AbpEditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppSubscriptionPayments",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Gateway = table.Column<int>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    EditionId = table.Column<int>(nullable: false),
                    TenantId = table.Column<int>(nullable: false),
                    DayCount = table.Column<int>(nullable: false),
                    PaymentPeriodType = table.Column<int>(nullable: true),
                    ExternalPaymentId = table.Column<string>(nullable: true),
                    InvoiceNo = table.Column<string>(nullable: true),
                    IsRecurring = table.Column<bool>(nullable: false),
                    SuccessUrl = table.Column<string>(nullable: true),
                    ErrorUrl = table.Column<string>(nullable: true),
                    EditionPaymentType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppSubscriptionPayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppSubscriptionPayments_AbpEditions_EditionId",
                        column: x => x.EditionId,
                        principalTable: "AbpEditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AbpEntityChanges",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChangeTime = table.Column<DateTime>(nullable: false),
                    ChangeType = table.Column<byte>(nullable: false),
                    EntityChangeSetId = table.Column<long>(nullable: false),
                    EntityId = table.Column<string>(maxLength: 48, nullable: true),
                    EntityTypeFullName = table.Column<string>(maxLength: 192, nullable: true),
                    TenantId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpEntityChanges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpEntityChanges_AbpEntityChangeSets_EntityChangeSetId",
                        column: x => x.EntityChangeSetId,
                        principalTable: "AbpEntityChangeSets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AbpRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(maxLength: 32, nullable: false),
                    DisplayName = table.Column<string>(maxLength: 64, nullable: false),
                    IsStatic = table.Column<bool>(nullable: false),
                    IsDefault = table.Column<bool>(nullable: false),
                    NormalizedName = table.Column<string>(maxLength: 32, nullable: false),
                    ConcurrencyStamp = table.Column<string>(maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpRoles_AbpUsers_CreatorUserId",
                        column: x => x.CreatorUserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AbpRoles_AbpUsers_DeleterUserId",
                        column: x => x.DeleterUserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AbpRoles_AbpUsers_LastModifierUserId",
                        column: x => x.LastModifierUserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AbpSettings",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    UserId = table.Column<long>(nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpSettings_AbpUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AbpTenants",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    TenancyName = table.Column<string>(maxLength: 64, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    ConnectionString = table.Column<string>(maxLength: 1024, nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    EditionId = table.Column<int>(nullable: true),
                    SubscriptionEndDateUtc = table.Column<DateTime>(nullable: true),
                    IsInTrialPeriod = table.Column<bool>(nullable: false),
                    CustomCssId = table.Column<Guid>(nullable: true),
                    LogoId = table.Column<Guid>(nullable: true),
                    LogoFileType = table.Column<string>(maxLength: 64, nullable: true),
                    SubscriptionPaymentType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpTenants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpTenants_AbpUsers_CreatorUserId",
                        column: x => x.CreatorUserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AbpTenants_AbpUsers_DeleterUserId",
                        column: x => x.DeleterUserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AbpTenants_AbpEditions_EditionId",
                        column: x => x.EditionId,
                        principalTable: "AbpEditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AbpTenants_AbpUsers_LastModifierUserId",
                        column: x => x.LastModifierUserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AbpUserClaims",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    UserId = table.Column<long>(nullable: false),
                    ClaimType = table.Column<string>(maxLength: 256, nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpUserClaims_AbpUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AbpUserLogins",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(nullable: true),
                    UserId = table.Column<long>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpUserLogins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpUserLogins_AbpUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AbpUserOrganizationUnits",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    UserId = table.Column<long>(nullable: false),
                    OrganizationUnitId = table.Column<long>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpUserOrganizationUnits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpUserOrganizationUnits_AbpUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AbpUserRoles",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    UserId = table.Column<long>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpUserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpUserRoles_AbpUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AbpUserTokens",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(nullable: true),
                    UserId = table.Column<long>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: true),
                    Name = table.Column<string>(maxLength: 128, nullable: true),
                    Value = table.Column<string>(maxLength: 512, nullable: true),
                    ExpireDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpUserTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpUserTokens_AbpUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AbpWebhookSendAttempts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    WebhookEventId = table.Column<Guid>(nullable: false),
                    WebhookSubscriptionId = table.Column<Guid>(nullable: false),
                    Response = table.Column<string>(nullable: true),
                    ResponseStatusCode = table.Column<int>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    TenantId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpWebhookSendAttempts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpWebhookSendAttempts_AbpWebhookEvents_WebhookEventId",
                        column: x => x.WebhookEventId,
                        principalTable: "AbpWebhookEvents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MstSleDistrict",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Code = table.Column<string>(maxLength: 50, nullable: true),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    Description = table.Column<string>(maxLength: 50, nullable: true),
                    ProvinceId = table.Column<long>(nullable: true),
                    DealerId = table.Column<decimal>(type: "numeric(8, 0)", nullable: true),
                    Status = table.Column<string>(maxLength: 1, nullable: true),
                    Ordering = table.Column<decimal>(type: "numeric(4, 0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstSleDistrict", x => x.Id);

                });

            migrationBuilder.CreateTable(
                name: "MstSleAccessoryPrice",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    AccessoryId = table.Column<long>(nullable: true),
                    UnitPrice = table.Column<long>(nullable: true),
                    DealerId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstSleAccessoryPrice", x => x.Id);

                });

            migrationBuilder.CreateTable(
                name: "MstSleAccessoryPackageDetail",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    UnitId = table.Column<long>(nullable: true),
                    UnitPrice = table.Column<long>(nullable: true),
                    Quantity = table.Column<int>(nullable: true),
                    Purchase = table.Column<int>(nullable: true),
                    Discount = table.Column<long>(nullable: true),
                    AccessoryPackageId = table.Column<long>(nullable: true),
                    AccessoryId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstSleAccessoryPackageDetail", x => x.Id);

                });

            migrationBuilder.CreateTable(
                name: "SalesProposalFinance",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    SalesProposalVehicleId = table.Column<decimal>(type: "numeric(18, 0)", nullable: true),
                    IsTFS = table.Column<decimal>(type: "numeric(1, 0)", nullable: true),
                    BankId = table.Column<decimal>(type: "numeric(15, 0)", nullable: true),
                    BankBranch = table.Column<string>(maxLength: 255, nullable: true),
                    TFSProductId = table.Column<decimal>(type: "numeric(8, 0)", nullable: true),
                    Product = table.Column<string>(maxLength: 255, nullable: true),
                    BankProduct = table.Column<string>(maxLength: 255, nullable: true),
                    Term = table.Column<decimal>(type: "numeric(8, 0)", nullable: true),
                    Downpayment = table.Column<decimal>(type: "numeric(15, 0)", nullable: true),
                    LoanAmount = table.Column<decimal>(type: "numeric(15, 0)", nullable: true),
                    DownpaymentDate = table.Column<DateTime>(nullable: true),
                    DisbursementDate = table.Column<DateTime>(nullable: true),
                    MaturityDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesProposalFinance", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalesProposalInsurance",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    SalesProposalVehicleId = table.Column<decimal>(type: "numeric(18, 0)", nullable: true),
                    InsuranceId = table.Column<decimal>(type: "numeric(8, 0)", nullable: true),
                    IsTI = table.Column<decimal>(type: "numeric(1, 0)", nullable: true),
                    VehiclePrice = table.Column<decimal>(type: "numeric(15, 0)", nullable: true),
                    InsuranceQuantity = table.Column<decimal>(type: "numeric(8, 0)", nullable: true),
                    InsuranceTypeId = table.Column<decimal>(type: "numeric(8, 0)", nullable: true),
                    InsuranceTIProductId = table.Column<decimal>(type: "numeric(8, 0)", nullable: true),
                    InsuranceNoneTIProduct = table.Column<string>(maxLength: 50, nullable: true),
                    PremiumRate = table.Column<decimal>(type: "numeric(8, 0)", nullable: true),
                    PremiumFee = table.Column<decimal>(type: "numeric(15, 0)", nullable: true),
                    InsuranceDiscount = table.Column<decimal>(type: "numeric(15, 0)", nullable: true),
                    PercentDiscount = table.Column<decimal>(type: "numeric(8, 0)", nullable: true),
                    InsuranceStartDate = table.Column<DateTime>(nullable: true),
                    InsuranceExpiryDate = table.Column<DateTime>(nullable: true),
                    PolicyNo = table.Column<decimal>(type: "numeric(8, 0)", nullable: true),
                    PercentCommission = table.Column<decimal>(type: "numeric(8, 0)", nullable: true),
                    CommissionAmount = table.Column<decimal>(type: "numeric(8, 0)", nullable: true),
                    TotalInsuranceAmount = table.Column<decimal>(type: "numeric(15, 0)", nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    Purchase = table.Column<int>(nullable: true),
                    InsuranceSaleCampaignId = table.Column<long>(nullable: true),
                    InsBranch = table.Column<string>(maxLength: 255, nullable: true),
                    Note = table.Column<string>(maxLength: 255, nullable: true),
                    SaleCampaignId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesProposalInsurance", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstSleStockChecking",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    ModelId = table.Column<decimal>(type: "numeric(15, 0)", nullable: true),
                    GradeId = table.Column<decimal>(type: "numeric(15, 0)", nullable: true),
                    ColorId = table.Column<decimal>(type: "numeric(15, 0)", nullable: true),
                    OnGoingReal = table.Column<int>(nullable: true),
                    OnGoingView = table.Column<int>(nullable: true),
                    InstockReal = table.Column<int>(nullable: true),
                    InstockView = table.Column<int>(nullable: true),
                    DealerId = table.Column<int>(nullable: true),
                    Description = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstSleStockChecking", x => x.Id);

                });

            migrationBuilder.CreateTable(
                name: "SalesVehicle",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    SaleStatusId = table.Column<decimal>(type: "numeric(5, 0)", nullable: true),
                    DealerId = table.Column<decimal>(type: "numeric(12, 0)", nullable: true),
                    ModelId = table.Column<decimal>(type: "numeric(15, 0)", nullable: true),
                    GradeId = table.Column<decimal>(type: "numeric(15, 0)", nullable: true),
                    GradeProductId = table.Column<decimal>(type: "numeric(12, 0)", nullable: true),
                    FrameNo = table.Column<string>(maxLength: 100, nullable: true),
                    VinNo = table.Column<string>(maxLength: 100, nullable: true),
                    EngineNo = table.Column<string>(maxLength: 50, nullable: true),
                    EngineCode = table.Column<string>(maxLength: 10, nullable: true),
                    InternalColorId = table.Column<decimal>(type: "numeric(18, 0)", nullable: true),
                    ExternalColorId = table.Column<decimal>(type: "numeric(12, 0)", nullable: true),
                    VehicleTypeId = table.Column<decimal>(type: "numeric(5, 0)", nullable: true),
                    CBULineOfMonthDate = table.Column<DateTime>(nullable: true),
                    Remark = table.Column<string>(maxLength: 2000, nullable: true),
                    TenantId = table.Column<int>(nullable: false),
                    ViewForSalePerson = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesVehicle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalesProposalPPM",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    SalesProposalVehicleId = table.Column<decimal>(type: "numeric(18, 0)", nullable: true),
                    PPMPackId = table.Column<decimal>(type: "numeric(8, 0)", nullable: true),
                    IsPromotion = table.Column<decimal>(type: "numeric(1, 0)", nullable: true),
                    IsPurchase = table.Column<decimal>(type: "numeric(1, 0)", nullable: true),
                    KM = table.Column<decimal>(type: "numeric(15, 0)", nullable: true),
                    Term = table.Column<decimal>(type: "numeric(8, 0)", nullable: true),
                    PPMAmount = table.Column<decimal>(type: "numeric(15, 0)", nullable: true),
                    PercentPPMDiscount = table.Column<decimal>(type: "numeric(8, 0)", nullable: true),
                    TotalPPMAmount = table.Column<decimal>(type: "numeric(15, 0)", nullable: true),
                    PPMStartDate = table.Column<DateTime>(nullable: true),
                    PPMExpiryDate = table.Column<DateTime>(nullable: true),
                    Note = table.Column<string>(maxLength: 255, nullable: true),
                    TenentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesProposalPPM", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AbpEntityDynamicParameterValues",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(nullable: false),
                    EntityId = table.Column<string>(nullable: true),
                    EntityDynamicParameterId = table.Column<int>(nullable: false),
                    TenantId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpEntityDynamicParameterValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpEntityDynamicParameterValues_AbpEntityDynamicParameters_EntityDynamicParameterId",
                        column: x => x.EntityDynamicParameterId,
                        principalTable: "AbpEntityDynamicParameters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AbpEntityPropertyChanges",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntityChangeId = table.Column<long>(nullable: false),
                    NewValue = table.Column<string>(maxLength: 512, nullable: true),
                    OriginalValue = table.Column<string>(maxLength: 512, nullable: true),
                    PropertyName = table.Column<string>(maxLength: 96, nullable: true),
                    PropertyTypeFullName = table.Column<string>(maxLength: 192, nullable: true),
                    TenantId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpEntityPropertyChanges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpEntityPropertyChanges_AbpEntityChanges_EntityChangeId",
                        column: x => x.EntityChangeId,
                        principalTable: "AbpEntityChanges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AbpPermissions",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    IsGranted = table.Column<bool>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    RoleId = table.Column<int>(nullable: true),
                    UserId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpPermissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpPermissions_AbpRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AbpRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AbpPermissions_AbpUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AbpRoleClaims",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    RoleId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(maxLength: 256, nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpRoleClaims_AbpRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AbpRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalesCustomer",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    SalesPersonId = table.Column<decimal>(type: "numeric(18, 0)", nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    DealerId = table.Column<decimal>(type: "numeric(8, 0)", nullable: true),
                    SourceId = table.Column<decimal>(type: "numeric(8, 0)", nullable: true),
                    CustomerTypeId = table.Column<decimal>(type: "numeric(8, 0)", nullable: true),
                    ProvinceId = table.Column<decimal>(type: "numeric(8, 0)", nullable: true),
                    DistrictId = table.Column<decimal>(type: "numeric(8, 0)", nullable: true),
                    HotnessId = table.Column<decimal>(type: "numeric(8, 0)", nullable: true),
                    ExpectedDelTimingId = table.Column<decimal>(type: "numeric(8, 0)", nullable: true),
                    PaymentTypeId = table.Column<decimal>(type: "numeric(8, 0)", nullable: true),
                    GenderId = table.Column<decimal>(type: "numeric(8, 0)", nullable: true),
                    MaritalStatusId = table.Column<decimal>(type: "numeric(8, 0)", nullable: true),
                    OccupationId = table.Column<decimal>(type: "numeric(8, 0)", nullable: true),
                    Income = table.Column<decimal>(type: "numeric(18, 2)", nullable: true),
                    HobbyId = table.Column<decimal>(type: "numeric(8, 0)", nullable: true),
                    SourceOfInfoId = table.Column<decimal>(type: "numeric(8, 0)", nullable: true),
                    FARId = table.Column<decimal>(type: "numeric(8, 0)", nullable: true),
                    PurposeId = table.Column<decimal>(type: "numeric(8, 0)", nullable: true),
                    AgeRangeId = table.Column<decimal>(type: "numeric(8, 0)", nullable: true),
                    RelationshipId = table.Column<decimal>(type: "numeric(8, 0)", nullable: true),
                    Status = table.Column<decimal>(type: "numeric(18, 0)", nullable: false),
                    ReferenceId = table.Column<long>(type: "bigint", nullable: true),
                    CustomerName = table.Column<string>(maxLength: 255, nullable: true),
                    CustomerPermanentAddress = table.Column<string>(maxLength: 255, nullable: true),
                    CustomerTemporaryAddress = table.Column<string>(maxLength: 255, nullable: true),
                    Telephone = table.Column<string>(maxLength: 50, nullable: true),
                    TaxCode = table.Column<string>(maxLength: 50, nullable: true),
                    IdCardNo = table.Column<string>(maxLength: 50, nullable: true),
                    Fax = table.Column<string>(maxLength: 50, nullable: true),
                    Remark = table.Column<string>(maxLength: 512, nullable: true),
                    Email = table.Column<string>(maxLength: 512, nullable: true),
                    BirthDay = table.Column<DateTime>(nullable: true),
                    CompanyName = table.Column<string>(maxLength: 800, nullable: true),
                    BusinessField = table.Column<string>(maxLength: 500, nullable: true),
                    ContactName = table.Column<string>(maxLength: 255, nullable: true),
                    Details = table.Column<string>(maxLength: 255, nullable: true),
                    Owner = table.Column<string>(maxLength: 255, nullable: true),
                    CustomerLastName = table.Column<string>(maxLength: 85, nullable: true),
                    CustomerFirstName = table.Column<string>(maxLength: 85, nullable: true),
                    CustomerMidName = table.Column<string>(maxLength: 85, nullable: true),
                    CustomerTel1 = table.Column<string>(maxLength: 20, nullable: true),
                    CustomerTel2 = table.Column<string>(maxLength: 20, nullable: true),
                    BusinessTypeId = table.Column<decimal>(type: "numeric(5, 0)", nullable: true),
                    RepresLastName = table.Column<string>(maxLength: 85, nullable: true),
                    RepresFirstName = table.Column<string>(maxLength: 85, nullable: true),
                    RepresMidName = table.Column<string>(maxLength: 85, nullable: true),
                    Title = table.Column<string>(maxLength: 85, nullable: true),
                    RoleId = table.Column<decimal>(type: "numeric(5, 0)", nullable: true),
                    CompanyTel = table.Column<string>(maxLength: 20, nullable: true),
                    CompanyBussinessArea = table.Column<string>(maxLength: 255, nullable: true),
                    CompanySizeId = table.Column<decimal>(type: "numeric(5, 0)", nullable: true),
                    YearlyRevenue = table.Column<decimal>(type: "numeric(15, 0)", nullable: true),
                    CompanyWebsite = table.Column<string>(maxLength: 255, nullable: true),
                    CompanySocialId1Type = table.Column<decimal>(type: "numeric(8, 0)", nullable: true),
                    CompanySocialId1Name = table.Column<string>(maxLength: 50, nullable: true),
                    CompanySocialId2Type = table.Column<decimal>(type: "numeric(8, 0)", nullable: true),
                    CompanySocialId2Name = table.Column<string>(maxLength: 50, nullable: true),
                    CompanyMaritalStatusId = table.Column<decimal>(type: "numeric(5, 0)", nullable: true),
                    CompanyFavoriteId = table.Column<decimal>(type: "numeric(5, 0)", nullable: true),
                    CompanySpecialDate1 = table.Column<DateTime>(nullable: true),
                    CompanyNote1 = table.Column<string>(maxLength: 255, nullable: true),
                    CompanySpecialDate2 = table.Column<DateTime>(nullable: true),
                    CompanyNote2 = table.Column<string>(maxLength: 255, nullable: true),
                    CompanyRemark = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesCustomer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalesVehicleTransportation",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    SalesVehicleId = table.Column<decimal>(type: "numeric(20, 0)", nullable: true),
                    MlYardAreaId = table.Column<decimal>(type: "numeric(8, 0)", nullable: true),
                    MlYardLocationId = table.Column<decimal>(type: "numeric(8, 0)", nullable: true),
                    TransportRouteId = table.Column<decimal>(type: "numeric(12, 0)", nullable: true),
                    MlDispatchPlanDate = table.Column<DateTime>(nullable: true),
                    MlDispatchPlanTime = table.Column<decimal>(type: "numeric(12, 0)", nullable: true),
                    TemporaryLicenseDate = table.Column<DateTime>(nullable: true),
                    MlDispatchActualDate = table.Column<DateTime>(nullable: true),
                    MlDispatchActualTime = table.Column<decimal>(type: "numeric(12, 0)", nullable: true),
                    MlDelayDispatchReason = table.Column<string>(maxLength: 255, nullable: true),
                    LogisticCompanyId = table.Column<decimal>(type: "numeric(12, 0)", nullable: true),
                    InternalMeansTransportId = table.Column<decimal>(type: "numeric(18, 0)", nullable: true),
                    TruckId = table.Column<decimal>(type: "numeric(12, 0)", nullable: true),
                    TransportationTypeId = table.Column<decimal>(type: "numeric(12, 0)", nullable: true),
                    DriverName = table.Column<string>(maxLength: 2000, nullable: true),
                    TripRequestId = table.Column<decimal>(type: "numeric(18, 0)", nullable: true),
                    MlArrivalTransportCost = table.Column<decimal>(type: "numeric(12, 0)", nullable: true),
                    MlOtherDealerId = table.Column<decimal>(type: "numeric(12, 0)", nullable: true),
                    DealerDeliveryAtId = table.Column<decimal>(type: "numeric(18, 0)", nullable: true),
                    TruckLocation = table.Column<string>(maxLength: 250, nullable: true),
                    StandbyLocationPdi = table.Column<string>(maxLength: 250, nullable: true),
                    MlMovingYardDate = table.Column<DateTime>(nullable: true),
                    MlMovingYardTime = table.Column<decimal>(type: "numeric(18, 0)", nullable: true),
                    TscArrivalDate = table.Column<DateTime>(nullable: true),
                    TscArrivalTime = table.Column<decimal>(type: "numeric(12, 0)", nullable: true),
                    TscYardAreaId = table.Column<decimal>(type: "numeric(18, 0)", nullable: true),
                    TscYardLocationId = table.Column<decimal>(type: "numeric(18, 0)", nullable: true),
                    TscTransportRouteId = table.Column<decimal>(type: "numeric(12, 0)", nullable: true),
                    TscPlanDeliveryDate = table.Column<DateTime>(nullable: true),
                    TscActualDeliveryDate = table.Column<DateTime>(nullable: true),
                    TscLogisticCompanyId = table.Column<decimal>(type: "numeric(12, 0)", nullable: true),
                    TscTruckTypeId = table.Column<decimal>(type: "numeric(12, 0)", nullable: true),
                    DealerLogisticTruckTypeId = table.Column<decimal>(type: "numeric(12, 0)", nullable: true),
                    DealerTruckRegisterPlateId = table.Column<decimal>(type: "numeric(12, 0)", nullable: true),
                    TscTruckRegisterPlateId = table.Column<decimal>(type: "numeric(12, 0)", nullable: true),
                    TscTransportCost = table.Column<decimal>(type: "numeric(12, 0)", nullable: true),
                    MlArrivalActualDate = table.Column<DateTime>(nullable: true),
                    DealerPlanArrivalDate = table.Column<DateTime>(nullable: true),
                    DealerPlanArrivalTime = table.Column<decimal>(type: "numeric(12, 0)", nullable: true),
                    DealerArrivalDate = table.Column<DateTime>(nullable: false),
                    DealerArrivalTime = table.Column<decimal>(type: "numeric(12, 0)", nullable: true),
                    DealerActualArrivalDate = table.Column<DateTime>(nullable: true),
                    OriginalArrivalPlanDate = table.Column<DateTime>(nullable: true),
                    DelayReasonOriginalArrivalPlan = table.Column<string>(maxLength: 2000, nullable: true),
                    DealerPlanDispatchDate = table.Column<DateTime>(nullable: true),
                    DealerPlanDispatchTime = table.Column<decimal>(type: "numeric(12, 0)", nullable: true),
                    DealerActualDispatchDate = table.Column<DateTime>(nullable: true),
                    DealerActualDispatchTime = table.Column<string>(maxLength: 12, nullable: true),
                    DealerTransportWayId = table.Column<decimal>(type: "numeric(2, 0)", nullable: true),
                    DealerDelayDay = table.Column<decimal>(type: "numeric(4, 0)", nullable: true),
                    DealerTransportCost = table.Column<decimal>(type: "numeric(12, 0)", nullable: true),
                    PortETDDate = table.Column<DateTime>(nullable: true),
                    PdiDate = table.Column<DateTime>(nullable: true),
                    PdiTime = table.Column<decimal>(type: "numeric(12, 0)", nullable: true),
                    CbuDocumentDate = table.Column<DateTime>(nullable: true),
                    Gasoline = table.Column<decimal>(type: "numeric(12, 0)", nullable: true),
                    Diesel = table.Column<decimal>(type: "numeric(18, 0)", nullable: true),
                    DocumentArrivalDate = table.Column<DateTime>(nullable: true),
                    DocumentArrivalTime = table.Column<decimal>(type: "numeric(12, 0)", nullable: true),
                    DocumentDeliveryDate = table.Column<DateTime>(nullable: true),
                    DocumentDeliveryTime = table.Column<decimal>(type: "numeric(12, 0)", nullable: true),
                    DocumentVendorArrivalRemark = table.Column<string>(maxLength: 255, nullable: true),
                    InternalAssignDesId = table.Column<decimal>(type: "numeric(12, 0)", nullable: true),
                    DocumentSendingVendorId = table.Column<decimal>(type: "numeric(12, 0)", nullable: true),
                    PortAssignmentDate = table.Column<DateTime>(nullable: true),
                    PortDispatchPlanDate = table.Column<DateTime>(nullable: true),
                    PortDispatchActualDate = table.Column<DateTime>(nullable: true),
                    PortDispatchDelayDate = table.Column<DateTime>(nullable: true),
                    PortDispatchDelayReason = table.Column<string>(maxLength: 500, nullable: true),
                    PortTransportCost = table.Column<decimal>(type: "numeric(12, 0)", nullable: true),
                    PortTructRegisterPlate = table.Column<string>(maxLength: 50, nullable: true),
                    DestinationArrivalPlanDate = table.Column<DateTime>(nullable: true),
                    DestinationArrivalActualDate = table.Column<DateTime>(nullable: true),
                    DestinationArrivalDelayReasonId = table.Column<decimal>(type: "numeric(12, 0)", nullable: true),
                    DestinationArrivalDelayReason = table.Column<string>(maxLength: 500, nullable: true),
                    StockDayAtPort = table.Column<decimal>(type: "numeric(12, 0)", nullable: true),
                    StockFeeAtPort = table.Column<decimal>(type: "numeric(12, 0)", nullable: true),
                    DealerRemark = table.Column<string>(maxLength: 2000, nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesVehicleTransportation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalesCustomerAnniversary",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    SalesCustomerId = table.Column<long>(nullable: false),
                    AnniversaryContent = table.Column<string>(maxLength: 255, nullable: true),
                    AnniversaryDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesCustomerAnniversary", x => x.Id);

                });

            migrationBuilder.CreateTable(
                name: "SalesCustomerSocialChannel",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    SalesCustomerId = table.Column<long>(nullable: false),
                    SocialChannelId = table.Column<long>(nullable: false),
                    SocialId = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesCustomerSocialChannel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalesCustomerTransactionInfo",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    TenantId = table.Column<int>(nullable: false),
                    SalesCustomerId = table.Column<decimal>(type: "numeric(20, 0)", nullable: true),
                    SalesStageId = table.Column<decimal>(type: "numeric(20, 0)", nullable: true),
                    ActivityDate = table.Column<DateTime>(nullable: true),
                    ActivityName = table.Column<string>(maxLength: 255, nullable: true),
                    ActivityStatusId = table.Column<decimal>(type: "numeric(8, 0)", nullable: true),
                    ReasonOfLostId = table.Column<decimal>(type: "numeric(8, 0)", nullable: true),
                    DeliveryPlaceId = table.Column<decimal>(type: "numeric(8, 0)", nullable: true),
                    RouteId = table.Column<decimal>(type: "numeric(8, 0)", nullable: true),
                    SupporterId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesCustomerTransactionInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalesCustomerTransactionInfoContact",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    TenantId = table.Column<int>(nullable: false),
                    SalesCustomerId = table.Column<decimal>(type: "numeric(18, 0)", nullable: true),
                    ContactById = table.Column<decimal>(type: "numeric(18, 0)", nullable: true),
                    CurrentActionId = table.Column<decimal>(type: "numeric(18, 0)", nullable: true),
                    CurrentDate = table.Column<DateTime>(nullable: true),
                    NextActionId = table.Column<decimal>(type: "numeric(18, 0)", nullable: true),
                    NextDate = table.Column<DateTime>(nullable: true),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesCustomerTransactionInfoContact", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalesCustomerVehicleInfo",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    TenantId = table.Column<int>(nullable: false),
                    SalesCustomerId = table.Column<decimal>(type: "numeric(20, 0)", nullable: true),
                    MakeId = table.Column<decimal>(type: "numeric(15, 0)", nullable: true),
                    ModelId = table.Column<decimal>(type: "numeric(15, 0)", nullable: true),
                    GradeId = table.Column<decimal>(type: "numeric(15, 0)", nullable: true),
                    ColorId = table.Column<decimal>(type: "numeric(18, 0)", nullable: true),
                    IsFavourite = table.Column<bool>(nullable: true),
                    ReasonOfChangeId = table.Column<decimal>(type: "numeric(18, 0)", nullable: true),
                    VehicleType = table.Column<int>(nullable: true),
                    YearOfPurchaseDate = table.Column<DateTime>(nullable: true),
                    ReasonToChangeVehicle = table.Column<string>(maxLength: 255, nullable: true),
                    ReasonOfNATDId = table.Column<decimal>(type: "numeric(8, 0)", nullable: true),
                    ReasonOfNADId = table.Column<decimal>(type: "numeric(8, 0)", nullable: true),
                    ReasonOfNA1kId = table.Column<decimal>(type: "numeric(8, 0)", nullable: true),
                    ReasonOfNAFinanceId = table.Column<decimal>(type: "numeric(8, 0)", nullable: true),
                    ReasonOfNAInsuranceId = table.Column<decimal>(type: "numeric(8, 0)", nullable: true),
                    PromotionId = table.Column<decimal>(type: "numeric(8, 0)", nullable: true),
                    BankId = table.Column<decimal>(type: "numeric(8, 0)", nullable: true),
                    InsuranceId = table.Column<decimal>(type: "numeric(8, 0)", nullable: true),
                    PackageId = table.Column<decimal>(type: "numeric(8, 0)", nullable: true),
                    CustomerTypeId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesCustomerVehicleInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalesToDoList",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    ActivityId = table.Column<int>(type: "int", nullable: true),
                    StartTime = table.Column<TimeSpan>(nullable: false),
                    EndTime = table.Column<TimeSpan>(nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: true),
                    PlaceId = table.Column<int>(type: "int", nullable: true),
                    RouteId = table.Column<int>(type: "int", nullable: true),
                    CustomerComment = table.Column<string>(nullable: true),
                    StallId = table.Column<int>(type: "int", nullable: true),
                    ApptDate1K = table.Column<DateTime>(nullable: true),
                    SAName = table.Column<string>(nullable: true),
                    LoanApplication = table.Column<string>(nullable: true),
                    FinanceProduct = table.Column<string>(nullable: true),
                    Term = table.Column<string>(nullable: true),
                    MaturityDate = table.Column<DateTime>(nullable: true),
                    PurchasingDate = table.Column<DateTime>(nullable: true),
                    ExpiryDate = table.Column<DateTime>(nullable: true),
                    InsuranceProduct = table.Column<string>(nullable: true),
                    Panel = table.Column<string>(nullable: true),
                    CustomerHotnessId = table.Column<long>(nullable: true),
                    CustomerInvoiceDate = table.Column<DateTime>(nullable: true),
                    CustomerFirstName = table.Column<string>(nullable: true),
                    CustomerMiddleName = table.Column<string>(nullable: true),
                    CustomerLastName = table.Column<string>(nullable: true),
                    CustomerTel1 = table.Column<string>(nullable: true),
                    CustomerTel2 = table.Column<string>(nullable: true),
                    CustomerDOB = table.Column<DateTime>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    Remark = table.Column<string>(nullable: true),
                    ReasonOfNAId = table.Column<long>(nullable: true),
                    Date = table.Column<DateTime>(nullable: true),
                    CustomerId = table.Column<long>(nullable: true),
                    SalePersonId = table.Column<long>(nullable: false),
                    DealerId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesToDoList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalesCustomerAppointment",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    TenantId = table.Column<int>(nullable: false),
                    SalesCustomerId = table.Column<decimal>(type: "numeric(20, 0)", nullable: true),
                    SalesCustomerTransactionInfoId = table.Column<decimal>(type: "numeric(20, 0)", nullable: false),
                    ApptActivityId = table.Column<decimal>(type: "numeric(8, 0)", nullable: true),
                    ApptPlaceId = table.Column<decimal>(type: "numeric(8, 0)", nullable: true),
                    ApptDate = table.Column<DateTime>(nullable: false),
                    ApptTime = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesCustomerAppointment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalesCustomerTestDrive",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    TenantId = table.Column<int>(nullable: false),
                    SalesCustomerId = table.Column<decimal>(type: "numeric(20, 0)", nullable: false),
                    SalesCustomerTransactionInfoId = table.Column<decimal>(type: "numeric(20, 0)", nullable: false),
                    TestDriveDate = table.Column<DateTime>(nullable: true),
                    TestDriveTime = table.Column<decimal>(nullable: false),
                    SupporterId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesCustomerTestDrive", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalesCustomerManagerComment",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    TenantId = table.Column<int>(nullable: false),
                    SalesCustomerId = table.Column<decimal>(type: "numeric(20, 0)", nullable: true),
                    SalesCustomerTransactionInfoId = table.Column<decimal>(type: "numeric(20, 0)", nullable: true),
                    SalesCustomerTransactionInfoContactId = table.Column<decimal>(type: "numeric(20, 0)", nullable: true),
                    SeekContentForManager = table.Column<string>(maxLength: 1000, nullable: true),
                    SeekManagerTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesCustomerManagerComment", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AbpAuditLogs_TenantId_ExecutionDuration",
                table: "AbpAuditLogs",
                columns: new[] { "TenantId", "ExecutionDuration" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpAuditLogs_TenantId_ExecutionTime",
                table: "AbpAuditLogs",
                columns: new[] { "TenantId", "ExecutionTime" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpAuditLogs_TenantId_UserId",
                table: "AbpAuditLogs",
                columns: new[] { "TenantId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpBackgroundJobs_IsAbandoned_NextTryTime",
                table: "AbpBackgroundJobs",
                columns: new[] { "IsAbandoned", "NextTryTime" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpDynamicParameters_ParameterName_TenantId",
                table: "AbpDynamicParameters",
                columns: new[] { "ParameterName", "TenantId" },
                unique: true,
                filter: "[ParameterName] IS NOT NULL AND [TenantId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AbpDynamicParameterValues_DynamicParameterId",
                table: "AbpDynamicParameterValues",
                column: "DynamicParameterId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpEntityChanges_EntityChangeSetId",
                table: "AbpEntityChanges",
                column: "EntityChangeSetId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpEntityChanges_EntityTypeFullName_EntityId",
                table: "AbpEntityChanges",
                columns: new[] { "EntityTypeFullName", "EntityId" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpEntityChangeSets_TenantId_CreationTime",
                table: "AbpEntityChangeSets",
                columns: new[] { "TenantId", "CreationTime" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpEntityChangeSets_TenantId_Reason",
                table: "AbpEntityChangeSets",
                columns: new[] { "TenantId", "Reason" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpEntityChangeSets_TenantId_UserId",
                table: "AbpEntityChangeSets",
                columns: new[] { "TenantId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpEntityDynamicParameters_DynamicParameterId",
                table: "AbpEntityDynamicParameters",
                column: "DynamicParameterId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpEntityDynamicParameters_EntityFullName_DynamicParameterId_TenantId",
                table: "AbpEntityDynamicParameters",
                columns: new[] { "EntityFullName", "DynamicParameterId", "TenantId" },
                unique: true,
                filter: "[EntityFullName] IS NOT NULL AND [TenantId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AbpEntityDynamicParameterValues_EntityDynamicParameterId",
                table: "AbpEntityDynamicParameterValues",
                column: "EntityDynamicParameterId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpEntityPropertyChanges_EntityChangeId",
                table: "AbpEntityPropertyChanges",
                column: "EntityChangeId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpFeatures_EditionId_Name",
                table: "AbpFeatures",
                columns: new[] { "EditionId", "Name" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpFeatures_TenantId_Name",
                table: "AbpFeatures",
                columns: new[] { "TenantId", "Name" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpLanguages_TenantId_Name",
                table: "AbpLanguages",
                columns: new[] { "TenantId", "Name" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpLanguageTexts_TenantId_Source_LanguageName_Key",
                table: "AbpLanguageTexts",
                columns: new[] { "TenantId", "Source", "LanguageName", "Key" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpNotificationSubscriptions_NotificationName_EntityTypeName_EntityId_UserId",
                table: "AbpNotificationSubscriptions",
                columns: new[] { "NotificationName", "EntityTypeName", "EntityId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpNotificationSubscriptions_TenantId_NotificationName_EntityTypeName_EntityId_UserId",
                table: "AbpNotificationSubscriptions",
                columns: new[] { "TenantId", "NotificationName", "EntityTypeName", "EntityId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpOrganizationUnitRoles_TenantId_OrganizationUnitId",
                table: "AbpOrganizationUnitRoles",
                columns: new[] { "TenantId", "OrganizationUnitId" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpOrganizationUnitRoles_TenantId_RoleId",
                table: "AbpOrganizationUnitRoles",
                columns: new[] { "TenantId", "RoleId" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpOrganizationUnits_ParentId",
                table: "AbpOrganizationUnits",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpOrganizationUnits_TenantId_Code",
                table: "AbpOrganizationUnits",
                columns: new[] { "TenantId", "Code" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpPermissions_TenantId_Name",
                table: "AbpPermissions",
                columns: new[] { "TenantId", "Name" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpPermissions_RoleId",
                table: "AbpPermissions",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpPermissions_UserId",
                table: "AbpPermissions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpPersistedGrants_SubjectId_ClientId_Type",
                table: "AbpPersistedGrants",
                columns: new[] { "SubjectId", "ClientId", "Type" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpRoleClaims_RoleId",
                table: "AbpRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpRoleClaims_TenantId_ClaimType",
                table: "AbpRoleClaims",
                columns: new[] { "TenantId", "ClaimType" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpRoles_CreatorUserId",
                table: "AbpRoles",
                column: "CreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpRoles_DeleterUserId",
                table: "AbpRoles",
                column: "DeleterUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpRoles_LastModifierUserId",
                table: "AbpRoles",
                column: "LastModifierUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpRoles_TenantId_NormalizedName",
                table: "AbpRoles",
                columns: new[] { "TenantId", "NormalizedName" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpSettings_UserId",
                table: "AbpSettings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpSettings_TenantId_Name_UserId",
                table: "AbpSettings",
                columns: new[] { "TenantId", "Name", "UserId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AbpTenantNotifications_TenantId",
                table: "AbpTenantNotifications",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpTenants_CreationTime",
                table: "AbpTenants",
                column: "CreationTime");

            migrationBuilder.CreateIndex(
                name: "IX_AbpTenants_CreatorUserId",
                table: "AbpTenants",
                column: "CreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpTenants_DeleterUserId",
                table: "AbpTenants",
                column: "DeleterUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpTenants_EditionId",
                table: "AbpTenants",
                column: "EditionId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpTenants_LastModifierUserId",
                table: "AbpTenants",
                column: "LastModifierUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpTenants_SubscriptionEndDateUtc",
                table: "AbpTenants",
                column: "SubscriptionEndDateUtc");

            migrationBuilder.CreateIndex(
                name: "IX_AbpTenants_TenancyName",
                table: "AbpTenants",
                column: "TenancyName");

            migrationBuilder.CreateIndex(
                name: "IX_AbpUserAccounts_EmailAddress",
                table: "AbpUserAccounts",
                column: "EmailAddress");

            migrationBuilder.CreateIndex(
                name: "IX_AbpUserAccounts_UserName",
                table: "AbpUserAccounts",
                column: "UserName");

            migrationBuilder.CreateIndex(
                name: "IX_AbpUserAccounts_TenantId_EmailAddress",
                table: "AbpUserAccounts",
                columns: new[] { "TenantId", "EmailAddress" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpUserAccounts_TenantId_UserId",
                table: "AbpUserAccounts",
                columns: new[] { "TenantId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpUserAccounts_TenantId_UserName",
                table: "AbpUserAccounts",
                columns: new[] { "TenantId", "UserName" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpUserClaims_UserId",
                table: "AbpUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpUserClaims_TenantId_ClaimType",
                table: "AbpUserClaims",
                columns: new[] { "TenantId", "ClaimType" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpUserLoginAttempts_UserId_TenantId",
                table: "AbpUserLoginAttempts",
                columns: new[] { "UserId", "TenantId" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpUserLoginAttempts_TenancyName_UserNameOrEmailAddress_Result",
                table: "AbpUserLoginAttempts",
                columns: new[] { "TenancyName", "UserNameOrEmailAddress", "Result" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpUserLogins_UserId",
                table: "AbpUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpUserLogins_TenantId_UserId",
                table: "AbpUserLogins",
                columns: new[] { "TenantId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpUserLogins_TenantId_LoginProvider_ProviderKey",
                table: "AbpUserLogins",
                columns: new[] { "TenantId", "LoginProvider", "ProviderKey" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpUserNotifications_UserId_State_CreationTime",
                table: "AbpUserNotifications",
                columns: new[] { "UserId", "State", "CreationTime" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpUserOrganizationUnits_UserId",
                table: "AbpUserOrganizationUnits",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpUserOrganizationUnits_TenantId_OrganizationUnitId",
                table: "AbpUserOrganizationUnits",
                columns: new[] { "TenantId", "OrganizationUnitId" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpUserOrganizationUnits_TenantId_UserId",
                table: "AbpUserOrganizationUnits",
                columns: new[] { "TenantId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpUserRoles_UserId",
                table: "AbpUserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpUserRoles_TenantId_RoleId",
                table: "AbpUserRoles",
                columns: new[] { "TenantId", "RoleId" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpUserRoles_TenantId_UserId",
                table: "AbpUserRoles",
                columns: new[] { "TenantId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpUsers_CreatorUserId",
                table: "AbpUsers",
                column: "CreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpUsers_DeleterUserId",
                table: "AbpUsers",
                column: "DeleterUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpUsers_LastModifierUserId",
                table: "AbpUsers",
                column: "LastModifierUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpUsers_TenantId_NormalizedEmailAddress",
                table: "AbpUsers",
                columns: new[] { "TenantId", "NormalizedEmailAddress" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpUsers_TenantId_NormalizedUserName",
                table: "AbpUsers",
                columns: new[] { "TenantId", "NormalizedUserName" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpUserTokens_UserId",
                table: "AbpUserTokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpUserTokens_TenantId_UserId",
                table: "AbpUserTokens",
                columns: new[] { "TenantId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpWebhookSendAttempts_WebhookEventId",
                table: "AbpWebhookSendAttempts",
                column: "WebhookEventId");

            migrationBuilder.CreateIndex(
                name: "IX_AppBinaryObjects_TenantId",
                table: "AppBinaryObjects",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_AppChatMessages_TargetTenantId_TargetUserId_ReadState",
                table: "AppChatMessages",
                columns: new[] { "TargetTenantId", "TargetUserId", "ReadState" });

            migrationBuilder.CreateIndex(
                name: "IX_AppChatMessages_TargetTenantId_UserId_ReadState",
                table: "AppChatMessages",
                columns: new[] { "TargetTenantId", "UserId", "ReadState" });

            migrationBuilder.CreateIndex(
                name: "IX_AppChatMessages_TenantId_TargetUserId_ReadState",
                table: "AppChatMessages",
                columns: new[] { "TenantId", "TargetUserId", "ReadState" });

            migrationBuilder.CreateIndex(
                name: "IX_AppChatMessages_TenantId_UserId_ReadState",
                table: "AppChatMessages",
                columns: new[] { "TenantId", "UserId", "ReadState" });

            migrationBuilder.CreateIndex(
                name: "IX_AppFriendships_FriendTenantId_FriendUserId",
                table: "AppFriendships",
                columns: new[] { "FriendTenantId", "FriendUserId" });

            migrationBuilder.CreateIndex(
                name: "IX_AppFriendships_FriendTenantId_UserId",
                table: "AppFriendships",
                columns: new[] { "FriendTenantId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_AppFriendships_TenantId_FriendUserId",
                table: "AppFriendships",
                columns: new[] { "TenantId", "FriendUserId" });

            migrationBuilder.CreateIndex(
                name: "IX_AppFriendships_TenantId_UserId",
                table: "AppFriendships",
                columns: new[] { "TenantId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_AppSubscriptionPayments_EditionId",
                table: "AppSubscriptionPayments",
                column: "EditionId");

            migrationBuilder.CreateIndex(
                name: "IX_AppSubscriptionPayments_ExternalPaymentId_Gateway",
                table: "AppSubscriptionPayments",
                columns: new[] { "ExternalPaymentId", "Gateway" });

            migrationBuilder.CreateIndex(
                name: "IX_AppSubscriptionPayments_Status_CreationTime",
                table: "AppSubscriptionPayments",
                columns: new[] { "Status", "CreationTime" });

            migrationBuilder.CreateIndex(
                name: "IX_AppSubscriptionPaymentsExtensionData_SubscriptionPaymentId_Key_IsDeleted",
                table: "AppSubscriptionPaymentsExtensionData",
                columns: new[] { "SubscriptionPaymentId", "Key", "IsDeleted" },
                unique: true,
                filter: "[Key] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserDelegations_TenantId_SourceUserId",
                table: "AppUserDelegations",
                columns: new[] { "TenantId", "SourceUserId" });

            migrationBuilder.CreateIndex(
                name: "IX_AppUserDelegations_TenantId_TargetUserId",
                table: "AppUserDelegations",
                columns: new[] { "TenantId", "TargetUserId" });

            migrationBuilder.CreateIndex(
                name: "IX_MstSleAccessoryPackageDetail_AccessoryId",
                table: "MstSleAccessoryPackageDetail",
                column: "AccessoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MstSleAccessoryPackageDetail_AccessoryPackageId",
                table: "MstSleAccessoryPackageDetail",
                column: "AccessoryPackageId");

            migrationBuilder.CreateIndex(
                name: "IX_MstSleAccessoryPrice_AccessoryId",
                table: "MstSleAccessoryPrice",
                column: "AccessoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MstSleDistrict_ProvinceId",
                table: "MstSleDistrict",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_MstSleStockChecking_ModelId",
                table: "MstSleStockChecking",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesCustomer_AgeRangeId",
                table: "SalesCustomer",
                column: "AgeRangeId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesCustomer_CustomerTypeId",
                table: "SalesCustomer",
                column: "CustomerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesCustomer_DealerId",
                table: "SalesCustomer",
                column: "DealerId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesCustomer_DistrictId",
                table: "SalesCustomer",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesCustomer_ExpectedDelTimingId",
                table: "SalesCustomer",
                column: "ExpectedDelTimingId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesCustomer_FARId",
                table: "SalesCustomer",
                column: "FARId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesCustomer_GenderId",
                table: "SalesCustomer",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesCustomer_HobbyId",
                table: "SalesCustomer",
                column: "HobbyId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesCustomer_HotnessId",
                table: "SalesCustomer",
                column: "HotnessId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesCustomer_MaritalStatusId",
                table: "SalesCustomer",
                column: "MaritalStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesCustomer_OccupationId",
                table: "SalesCustomer",
                column: "OccupationId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesCustomer_PaymentTypeId",
                table: "SalesCustomer",
                column: "PaymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesCustomer_ProvinceId",
                table: "SalesCustomer",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesCustomer_PurposeId",
                table: "SalesCustomer",
                column: "PurposeId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesCustomer_ReferenceId",
                table: "SalesCustomer",
                column: "ReferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesCustomer_RelationshipId",
                table: "SalesCustomer",
                column: "RelationshipId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesCustomer_SalesPersonId",
                table: "SalesCustomer",
                column: "SalesPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesCustomer_SourceId",
                table: "SalesCustomer",
                column: "SourceId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesCustomer_SourceOfInfoId",
                table: "SalesCustomer",
                column: "SourceOfInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesCustomerAnniversary_SalesCustomerId",
                table: "SalesCustomerAnniversary",
                column: "SalesCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesCustomerAppointment_ApptActivityId",
                table: "SalesCustomerAppointment",
                column: "ApptActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesCustomerAppointment_ApptPlaceId",
                table: "SalesCustomerAppointment",
                column: "ApptPlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesCustomerAppointment_SalesCustomerId",
                table: "SalesCustomerAppointment",
                column: "SalesCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesCustomerAppointment_SalesCustomerTransactionInfoId",
                table: "SalesCustomerAppointment",
                column: "SalesCustomerTransactionInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesCustomerManagerComment_SalesCustomerId",
                table: "SalesCustomerManagerComment",
                column: "SalesCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesCustomerManagerComment_SalesCustomerTransactionInfoContactId",
                table: "SalesCustomerManagerComment",
                column: "SalesCustomerTransactionInfoContactId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesCustomerManagerComment_SalesCustomerTransactionInfoId",
                table: "SalesCustomerManagerComment",
                column: "SalesCustomerTransactionInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesCustomerSocialChannel_SalesCustomerId",
                table: "SalesCustomerSocialChannel",
                column: "SalesCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesCustomerSocialChannel_SocialChannelId",
                table: "SalesCustomerSocialChannel",
                column: "SocialChannelId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesCustomerTestDrive_SalesCustomerId",
                table: "SalesCustomerTestDrive",
                column: "SalesCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesCustomerTestDrive_SalesCustomerTransactionInfoId",
                table: "SalesCustomerTestDrive",
                column: "SalesCustomerTransactionInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesCustomerTestDrive_SupporterId",
                table: "SalesCustomerTestDrive",
                column: "SupporterId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesCustomerTransactionInfo_ActivityStatusId",
                table: "SalesCustomerTransactionInfo",
                column: "ActivityStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesCustomerTransactionInfo_DeliveryPlaceId",
                table: "SalesCustomerTransactionInfo",
                column: "DeliveryPlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesCustomerTransactionInfo_ReasonOfLostId",
                table: "SalesCustomerTransactionInfo",
                column: "ReasonOfLostId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesCustomerTransactionInfo_RouteId",
                table: "SalesCustomerTransactionInfo",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesCustomerTransactionInfo_SalesCustomerId",
                table: "SalesCustomerTransactionInfo",
                column: "SalesCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesCustomerTransactionInfo_SalesStageId",
                table: "SalesCustomerTransactionInfo",
                column: "SalesStageId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesCustomerTransactionInfo_SupporterId",
                table: "SalesCustomerTransactionInfo",
                column: "SupporterId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesCustomerTransactionInfoContact_SalesCustomerId",
                table: "SalesCustomerTransactionInfoContact",
                column: "SalesCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesCustomerVehicleInfo_BankId",
                table: "SalesCustomerVehicleInfo",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesCustomerVehicleInfo_ColorId",
                table: "SalesCustomerVehicleInfo",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesCustomerVehicleInfo_CustomerTypeId",
                table: "SalesCustomerVehicleInfo",
                column: "CustomerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesCustomerVehicleInfo_GradeId",
                table: "SalesCustomerVehicleInfo",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesCustomerVehicleInfo_InsuranceId",
                table: "SalesCustomerVehicleInfo",
                column: "InsuranceId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesCustomerVehicleInfo_MakeId",
                table: "SalesCustomerVehicleInfo",
                column: "MakeId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesCustomerVehicleInfo_ModelId",
                table: "SalesCustomerVehicleInfo",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesCustomerVehicleInfo_PromotionId",
                table: "SalesCustomerVehicleInfo",
                column: "PromotionId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesCustomerVehicleInfo_ReasonOfChangeId",
                table: "SalesCustomerVehicleInfo",
                column: "ReasonOfChangeId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesCustomerVehicleInfo_ReasonOfNA1kId",
                table: "SalesCustomerVehicleInfo",
                column: "ReasonOfNA1kId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesCustomerVehicleInfo_ReasonOfNADId",
                table: "SalesCustomerVehicleInfo",
                column: "ReasonOfNADId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesCustomerVehicleInfo_ReasonOfNAFinanceId",
                table: "SalesCustomerVehicleInfo",
                column: "ReasonOfNAFinanceId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesCustomerVehicleInfo_ReasonOfNAInsuranceId",
                table: "SalesCustomerVehicleInfo",
                column: "ReasonOfNAInsuranceId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesCustomerVehicleInfo_ReasonOfNATDId",
                table: "SalesCustomerVehicleInfo",
                column: "ReasonOfNATDId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesCustomerVehicleInfo_SalesCustomerId",
                table: "SalesCustomerVehicleInfo",
                column: "SalesCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesProposalFinance_BankId",
                table: "SalesProposalFinance",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesProposalInsurance_SaleCampaignId",
                table: "SalesProposalInsurance",
                column: "SaleCampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesProposalPPM_PPMPackId",
                table: "SalesProposalPPM",
                column: "PPMPackId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesToDoList_ActivityId",
                table: "SalesToDoList",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesToDoList_CustomerHotnessId",
                table: "SalesToDoList",
                column: "CustomerHotnessId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesToDoList_CustomerId",
                table: "SalesToDoList",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesToDoList_PlaceId",
                table: "SalesToDoList",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesToDoList_ReasonOfNAId",
                table: "SalesToDoList",
                column: "ReasonOfNAId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesToDoList_RouteId",
                table: "SalesToDoList",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesToDoList_StallId",
                table: "SalesToDoList",
                column: "StallId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesToDoList_VehicleId",
                table: "SalesToDoList",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesVehicle_ExternalColorId",
                table: "SalesVehicle",
                column: "ExternalColorId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesVehicle_GradeId",
                table: "SalesVehicle",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesVehicle_ModelId",
                table: "SalesVehicle",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesVehicleTransportation_SalesVehicleId",
                table: "SalesVehicleTransportation",
                column: "SalesVehicleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AbpAuditLogs");

            migrationBuilder.DropTable(
                name: "AbpBackgroundJobs");

            migrationBuilder.DropTable(
                name: "AbpDynamicParameterValues");

            migrationBuilder.DropTable(
                name: "AbpEntityDynamicParameterValues");

            migrationBuilder.DropTable(
                name: "AbpEntityPropertyChanges");

            migrationBuilder.DropTable(
                name: "AbpFeatures");

            migrationBuilder.DropTable(
                name: "AbpLanguages");

            migrationBuilder.DropTable(
                name: "AbpLanguageTexts");

            migrationBuilder.DropTable(
                name: "AbpNotifications");

            migrationBuilder.DropTable(
                name: "AbpNotificationSubscriptions");

            migrationBuilder.DropTable(
                name: "AbpOrganizationUnitRoles");

            migrationBuilder.DropTable(
                name: "AbpOrganizationUnits");

            migrationBuilder.DropTable(
                name: "AbpPermissions");

            migrationBuilder.DropTable(
                name: "AbpPersistedGrants");

            migrationBuilder.DropTable(
                name: "AbpRoleClaims");

            migrationBuilder.DropTable(
                name: "AbpSettings");

            migrationBuilder.DropTable(
                name: "AbpTenantNotifications");

            migrationBuilder.DropTable(
                name: "AbpTenants");

            migrationBuilder.DropTable(
                name: "AbpUserAccounts");

            migrationBuilder.DropTable(
                name: "AbpUserClaims");

            migrationBuilder.DropTable(
                name: "AbpUserLoginAttempts");

            migrationBuilder.DropTable(
                name: "AbpUserLogins");

            migrationBuilder.DropTable(
                name: "AbpUserNotifications");

            migrationBuilder.DropTable(
                name: "AbpUserOrganizationUnits");

            migrationBuilder.DropTable(
                name: "AbpUserRoles");

            migrationBuilder.DropTable(
                name: "AbpUserTokens");

            migrationBuilder.DropTable(
                name: "AbpWebhookSendAttempts");

            migrationBuilder.DropTable(
                name: "AbpWebhookSubscriptions");

            migrationBuilder.DropTable(
                name: "AppBinaryObjects");

            migrationBuilder.DropTable(
                name: "AppChatMessages");

            migrationBuilder.DropTable(
                name: "AppFriendships");

            migrationBuilder.DropTable(
                name: "AppInvoices");

            migrationBuilder.DropTable(
                name: "AppSubscriptionPayments");

            migrationBuilder.DropTable(
                name: "AppSubscriptionPaymentsExtensionData");

            migrationBuilder.DropTable(
                name: "AppUserDelegations");

            migrationBuilder.DropTable(
                name: "MstInvoicePlanLeadTime");

            migrationBuilder.DropTable(
                name: "MstSleAccessoryPackageDetail");

            migrationBuilder.DropTable(
                name: "MstSleAccessoryPrice");

            migrationBuilder.DropTable(
                name: "MstSleAccessoryTypes");

            migrationBuilder.DropTable(
                name: "MstSleAction");

            migrationBuilder.DropTable(
                name: "MstSleArea");

            migrationBuilder.DropTable(
                name: "MstSleAudio");

            migrationBuilder.DropTable(
                name: "MstSleColorGradesProduction");

            migrationBuilder.DropTable(
                name: "MstSleCommissionSource");

            migrationBuilder.DropTable(
                name: "MstSleContactBy");

            migrationBuilder.DropTable(
                name: "MstSleDayOff");

            migrationBuilder.DropTable(
                name: "MstSleDealerAddressReceiveVehicle");

            migrationBuilder.DropTable(
                name: "MstSleDealerGroup");

            migrationBuilder.DropTable(
                name: "MstSleFinanceSaleCampaign");

            migrationBuilder.DropTable(
                name: "MstSleGradeProduction");

            migrationBuilder.DropTable(
                name: "MstSleInsuranceCompany");

            migrationBuilder.DropTable(
                name: "MstSleInsuranceDoctype");

            migrationBuilder.DropTable(
                name: "MstSleInsuranceEmployee");

            migrationBuilder.DropTable(
                name: "MstSleInsuranceTIProduct");

            migrationBuilder.DropTable(
                name: "MstSleInsuranceType");

            migrationBuilder.DropTable(
                name: "MstSleInteriorColorGradesProduction");

            migrationBuilder.DropTable(
                name: "MstSleLocation");

            migrationBuilder.DropTable(
                name: "MstSleLogisticCompany");

            migrationBuilder.DropTable(
                name: "MstSleLookUp");

            migrationBuilder.DropTable(
                name: "MstSleMeanTransportation");

            migrationBuilder.DropTable(
                name: "MstSleMoney");

            migrationBuilder.DropTable(
                name: "MstSlePetrol");

            migrationBuilder.DropTable(
                name: "MstSlePlanDeliveryLeadtime");

            migrationBuilder.DropTable(
                name: "MstSleReasonOfLostType");

            migrationBuilder.DropTable(
                name: "MstSleSalesTeam");

            migrationBuilder.DropTable(
                name: "MstSleStockChecking");

            migrationBuilder.DropTable(
                name: "MstSleTFSProduct");

            migrationBuilder.DropTable(
                name: "MstSleTransportationType");

            migrationBuilder.DropTable(
                name: "MstSleTripRequest");

            migrationBuilder.DropTable(
                name: "MstSleTruck");

            migrationBuilder.DropTable(
                name: "MstSleUnit");

            migrationBuilder.DropTable(
                name: "MstSleVehiclePrice");

            migrationBuilder.DropTable(
                name: "MstSleYard");

            migrationBuilder.DropTable(
                name: "SalesContract");

            migrationBuilder.DropTable(
                name: "SalesContractDetail");

            migrationBuilder.DropTable(
                name: "SalesCustomerAnniversary");

            migrationBuilder.DropTable(
                name: "SalesCustomerAppointment");

            migrationBuilder.DropTable(
                name: "SalesCustomerManagerComment");

            migrationBuilder.DropTable(
                name: "SalesCustomerSocialChannel");

            migrationBuilder.DropTable(
                name: "SalesCustomerTestDrive");

            migrationBuilder.DropTable(
                name: "SalesCustomerVehicleInfo");

            migrationBuilder.DropTable(
                name: "SalesFilter");

            migrationBuilder.DropTable(
                name: "SalesFilterDetail");

            migrationBuilder.DropTable(
                name: "SalesProposal");

            migrationBuilder.DropTable(
                name: "SalesProposalAccessories");

            migrationBuilder.DropTable(
                name: "SalesProposalCommission");

            migrationBuilder.DropTable(
                name: "SalesProposalFinance");

            migrationBuilder.DropTable(
                name: "SalesProposalFuelControl");

            migrationBuilder.DropTable(
                name: "SalesProposalInsurance");

            migrationBuilder.DropTable(
                name: "SalesProposalPPM");

            migrationBuilder.DropTable(
                name: "SalesProposalVehicle");

            migrationBuilder.DropTable(
                name: "SalesToDoList");

            migrationBuilder.DropTable(
                name: "SalesUserFilterDefine");

            migrationBuilder.DropTable(
                name: "SalesVehicleAssignment");

            migrationBuilder.DropTable(
                name: "SalesVehicleCustoms");

            migrationBuilder.DropTable(
                name: "SalesVehicleLogisticSwap");

            migrationBuilder.DropTable(
                name: "SalesVehicleMaintenance");

            migrationBuilder.DropTable(
                name: "SalesVehiclePio");

            migrationBuilder.DropTable(
                name: "SalesVehicleProduction");

            migrationBuilder.DropTable(
                name: "SalesVehiclesDamage");

            migrationBuilder.DropTable(
                name: "SalesVehicleTransportation");

            migrationBuilder.DropTable(
                name: "AbpEntityDynamicParameters");

            migrationBuilder.DropTable(
                name: "AbpEntityChanges");

            migrationBuilder.DropTable(
                name: "AbpRoles");

            migrationBuilder.DropTable(
                name: "AbpWebhookEvents");

            migrationBuilder.DropTable(
                name: "AbpEditions");

            migrationBuilder.DropTable(
                name: "MstSleAccessoryPackage");

            migrationBuilder.DropTable(
                name: "MstSleAccessories");

            migrationBuilder.DropTable(
                name: "MstSleAppActivity");

            migrationBuilder.DropTable(
                name: "MstSleAppPlace");

            migrationBuilder.DropTable(
                name: "SalesCustomerTransactionInfoContact");

            migrationBuilder.DropTable(
                name: "MstSleSocialChannel");

            migrationBuilder.DropTable(
                name: "SalesCustomerTransactionInfo");

            migrationBuilder.DropTable(
                name: "MstSleInsurance");

            migrationBuilder.DropTable(
                name: "MstSleMake");

            migrationBuilder.DropTable(
                name: "MstSlePromotion");

            migrationBuilder.DropTable(
                name: "MstSleReasonOfChanges");

            migrationBuilder.DropTable(
                name: "MstSleBank");

            migrationBuilder.DropTable(
                name: "MstSleInsuranceSaleCampaign");

            migrationBuilder.DropTable(
                name: "MstSlePPMPackage");

            migrationBuilder.DropTable(
                name: "MstSleActivity");

            migrationBuilder.DropTable(
                name: "MstSleTestDrivePlace");

            migrationBuilder.DropTable(
                name: "MstSleReasonOfNA");

            migrationBuilder.DropTable(
                name: "MstSleTestDriveRoute");

            migrationBuilder.DropTable(
                name: "MstSleTestDriveStall");

            migrationBuilder.DropTable(
                name: "MstSleTestDriveVehicle");

            migrationBuilder.DropTable(
                name: "SalesVehicle");

            migrationBuilder.DropTable(
                name: "AbpDynamicParameters");

            migrationBuilder.DropTable(
                name: "AbpEntityChangeSets");

            migrationBuilder.DropTable(
                name: "AbpUsers");

            migrationBuilder.DropTable(
                name: "MstSleActivityStatus");

            migrationBuilder.DropTable(
                name: "MstSleDeliveryPlace");

            migrationBuilder.DropTable(
                name: "MstSleReasonofLost");

            migrationBuilder.DropTable(
                name: "MstSleRoute");

            migrationBuilder.DropTable(
                name: "SalesCustomer");

            migrationBuilder.DropTable(
                name: "MstSleSalesStage");

            migrationBuilder.DropTable(
                name: "MstSleSupporter");

            migrationBuilder.DropTable(
                name: "MstSleColors");

            migrationBuilder.DropTable(
                name: "MstSleGrades");

            migrationBuilder.DropTable(
                name: "MstSleModel");

            migrationBuilder.DropTable(
                name: "MstSleAgeRange");

            migrationBuilder.DropTable(
                name: "MstSleCustomerType");

            migrationBuilder.DropTable(
                name: "MstGenDealer");

            migrationBuilder.DropTable(
                name: "MstSleDistrict");

            migrationBuilder.DropTable(
                name: "MstSleExpectedDelTiming");

            migrationBuilder.DropTable(
                name: "MstSleFAR");

            migrationBuilder.DropTable(
                name: "MstSleGender");

            migrationBuilder.DropTable(
                name: "MstSleHobby");

            migrationBuilder.DropTable(
                name: "MstSleHotness");

            migrationBuilder.DropTable(
                name: "MstSleMaritalStatus");

            migrationBuilder.DropTable(
                name: "MstSleOccupation");

            migrationBuilder.DropTable(
                name: "MstSlePaymentType");

            migrationBuilder.DropTable(
                name: "MstSlePurpose");

            migrationBuilder.DropTable(
                name: "MstSleReference");

            migrationBuilder.DropTable(
                name: "MstSleRelationship");

            migrationBuilder.DropTable(
                name: "MstSleSalesPerson");

            migrationBuilder.DropTable(
                name: "MstSleSource");

            migrationBuilder.DropTable(
                name: "MstSleSourceOfInfo");

            migrationBuilder.DropTable(
                name: "MstGenProvince");
        }
    }
}
