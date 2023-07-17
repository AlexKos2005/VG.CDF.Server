using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace VG.CDF.Server.WebApi.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ParameterGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ExternalId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParameterGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    RoleCode = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkEmails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkEmails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AlarmEvents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ExternalId = table.Column<int>(type: "integer", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlarmEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlarmEvents_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ExternalId = table.Column<int>(type: "integer", nullable: false),
                    UtcOffset = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    CompanyId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Parameters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ExternalId = table.Column<int>(type: "integer", nullable: false),
                    ValueType = table.Column<int>(type: "integer", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uuid", nullable: false),
                    ParameterGroupId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parameters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parameters_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Parameters_ParameterGroups_ParameterGroupId",
                        column: x => x.ParameterGroupId,
                        principalTable: "ParameterGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: true),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlarmEventDescriptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RusDescription = table.Column<string>(type: "text", nullable: true),
                    EngDescription = table.Column<string>(type: "text", nullable: true),
                    UkrDescription = table.Column<string>(type: "text", nullable: true),
                    AlarmEventId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlarmEventDescriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlarmEventDescriptions_AlarmEvents_AlarmEventId",
                        column: x => x.AlarmEventId,
                        principalTable: "AlarmEvents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParameterReportTasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    LastSendDt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Status = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParameterReportTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParameterReportTasks_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Processess",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ExternalId = table.Column<int>(type: "integer", nullable: false),
                    DeviceCode = table.Column<int>(type: "integer", nullable: false),
                    DeviceIp = table.Column<string>(type: "text", nullable: true),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Processess", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Processess_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectActionsInfos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    LastDateTimeConnection = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastDateTimeReportSending = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastDateTimeConnectionOffset = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastDateTimeReportSendingOffset = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    AlarmMessageCounter = table.Column<int>(type: "integer", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectActionsInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectActionsInfos_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParameterDescriptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RusDescription = table.Column<string>(type: "text", nullable: true),
                    EngDescription = table.Column<string>(type: "text", nullable: true),
                    UkrDescription = table.Column<string>(type: "text", nullable: true),
                    ParameterId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParameterDescriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParameterDescriptions_Parameters_ParameterId",
                        column: x => x.ParameterId,
                        principalTable: "Parameters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersProjects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersProjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersProjects_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersProjects_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParametersReportTaskWorkEmail",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ParameterReportTaskId = table.Column<Guid>(type: "uuid", nullable: true),
                    WorkEmailId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParametersReportTaskWorkEmail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParametersReportTaskWorkEmail_ParameterReportTasks_Paramete~",
                        column: x => x.ParameterReportTaskId,
                        principalTable: "ParameterReportTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParametersReportTaskWorkEmail_WorkEmails_WorkEmailId",
                        column: x => x.WorkEmailId,
                        principalTable: "WorkEmails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlarmEventsLive",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ExternalId = table.Column<int>(type: "integer", nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateTimeOffset = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ProcessId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlarmEventsLive", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlarmEventsLive_Processess_ProcessId",
                        column: x => x.ProcessId,
                        principalTable: "Processess",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParametersProcesses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ParameterId = table.Column<Guid>(type: "uuid", nullable: true),
                    ProcessId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParametersProcesses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParametersProcesses_Parameters_ParameterId",
                        column: x => x.ParameterId,
                        principalTable: "Parameters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParametersProcesses_Processess_ProcessId",
                        column: x => x.ProcessId,
                        principalTable: "Processess",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParameterValuesGroups",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateTimeOffset = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ProcessId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParameterValuesGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParameterValuesGroups_Processess_ProcessId",
                        column: x => x.ProcessId,
                        principalTable: "Processess",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProcessDescriptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RusDescription = table.Column<string>(type: "text", nullable: true),
                    EngDescription = table.Column<string>(type: "text", nullable: true),
                    UkrDescription = table.Column<string>(type: "text", nullable: true),
                    ProcessId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessDescriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProcessDescriptions_Processess_ProcessId",
                        column: x => x.ProcessId,
                        principalTable: "Processess",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParameterValues",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ParameterExternalId = table.Column<int>(type: "integer", nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateTimeOffset = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true),
                    ValueType = table.Column<int>(type: "integer", nullable: false),
                    ProcessId = table.Column<Guid>(type: "uuid", nullable: false),
                    ParameterValuesGroupId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParameterValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParameterValues_ParameterValuesGroups_ParameterValuesGroupId",
                        column: x => x.ParameterValuesGroupId,
                        principalTable: "ParameterValuesGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlarmEventDescriptions_AlarmEventId",
                table: "AlarmEventDescriptions",
                column: "AlarmEventId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AlarmEvents_CompanyId",
                table: "AlarmEvents",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_AlarmEventsLive_ProcessId",
                table: "AlarmEventsLive",
                column: "ProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_Company_Id",
                table: "Company",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ParameterDescriptions_ParameterId",
                table: "ParameterDescriptions",
                column: "ParameterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ParameterReportTasks_ProjectId",
                table: "ParameterReportTasks",
                column: "ProjectId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Parameters_CompanyId",
                table: "Parameters",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Parameters_ParameterGroupId",
                table: "Parameters",
                column: "ParameterGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ParametersProcesses_ParameterId",
                table: "ParametersProcesses",
                column: "ParameterId");

            migrationBuilder.CreateIndex(
                name: "IX_ParametersProcesses_ProcessId",
                table: "ParametersProcesses",
                column: "ProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_ParametersReportTaskWorkEmail_ParameterReportTaskId",
                table: "ParametersReportTaskWorkEmail",
                column: "ParameterReportTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_ParametersReportTaskWorkEmail_WorkEmailId",
                table: "ParametersReportTaskWorkEmail",
                column: "WorkEmailId");

            migrationBuilder.CreateIndex(
                name: "IX_ParameterValues_ParameterValuesGroupId",
                table: "ParameterValues",
                column: "ParameterValuesGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ParameterValuesGroups_ProcessId",
                table: "ParameterValuesGroups",
                column: "ProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessDescriptions_ProcessId",
                table: "ProcessDescriptions",
                column: "ProcessId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Processess_ProjectId",
                table: "Processess",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectActionsInfos_ProjectId",
                table: "ProjectActionsInfos",
                column: "ProjectId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_CompanyId",
                table: "Projects",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersProjects_ProjectId",
                table: "UsersProjects",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersProjects_UserId",
                table: "UsersProjects",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlarmEventDescriptions");

            migrationBuilder.DropTable(
                name: "AlarmEventsLive");

            migrationBuilder.DropTable(
                name: "ParameterDescriptions");

            migrationBuilder.DropTable(
                name: "ParametersProcesses");

            migrationBuilder.DropTable(
                name: "ParametersReportTaskWorkEmail");

            migrationBuilder.DropTable(
                name: "ParameterValues");

            migrationBuilder.DropTable(
                name: "ProcessDescriptions");

            migrationBuilder.DropTable(
                name: "ProjectActionsInfos");

            migrationBuilder.DropTable(
                name: "UsersProjects");

            migrationBuilder.DropTable(
                name: "AlarmEvents");

            migrationBuilder.DropTable(
                name: "Parameters");

            migrationBuilder.DropTable(
                name: "ParameterReportTasks");

            migrationBuilder.DropTable(
                name: "WorkEmails");

            migrationBuilder.DropTable(
                name: "ParameterValuesGroups");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "ParameterGroups");

            migrationBuilder.DropTable(
                name: "Processess");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Company");
        }
    }
}
