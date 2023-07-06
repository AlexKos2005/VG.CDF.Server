using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VG.CDF.Server.WebApi.Migrations
{
    public partial class Cascading_Delete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlarmEventDescriptions_AlarmEvents_AlarmEventId",
                table: "AlarmEventDescriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_AlarmEvents_Company_CompanyId",
                table: "AlarmEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_AlarmEventsLive_Processess_ProcessId",
                table: "AlarmEventsLive");

            migrationBuilder.DropForeignKey(
                name: "FK_ParameterDescriptions_Parameters_ParameterId",
                table: "ParameterDescriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_ParameterReportTasks_Projects_ProjectId",
                table: "ParameterReportTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Parameters_Company_CompanyId",
                table: "Parameters");

            migrationBuilder.DropForeignKey(
                name: "FK_Parameters_ParameterGroups_ParameterGroupId",
                table: "Parameters");

            migrationBuilder.DropForeignKey(
                name: "FK_ParametersProcesses_Parameters_ParameterId",
                table: "ParametersProcesses");

            migrationBuilder.DropForeignKey(
                name: "FK_ParametersProcesses_Processess_ProcessId",
                table: "ParametersProcesses");

            migrationBuilder.DropForeignKey(
                name: "FK_ParametersReportTaskWorkEmail_ParameterReportTasks_Paramete~",
                table: "ParametersReportTaskWorkEmail");

            migrationBuilder.DropForeignKey(
                name: "FK_ParametersReportTaskWorkEmail_WorkEmails_WorkEmailId",
                table: "ParametersReportTaskWorkEmail");

            migrationBuilder.DropForeignKey(
                name: "FK_ParameterValues_ParameterValuesGroups_ParameterValuesGroupId",
                table: "ParameterValues");

            migrationBuilder.DropForeignKey(
                name: "FK_ParameterValuesGroups_Processess_ProcessId",
                table: "ParameterValuesGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_ProcessDescriptions_Processess_ProcessId",
                table: "ProcessDescriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Processess_Projects_ProjectId",
                table: "Processess");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectActionsInfos_Projects_ProjectId",
                table: "ProjectActionsInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Company_CompanyId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersProjects_Projects_ProjectId",
                table: "UsersProjects");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersProjects_Users_UserId",
                table: "UsersProjects");

            migrationBuilder.AddForeignKey(
                name: "FK_AlarmEventDescriptions_AlarmEvents_AlarmEventId",
                table: "AlarmEventDescriptions",
                column: "AlarmEventId",
                principalTable: "AlarmEvents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AlarmEvents_Company_CompanyId",
                table: "AlarmEvents",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AlarmEventsLive_Processess_ProcessId",
                table: "AlarmEventsLive",
                column: "ProcessId",
                principalTable: "Processess",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ParameterDescriptions_Parameters_ParameterId",
                table: "ParameterDescriptions",
                column: "ParameterId",
                principalTable: "Parameters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ParameterReportTasks_Projects_ProjectId",
                table: "ParameterReportTasks",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Parameters_Company_CompanyId",
                table: "Parameters",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Parameters_ParameterGroups_ParameterGroupId",
                table: "Parameters",
                column: "ParameterGroupId",
                principalTable: "ParameterGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ParametersProcesses_Parameters_ParameterId",
                table: "ParametersProcesses",
                column: "ParameterId",
                principalTable: "Parameters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ParametersProcesses_Processess_ProcessId",
                table: "ParametersProcesses",
                column: "ProcessId",
                principalTable: "Processess",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ParametersReportTaskWorkEmail_ParameterReportTasks_Paramete~",
                table: "ParametersReportTaskWorkEmail",
                column: "ParameterReportTaskId",
                principalTable: "ParameterReportTasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ParametersReportTaskWorkEmail_WorkEmails_WorkEmailId",
                table: "ParametersReportTaskWorkEmail",
                column: "WorkEmailId",
                principalTable: "WorkEmails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ParameterValues_ParameterValuesGroups_ParameterValuesGroupId",
                table: "ParameterValues",
                column: "ParameterValuesGroupId",
                principalTable: "ParameterValuesGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ParameterValuesGroups_Processess_ProcessId",
                table: "ParameterValuesGroups",
                column: "ProcessId",
                principalTable: "Processess",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProcessDescriptions_Processess_ProcessId",
                table: "ProcessDescriptions",
                column: "ProcessId",
                principalTable: "Processess",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Processess_Projects_ProjectId",
                table: "Processess",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectActionsInfos_Projects_ProjectId",
                table: "ProjectActionsInfos",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Company_CompanyId",
                table: "Projects",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersProjects_Projects_ProjectId",
                table: "UsersProjects",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersProjects_Users_UserId",
                table: "UsersProjects",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlarmEventDescriptions_AlarmEvents_AlarmEventId",
                table: "AlarmEventDescriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_AlarmEvents_Company_CompanyId",
                table: "AlarmEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_AlarmEventsLive_Processess_ProcessId",
                table: "AlarmEventsLive");

            migrationBuilder.DropForeignKey(
                name: "FK_ParameterDescriptions_Parameters_ParameterId",
                table: "ParameterDescriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_ParameterReportTasks_Projects_ProjectId",
                table: "ParameterReportTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Parameters_Company_CompanyId",
                table: "Parameters");

            migrationBuilder.DropForeignKey(
                name: "FK_Parameters_ParameterGroups_ParameterGroupId",
                table: "Parameters");

            migrationBuilder.DropForeignKey(
                name: "FK_ParametersProcesses_Parameters_ParameterId",
                table: "ParametersProcesses");

            migrationBuilder.DropForeignKey(
                name: "FK_ParametersProcesses_Processess_ProcessId",
                table: "ParametersProcesses");

            migrationBuilder.DropForeignKey(
                name: "FK_ParametersReportTaskWorkEmail_ParameterReportTasks_Paramete~",
                table: "ParametersReportTaskWorkEmail");

            migrationBuilder.DropForeignKey(
                name: "FK_ParametersReportTaskWorkEmail_WorkEmails_WorkEmailId",
                table: "ParametersReportTaskWorkEmail");

            migrationBuilder.DropForeignKey(
                name: "FK_ParameterValues_ParameterValuesGroups_ParameterValuesGroupId",
                table: "ParameterValues");

            migrationBuilder.DropForeignKey(
                name: "FK_ParameterValuesGroups_Processess_ProcessId",
                table: "ParameterValuesGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_ProcessDescriptions_Processess_ProcessId",
                table: "ProcessDescriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Processess_Projects_ProjectId",
                table: "Processess");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectActionsInfos_Projects_ProjectId",
                table: "ProjectActionsInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Company_CompanyId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersProjects_Projects_ProjectId",
                table: "UsersProjects");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersProjects_Users_UserId",
                table: "UsersProjects");

            migrationBuilder.AddForeignKey(
                name: "FK_AlarmEventDescriptions_AlarmEvents_AlarmEventId",
                table: "AlarmEventDescriptions",
                column: "AlarmEventId",
                principalTable: "AlarmEvents",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_AlarmEvents_Company_CompanyId",
                table: "AlarmEvents",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_AlarmEventsLive_Processess_ProcessId",
                table: "AlarmEventsLive",
                column: "ProcessId",
                principalTable: "Processess",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_ParameterDescriptions_Parameters_ParameterId",
                table: "ParameterDescriptions",
                column: "ParameterId",
                principalTable: "Parameters",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_ParameterReportTasks_Projects_ProjectId",
                table: "ParameterReportTasks",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Parameters_Company_CompanyId",
                table: "Parameters",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Parameters_ParameterGroups_ParameterGroupId",
                table: "Parameters",
                column: "ParameterGroupId",
                principalTable: "ParameterGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_ParametersProcesses_Parameters_ParameterId",
                table: "ParametersProcesses",
                column: "ParameterId",
                principalTable: "Parameters",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_ParametersProcesses_Processess_ProcessId",
                table: "ParametersProcesses",
                column: "ProcessId",
                principalTable: "Processess",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_ParametersReportTaskWorkEmail_ParameterReportTasks_Paramete~",
                table: "ParametersReportTaskWorkEmail",
                column: "ParameterReportTaskId",
                principalTable: "ParameterReportTasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_ParametersReportTaskWorkEmail_WorkEmails_WorkEmailId",
                table: "ParametersReportTaskWorkEmail",
                column: "WorkEmailId",
                principalTable: "WorkEmails",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_ParameterValues_ParameterValuesGroups_ParameterValuesGroupId",
                table: "ParameterValues",
                column: "ParameterValuesGroupId",
                principalTable: "ParameterValuesGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_ParameterValuesGroups_Processess_ProcessId",
                table: "ParameterValuesGroups",
                column: "ProcessId",
                principalTable: "Processess",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_ProcessDescriptions_Processess_ProcessId",
                table: "ProcessDescriptions",
                column: "ProcessId",
                principalTable: "Processess",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Processess_Projects_ProjectId",
                table: "Processess",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectActionsInfos_Projects_ProjectId",
                table: "ProjectActionsInfos",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Company_CompanyId",
                table: "Projects",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersProjects_Projects_ProjectId",
                table: "UsersProjects",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersProjects_Users_UserId",
                table: "UsersProjects",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
