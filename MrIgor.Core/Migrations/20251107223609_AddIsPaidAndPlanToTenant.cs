using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MrIgor.Core.Migrations
{
    /// <inheritdoc />
    public partial class AddIsPaidAndPlanToTenant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Academic");

            migrationBuilder.CreateTable(
                name: "Tenants",
                schema: "Academic",
                columns: table => new
                {
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Domain = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "(sysdatetime())"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    IsPaid = table.Column<bool>(type: "bit", nullable: false),
                    SubcriptionPlan = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Tenants__2E9B47E170819AFD", x => x.TenantId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoles_Tenant",
                        column: x => x.TenantId,
                        principalSchema: "Academic",
                        principalTable: "Tenants",
                        principalColumn: "TenantId");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Tenant",
                        column: x => x.TenantId,
                        principalSchema: "Academic",
                        principalTable: "Tenants",
                        principalColumn: "TenantId");
                });

            migrationBuilder.CreateTable(
                name: "Classrooms",
                schema: "Academic",
                columns: table => new
                {
                    ClassroomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false, defaultValue: 30),
                    Location = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "(sysdatetime())"),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Classroo__11618EAAEA32DC3B", x => x.ClassroomId);
                    table.ForeignKey(
                        name: "FK_Classrooms_Tenant",
                        column: x => x.TenantId,
                        principalSchema: "Academic",
                        principalTable: "Tenants",
                        principalColumn: "TenantId");
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                schema: "Academic",
                columns: table => new
                {
                    SessionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "(sysdatetime())"),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Sessions__C9F492902F42498B", x => x.SessionId);
                    table.ForeignKey(
                        name: "FK_Sessions_Tenant",
                        column: x => x.TenantId,
                        principalSchema: "Academic",
                        principalTable: "Tenants",
                        principalColumn: "TenantId");
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_Tenant",
                        column: x => x.TenantId,
                        principalSchema: "Academic",
                        principalTable: "Tenants",
                        principalColumn: "TenantId");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                schema: "Academic",
                columns: table => new
                {
                    SubjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SessionId = table.Column<int>(type: "int", nullable: false),
                    ClassroomId = table.Column<int>(type: "int", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Subjects__AC1BA3A80BC4A452", x => x.SubjectId);
                    table.ForeignKey(
                        name: "FK_Subjects_Classroom",
                        column: x => x.ClassroomId,
                        principalSchema: "Academic",
                        principalTable: "Classrooms",
                        principalColumn: "ClassroomId");
                    table.ForeignKey(
                        name: "FK_Subjects_Session",
                        column: x => x.SessionId,
                        principalSchema: "Academic",
                        principalTable: "Sessions",
                        principalColumn: "SessionId");
                    table.ForeignKey(
                        name: "FK_Subjects_Tenant",
                        column: x => x.TenantId,
                        principalSchema: "Academic",
                        principalTable: "Tenants",
                        principalColumn: "TenantId");
                });

            migrationBuilder.CreateTable(
                name: "Assessments",
                schema: "Academic",
                columns: table => new
                {
                    AssessmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    MaxScore = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Assessme__3D2BF81EDD65C589", x => x.AssessmentId);
                    table.ForeignKey(
                        name: "FK_Assessments_Subject",
                        column: x => x.SubjectId,
                        principalSchema: "Academic",
                        principalTable: "Subjects",
                        principalColumn: "SubjectId");
                    table.ForeignKey(
                        name: "FK_Assessments_Tenant",
                        column: x => x.TenantId,
                        principalSchema: "Academic",
                        principalTable: "Tenants",
                        principalColumn: "TenantId");
                });

            migrationBuilder.CreateTable(
                name: "Attendance",
                schema: "Academic",
                columns: table => new
                {
                    AttendanceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    ClassroomId = table.Column<int>(type: "int", nullable: false),
                    AttendedAt = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "(sysdatetime())"),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Attendan__8B69261C363C9B7A", x => x.AttendanceId);
                    table.ForeignKey(
                        name: "FK_Attendance_Classroom",
                        column: x => x.ClassroomId,
                        principalSchema: "Academic",
                        principalTable: "Classrooms",
                        principalColumn: "ClassroomId");
                    table.ForeignKey(
                        name: "FK_Attendance_Student",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Attendance_Subject",
                        column: x => x.SubjectId,
                        principalSchema: "Academic",
                        principalTable: "Subjects",
                        principalColumn: "SubjectId");
                    table.ForeignKey(
                        name: "FK_Attendance_Tenant",
                        column: x => x.TenantId,
                        principalSchema: "Academic",
                        principalTable: "Tenants",
                        principalColumn: "TenantId");
                });

            migrationBuilder.CreateTable(
                name: "Exams",
                schema: "Academic",
                columns: table => new
                {
                    ExamId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    MaxScore = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    ExamDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Exams__297521C7A36B965C", x => x.ExamId);
                    table.ForeignKey(
                        name: "FK_Exams_Subject",
                        column: x => x.SubjectId,
                        principalSchema: "Academic",
                        principalTable: "Subjects",
                        principalColumn: "SubjectId");
                    table.ForeignKey(
                        name: "FK_Exams_Tenant",
                        column: x => x.TenantId,
                        principalSchema: "Academic",
                        principalTable: "Tenants",
                        principalColumn: "TenantId");
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                schema: "Academic",
                columns: table => new
                {
                    NotificationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipientId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    SentAt = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "(sysdatetime())"),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Notifica__20CF2E12FE7BBADC", x => x.NotificationId);
                    table.ForeignKey(
                        name: "FK_Notifications_Recipient",
                        column: x => x.RecipientId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Notifications_Subject",
                        column: x => x.SubjectId,
                        principalSchema: "Academic",
                        principalTable: "Subjects",
                        principalColumn: "SubjectId");
                    table.ForeignKey(
                        name: "FK_Notifications_Tenant",
                        column: x => x.TenantId,
                        principalSchema: "Academic",
                        principalTable: "Tenants",
                        principalColumn: "TenantId");
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                schema: "Academic",
                columns: table => new
                {
                    ScheduleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    ClassroomId = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DayOfWeek = table.Column<byte>(type: "tinyint", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Schedule__9C8A5B49821B2F9C", x => x.ScheduleId);
                    table.ForeignKey(
                        name: "FK_Schedules_Classroom",
                        column: x => x.ClassroomId,
                        principalSchema: "Academic",
                        principalTable: "Classrooms",
                        principalColumn: "ClassroomId");
                    table.ForeignKey(
                        name: "FK_Schedules_Subject",
                        column: x => x.SubjectId,
                        principalSchema: "Academic",
                        principalTable: "Subjects",
                        principalColumn: "SubjectId");
                    table.ForeignKey(
                        name: "FK_Schedules_Tenant",
                        column: x => x.TenantId,
                        principalSchema: "Academic",
                        principalTable: "Tenants",
                        principalColumn: "TenantId");
                });

            migrationBuilder.CreateTable(
                name: "StudentSubjects",
                schema: "Academic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    RegisteredAt = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "(sysdatetime())"),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__StudentS__3214EC072CD4AF8B", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentSubjects_Student",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StudentSubjects_Subject",
                        column: x => x.SubjectId,
                        principalSchema: "Academic",
                        principalTable: "Subjects",
                        principalColumn: "SubjectId");
                    table.ForeignKey(
                        name: "FK_StudentSubjects_Tenant",
                        column: x => x.TenantId,
                        principalSchema: "Academic",
                        principalTable: "Tenants",
                        principalColumn: "TenantId");
                });

            migrationBuilder.CreateTable(
                name: "TeachersSubjects",
                schema: "Academic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeacherId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    AssignedAt = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "(sysdatetime())"),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Teachers__3214EC07B62212B0", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeachersSubjects_Subject",
                        column: x => x.SubjectId,
                        principalSchema: "Academic",
                        principalTable: "Subjects",
                        principalColumn: "SubjectId");
                    table.ForeignKey(
                        name: "FK_TeachersSubjects_Teacher",
                        column: x => x.TeacherId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TeachersSubjects_Tenant",
                        column: x => x.TenantId,
                        principalSchema: "Academic",
                        principalTable: "Tenants",
                        principalColumn: "TenantId");
                });

            migrationBuilder.CreateTable(
                name: "Scores",
                schema: "Academic",
                columns: table => new
                {
                    ScoreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    AssessmentId = table.Column<int>(type: "int", nullable: true),
                    ExamId = table.Column<int>(type: "int", nullable: true),
                    Score = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    RecordedAt = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "(sysdatetime())"),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Scores__7DD229D18032CA2C", x => x.ScoreId);
                    table.ForeignKey(
                        name: "FK_Scores_Assessment",
                        column: x => x.AssessmentId,
                        principalSchema: "Academic",
                        principalTable: "Assessments",
                        principalColumn: "AssessmentId");
                    table.ForeignKey(
                        name: "FK_Scores_Exam",
                        column: x => x.ExamId,
                        principalSchema: "Academic",
                        principalTable: "Exams",
                        principalColumn: "ExamId");
                    table.ForeignKey(
                        name: "FK_Scores_Student",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Scores_Subject",
                        column: x => x.SubjectId,
                        principalSchema: "Academic",
                        principalTable: "Subjects",
                        principalColumn: "SubjectId");
                    table.ForeignKey(
                        name: "FK_Scores_Tenant",
                        column: x => x.TenantId,
                        principalSchema: "Academic",
                        principalTable: "Tenants",
                        principalColumn: "TenantId");
                });

            migrationBuilder.CreateTable(
                name: "StudentSubjectApprovals",
                schema: "Academic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeacherId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    StudentSubjectId = table.Column<int>(type: "int", nullable: false),
                    Approved = table.Column<bool>(type: "bit", nullable: false),
                    ApprovedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__StudentS__3214EC071B055513", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Approvals_StudentSubject",
                        column: x => x.StudentSubjectId,
                        principalSchema: "Academic",
                        principalTable: "StudentSubjects",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Approvals_Teacher",
                        column: x => x.TeacherId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Approvals_Tenant",
                        column: x => x.TenantId,
                        principalSchema: "Academic",
                        principalTable: "Tenants",
                        principalColumn: "TenantId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoles_TenantId",
                table: "AspNetRoles",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "([NormalizedName] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_TenantId",
                table: "AspNetUserRoles",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_TenantId",
                table: "AspNetUsers",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "([NormalizedUserName] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_Assessments_SubjectId",
                schema: "Academic",
                table: "Assessments",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Assessments_TenantId",
                schema: "Academic",
                table: "Assessments",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Attendance_ClassroomId",
                schema: "Academic",
                table: "Attendance",
                column: "ClassroomId");

            migrationBuilder.CreateIndex(
                name: "IX_Attendance_StudentId",
                schema: "Academic",
                table: "Attendance",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Attendance_SubjectId",
                schema: "Academic",
                table: "Attendance",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Attendance_TenantId",
                schema: "Academic",
                table: "Attendance",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Classrooms_TenantId",
                schema: "Academic",
                table: "Classrooms",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Exams_SubjectId",
                schema: "Academic",
                table: "Exams",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Exams_TenantId",
                schema: "Academic",
                table: "Exams",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_RecipientId",
                schema: "Academic",
                table: "Notifications",
                column: "RecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_SubjectId",
                schema: "Academic",
                table: "Notifications",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_TenantId",
                schema: "Academic",
                table: "Notifications",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_ClassroomId",
                schema: "Academic",
                table: "Schedules",
                column: "ClassroomId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_SubjectId",
                schema: "Academic",
                table: "Schedules",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_TenantId",
                schema: "Academic",
                table: "Schedules",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Scores_AssessmentId",
                schema: "Academic",
                table: "Scores",
                column: "AssessmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Scores_ExamId",
                schema: "Academic",
                table: "Scores",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_Scores_StudentId",
                schema: "Academic",
                table: "Scores",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Scores_SubjectId",
                schema: "Academic",
                table: "Scores",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Scores_TenantId",
                schema: "Academic",
                table: "Scores",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_TenantId",
                schema: "Academic",
                table: "Sessions",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubjectApprovals_StudentSubjectId",
                schema: "Academic",
                table: "StudentSubjectApprovals",
                column: "StudentSubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubjectApprovals_TeacherId",
                schema: "Academic",
                table: "StudentSubjectApprovals",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubjectApprovals_TenantId",
                schema: "Academic",
                table: "StudentSubjectApprovals",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubjects_SubjectId",
                schema: "Academic",
                table: "StudentSubjects",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubjects_TenantId",
                schema: "Academic",
                table: "StudentSubjects",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UQ_Student_Subject",
                schema: "Academic",
                table: "StudentSubjects",
                columns: new[] { "StudentId", "SubjectId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_ClassroomId",
                schema: "Academic",
                table: "Subjects",
                column: "ClassroomId");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_SessionId",
                schema: "Academic",
                table: "Subjects",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_TenantId",
                schema: "Academic",
                table: "Subjects",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_TeachersSubjects_SubjectId",
                schema: "Academic",
                table: "TeachersSubjects",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_TeachersSubjects_TenantId",
                schema: "Academic",
                table: "TeachersSubjects",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UQ_Teacher_Subject",
                schema: "Academic",
                table: "TeachersSubjects",
                columns: new[] { "TeacherId", "SubjectId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Attendance",
                schema: "Academic");

            migrationBuilder.DropTable(
                name: "Notifications",
                schema: "Academic");

            migrationBuilder.DropTable(
                name: "Schedules",
                schema: "Academic");

            migrationBuilder.DropTable(
                name: "Scores",
                schema: "Academic");

            migrationBuilder.DropTable(
                name: "StudentSubjectApprovals",
                schema: "Academic");

            migrationBuilder.DropTable(
                name: "TeachersSubjects",
                schema: "Academic");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Assessments",
                schema: "Academic");

            migrationBuilder.DropTable(
                name: "Exams",
                schema: "Academic");

            migrationBuilder.DropTable(
                name: "StudentSubjects",
                schema: "Academic");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Subjects",
                schema: "Academic");

            migrationBuilder.DropTable(
                name: "Classrooms",
                schema: "Academic");

            migrationBuilder.DropTable(
                name: "Sessions",
                schema: "Academic");

            migrationBuilder.DropTable(
                name: "Tenants",
                schema: "Academic");
        }
    }
}
