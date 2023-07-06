using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VG.CDF.Server.WebApi.Migrations
{
    public partial class AddProcessId_To_ParameterValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ProcessId",
                table: "ParameterValues",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProcessId",
                table: "ParameterValues");
        }
    }
}
