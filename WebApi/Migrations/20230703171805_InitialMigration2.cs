using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VG.CDF.Server.WebApi.Migrations
{
    public partial class InitialMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlarmEventDescription_AlarmEvents_AlarmEventId",
                table: "AlarmEventDescription");

            migrationBuilder.DropForeignKey(
                name: "FK_AlarmEventDescription_Languages_LanguageId",
                table: "AlarmEventDescription");

            migrationBuilder.DropForeignKey(
                name: "FK_ParameterDescriptions_Languages_LanguageId",
                table: "ParameterDescriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_ProcessDescription_Languages_LanguageId",
                table: "ProcessDescription");

            migrationBuilder.DropForeignKey(
                name: "FK_ProcessDescription_Processess_ProcessId",
                table: "ProcessDescription");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropIndex(
                name: "IX_ParameterDescriptions_LanguageId",
                table: "ParameterDescriptions");

            migrationBuilder.DropIndex(
                name: "IX_ParameterDescriptions_ParameterId",
                table: "ParameterDescriptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProcessDescription",
                table: "ProcessDescription");

            migrationBuilder.DropIndex(
                name: "IX_ProcessDescription_LanguageId",
                table: "ProcessDescription");

            migrationBuilder.DropIndex(
                name: "IX_ProcessDescription_ProcessId",
                table: "ProcessDescription");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AlarmEventDescription",
                table: "AlarmEventDescription");

            migrationBuilder.DropIndex(
                name: "IX_AlarmEventDescription_AlarmEventId",
                table: "AlarmEventDescription");

            migrationBuilder.DropIndex(
                name: "IX_AlarmEventDescription_LanguageId",
                table: "AlarmEventDescription");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "ParameterDescriptions");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "ProcessDescription");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "AlarmEventDescription");

            migrationBuilder.RenameTable(
                name: "ProcessDescription",
                newName: "ProcessDescriptions");

            migrationBuilder.RenameTable(
                name: "AlarmEventDescription",
                newName: "AlarmEventDescriptions");

            migrationBuilder.RenameColumn(
                name: "RusDescription",
                table: "Projects",
                newName: "Description");

            migrationBuilder.AddColumn<string>(
                name: "EngDescription",
                table: "ParameterDescriptions",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UkrDescription",
                table: "ParameterDescriptions",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EngDescription",
                table: "ProcessDescriptions",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UkrDescription",
                table: "ProcessDescriptions",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EngDescription",
                table: "AlarmEventDescriptions",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UkrDescription",
                table: "AlarmEventDescriptions",
                type: "text",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProcessDescriptions",
                table: "ProcessDescriptions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AlarmEventDescriptions",
                table: "AlarmEventDescriptions",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ParameterDescriptions_ParameterId",
                table: "ParameterDescriptions",
                column: "ParameterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProcessDescriptions_ProcessId",
                table: "ProcessDescriptions",
                column: "ProcessId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AlarmEventDescriptions_AlarmEventId",
                table: "AlarmEventDescriptions",
                column: "AlarmEventId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AlarmEventDescriptions_AlarmEvents_AlarmEventId",
                table: "AlarmEventDescriptions",
                column: "AlarmEventId",
                principalTable: "AlarmEvents",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_ProcessDescriptions_Processess_ProcessId",
                table: "ProcessDescriptions",
                column: "ProcessId",
                principalTable: "Processess",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlarmEventDescriptions_AlarmEvents_AlarmEventId",
                table: "AlarmEventDescriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_ProcessDescriptions_Processess_ProcessId",
                table: "ProcessDescriptions");

            migrationBuilder.DropIndex(
                name: "IX_ParameterDescriptions_ParameterId",
                table: "ParameterDescriptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProcessDescriptions",
                table: "ProcessDescriptions");

            migrationBuilder.DropIndex(
                name: "IX_ProcessDescriptions_ProcessId",
                table: "ProcessDescriptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AlarmEventDescriptions",
                table: "AlarmEventDescriptions");

            migrationBuilder.DropIndex(
                name: "IX_AlarmEventDescriptions_AlarmEventId",
                table: "AlarmEventDescriptions");

            migrationBuilder.DropColumn(
                name: "EngDescription",
                table: "ParameterDescriptions");

            migrationBuilder.DropColumn(
                name: "UkrDescription",
                table: "ParameterDescriptions");

            migrationBuilder.DropColumn(
                name: "EngDescription",
                table: "ProcessDescriptions");

            migrationBuilder.DropColumn(
                name: "UkrDescription",
                table: "ProcessDescriptions");

            migrationBuilder.DropColumn(
                name: "EngDescription",
                table: "AlarmEventDescriptions");

            migrationBuilder.DropColumn(
                name: "UkrDescription",
                table: "AlarmEventDescriptions");

            migrationBuilder.RenameTable(
                name: "ProcessDescriptions",
                newName: "ProcessDescription");

            migrationBuilder.RenameTable(
                name: "AlarmEventDescriptions",
                newName: "AlarmEventDescription");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Projects",
                newName: "RusDescription");

            migrationBuilder.AddColumn<Guid>(
                name: "LanguageId",
                table: "ParameterDescriptions",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "LanguageId",
                table: "ProcessDescription",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "LanguageId",
                table: "AlarmEventDescription",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProcessDescription",
                table: "ProcessDescription",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AlarmEventDescription",
                table: "AlarmEventDescription",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Acronym = table.Column<string>(type: "text", nullable: true),
                    ExternalId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ParameterDescriptions_LanguageId",
                table: "ParameterDescriptions",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_ParameterDescriptions_ParameterId",
                table: "ParameterDescriptions",
                column: "ParameterId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessDescription_LanguageId",
                table: "ProcessDescription",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessDescription_ProcessId",
                table: "ProcessDescription",
                column: "ProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_AlarmEventDescription_AlarmEventId",
                table: "AlarmEventDescription",
                column: "AlarmEventId");

            migrationBuilder.CreateIndex(
                name: "IX_AlarmEventDescription_LanguageId",
                table: "AlarmEventDescription",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_AlarmEventDescription_AlarmEvents_AlarmEventId",
                table: "AlarmEventDescription",
                column: "AlarmEventId",
                principalTable: "AlarmEvents",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_AlarmEventDescription_Languages_LanguageId",
                table: "AlarmEventDescription",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_ParameterDescriptions_Languages_LanguageId",
                table: "ParameterDescriptions",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_ProcessDescription_Languages_LanguageId",
                table: "ProcessDescription",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_ProcessDescription_Processess_ProcessId",
                table: "ProcessDescription",
                column: "ProcessId",
                principalTable: "Processess",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
