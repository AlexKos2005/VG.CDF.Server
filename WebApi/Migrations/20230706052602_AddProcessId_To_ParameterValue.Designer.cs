﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using VG.CDF.Server.WebApi.DataBaseContext;

#nullable disable

namespace VG.CDF.Server.WebApi.Migrations
{
    [DbContext(typeof(SqlDataContext))]
    [Migration("20230706052602_AddProcessId_To_ParameterValue")]
    partial class AddProcessId_To_ParameterValue
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("VG.CDF.Server.Domain.Entities.AlarmEvent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uuid");

                    b.Property<int>("ExternalId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("AlarmEvents");
                });

            modelBuilder.Entity("VG.CDF.Server.Domain.Entities.AlarmEventDescription", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("AlarmEventId")
                        .HasColumnType("uuid");

                    b.Property<string>("EngDescription")
                        .HasColumnType("text");

                    b.Property<string>("RusDescription")
                        .HasColumnType("text");

                    b.Property<string>("UkrDescription")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AlarmEventId")
                        .IsUnique();

                    b.ToTable("AlarmEventDescriptions");
                });

            modelBuilder.Entity("VG.CDF.Server.Domain.Entities.AlarmEventLive", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("DateTimeOffset")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("ExternalId")
                        .HasColumnType("integer");

                    b.Property<Guid>("ProcessId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ProcessId");

                    b.ToTable("AlarmEventsLive");
                });

            modelBuilder.Entity("VG.CDF.Server.Domain.Entities.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("VG.CDF.Server.Domain.Entities.Parameter", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uuid");

                    b.Property<int>("ExternalId")
                        .HasColumnType("integer");

                    b.Property<Guid?>("ParameterGroupId")
                        .HasColumnType("uuid");

                    b.Property<int>("ValueType")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("ParameterGroupId");

                    b.ToTable("Parameters");
                });

            modelBuilder.Entity("VG.CDF.Server.Domain.Entities.ParameterDescription", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("EngDescription")
                        .HasColumnType("text");

                    b.Property<Guid?>("ParameterId")
                        .HasColumnType("uuid");

                    b.Property<string>("RusDescription")
                        .HasColumnType("text");

                    b.Property<string>("UkrDescription")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ParameterId")
                        .IsUnique();

                    b.ToTable("ParameterDescriptions");
                });

            modelBuilder.Entity("VG.CDF.Server.Domain.Entities.ParameterGroup", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("ExternalId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ParameterGroups");
                });

            modelBuilder.Entity("VG.CDF.Server.Domain.Entities.ParameterProcess", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ParameterId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ProcessId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ParameterId");

                    b.HasIndex("ProcessId");

                    b.ToTable("ParametersProcesses");
                });

            modelBuilder.Entity("VG.CDF.Server.Domain.Entities.ParameterReportTask", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("LastSendDt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("ProjectId")
                        .HasColumnType("uuid");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId")
                        .IsUnique();

                    b.ToTable("ParameterReportTasks");
                });

            modelBuilder.Entity("VG.CDF.Server.Domain.Entities.ParametersReportTaskWorkEmail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ParameterReportTaskId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("WorkEmailId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ParameterReportTaskId");

                    b.HasIndex("WorkEmailId");

                    b.ToTable("ParametersReportTaskWorkEmail");
                });

            modelBuilder.Entity("VG.CDF.Server.Domain.Entities.ParameterValue", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("DateTimeOffset")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("ParameterExternalId")
                        .HasColumnType("integer");

                    b.Property<long>("ParameterValuesGroupId")
                        .HasColumnType("bigint");

                    b.Property<Guid>("ProcessId")
                        .HasColumnType("uuid");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.Property<int>("ValueType")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ParameterValuesGroupId");

                    b.ToTable("ParameterValues");
                });

            modelBuilder.Entity("VG.CDF.Server.Domain.Entities.ParameterValuesGroup", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("DateTimeOffset")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("ProcessId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ProcessId");

                    b.ToTable("ParameterValuesGroups");
                });

            modelBuilder.Entity("VG.CDF.Server.Domain.Entities.Process", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("DeviceCode")
                        .HasColumnType("integer");

                    b.Property<string>("DeviceIp")
                        .HasColumnType("text");

                    b.Property<int>("ExternalId")
                        .HasColumnType("integer");

                    b.Property<Guid?>("ProjectId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("Processess");
                });

            modelBuilder.Entity("VG.CDF.Server.Domain.Entities.ProcessDescription", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("EngDescription")
                        .HasColumnType("text");

                    b.Property<Guid?>("ProcessId")
                        .HasColumnType("uuid");

                    b.Property<string>("RusDescription")
                        .HasColumnType("text");

                    b.Property<string>("UkrDescription")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ProcessId")
                        .IsUnique();

                    b.ToTable("ProcessDescriptions");
                });

            modelBuilder.Entity("VG.CDF.Server.Domain.Entities.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("CompanyId")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int>("ExternalId")
                        .HasColumnType("integer");

                    b.Property<int>("UtcOffset")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("VG.CDF.Server.Domain.Entities.ProjectActionsInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("AlarmMessageCounter")
                        .HasColumnType("integer");

                    b.Property<DateTime>("LastDateTimeConnection")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("LastDateTimeConnectionOffset")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("LastDateTimeReportSending")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("LastDateTimeReportSendingOffset")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("ProjectId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId")
                        .IsUnique();

                    b.ToTable("ProjectActionsInfos");
                });

            modelBuilder.Entity("VG.CDF.Server.Domain.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("RoleCode")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("RoleName")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("VG.CDF.Server.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("VG.CDF.Server.Domain.Entities.UserProject", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.HasIndex("UserId");

                    b.ToTable("UsersProjects");
                });

            modelBuilder.Entity("VG.CDF.Server.Domain.Entities.WorkEmail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("WorkEmails");
                });

            modelBuilder.Entity("VG.CDF.Server.Domain.Entities.AlarmEvent", b =>
                {
                    b.HasOne("VG.CDF.Server.Domain.Entities.Company", "Company")
                        .WithMany("AlarmEvents")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("VG.CDF.Server.Domain.Entities.AlarmEventDescription", b =>
                {
                    b.HasOne("VG.CDF.Server.Domain.Entities.AlarmEvent", "AlarmEvent")
                        .WithOne("AlarmEventDescription")
                        .HasForeignKey("VG.CDF.Server.Domain.Entities.AlarmEventDescription", "AlarmEventId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("AlarmEvent");
                });

            modelBuilder.Entity("VG.CDF.Server.Domain.Entities.AlarmEventLive", b =>
                {
                    b.HasOne("VG.CDF.Server.Domain.Entities.Process", "Process")
                        .WithMany("AlarmEventLives")
                        .HasForeignKey("ProcessId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Process");
                });

            modelBuilder.Entity("VG.CDF.Server.Domain.Entities.Parameter", b =>
                {
                    b.HasOne("VG.CDF.Server.Domain.Entities.Company", "Company")
                        .WithMany("Parameters")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VG.CDF.Server.Domain.Entities.ParameterGroup", "ParameterGroup")
                        .WithMany("Parameters")
                        .HasForeignKey("ParameterGroupId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Company");

                    b.Navigation("ParameterGroup");
                });

            modelBuilder.Entity("VG.CDF.Server.Domain.Entities.ParameterDescription", b =>
                {
                    b.HasOne("VG.CDF.Server.Domain.Entities.Parameter", "Parameter")
                        .WithOne("ParametersDescription")
                        .HasForeignKey("VG.CDF.Server.Domain.Entities.ParameterDescription", "ParameterId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Parameter");
                });

            modelBuilder.Entity("VG.CDF.Server.Domain.Entities.ParameterProcess", b =>
                {
                    b.HasOne("VG.CDF.Server.Domain.Entities.Parameter", "Parameter")
                        .WithMany("ParametersProcesses")
                        .HasForeignKey("ParameterId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("VG.CDF.Server.Domain.Entities.Process", "Process")
                        .WithMany("ParametersProcesses")
                        .HasForeignKey("ProcessId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Parameter");

                    b.Navigation("Process");
                });

            modelBuilder.Entity("VG.CDF.Server.Domain.Entities.ParameterReportTask", b =>
                {
                    b.HasOne("VG.CDF.Server.Domain.Entities.Project", "Project")
                        .WithOne("ParameterReportTask")
                        .HasForeignKey("VG.CDF.Server.Domain.Entities.ParameterReportTask", "ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Project");
                });

            modelBuilder.Entity("VG.CDF.Server.Domain.Entities.ParametersReportTaskWorkEmail", b =>
                {
                    b.HasOne("VG.CDF.Server.Domain.Entities.ParameterReportTask", "ParameterReportTask")
                        .WithMany("ParametersReportTaskWorkEmails")
                        .HasForeignKey("ParameterReportTaskId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("VG.CDF.Server.Domain.Entities.WorkEmail", "WorkEmail")
                        .WithMany("ParametersReportTaskWorkEmails")
                        .HasForeignKey("WorkEmailId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("ParameterReportTask");

                    b.Navigation("WorkEmail");
                });

            modelBuilder.Entity("VG.CDF.Server.Domain.Entities.ParameterValue", b =>
                {
                    b.HasOne("VG.CDF.Server.Domain.Entities.ParameterValuesGroup", "ParameterValuesGroup")
                        .WithMany("ParameterValues")
                        .HasForeignKey("ParameterValuesGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ParameterValuesGroup");
                });

            modelBuilder.Entity("VG.CDF.Server.Domain.Entities.ParameterValuesGroup", b =>
                {
                    b.HasOne("VG.CDF.Server.Domain.Entities.Process", "Process")
                        .WithMany("ParameterValuesGroups")
                        .HasForeignKey("ProcessId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Process");
                });

            modelBuilder.Entity("VG.CDF.Server.Domain.Entities.Process", b =>
                {
                    b.HasOne("VG.CDF.Server.Domain.Entities.Project", "Project")
                        .WithMany("Processes")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Project");
                });

            modelBuilder.Entity("VG.CDF.Server.Domain.Entities.ProcessDescription", b =>
                {
                    b.HasOne("VG.CDF.Server.Domain.Entities.Process", "Process")
                        .WithOne("ProcessDescription")
                        .HasForeignKey("VG.CDF.Server.Domain.Entities.ProcessDescription", "ProcessId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Process");
                });

            modelBuilder.Entity("VG.CDF.Server.Domain.Entities.Project", b =>
                {
                    b.HasOne("VG.CDF.Server.Domain.Entities.Company", "Company")
                        .WithMany("Projects")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Company");
                });

            modelBuilder.Entity("VG.CDF.Server.Domain.Entities.ProjectActionsInfo", b =>
                {
                    b.HasOne("VG.CDF.Server.Domain.Entities.Project", "Project")
                        .WithOne("ProjectActionsInfo")
                        .HasForeignKey("VG.CDF.Server.Domain.Entities.ProjectActionsInfo", "ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Project");
                });

            modelBuilder.Entity("VG.CDF.Server.Domain.Entities.User", b =>
                {
                    b.HasOne("VG.CDF.Server.Domain.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("VG.CDF.Server.Domain.Entities.UserProject", b =>
                {
                    b.HasOne("VG.CDF.Server.Domain.Entities.Project", "Project")
                        .WithMany("UserProjects")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VG.CDF.Server.Domain.Entities.User", "User")
                        .WithMany("UserProjects")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");

                    b.Navigation("User");
                });

            modelBuilder.Entity("VG.CDF.Server.Domain.Entities.AlarmEvent", b =>
                {
                    b.Navigation("AlarmEventDescription");
                });

            modelBuilder.Entity("VG.CDF.Server.Domain.Entities.Company", b =>
                {
                    b.Navigation("AlarmEvents");

                    b.Navigation("Parameters");

                    b.Navigation("Projects");
                });

            modelBuilder.Entity("VG.CDF.Server.Domain.Entities.Parameter", b =>
                {
                    b.Navigation("ParametersDescription");

                    b.Navigation("ParametersProcesses");
                });

            modelBuilder.Entity("VG.CDF.Server.Domain.Entities.ParameterGroup", b =>
                {
                    b.Navigation("Parameters");
                });

            modelBuilder.Entity("VG.CDF.Server.Domain.Entities.ParameterReportTask", b =>
                {
                    b.Navigation("ParametersReportTaskWorkEmails");
                });

            modelBuilder.Entity("VG.CDF.Server.Domain.Entities.ParameterValuesGroup", b =>
                {
                    b.Navigation("ParameterValues");
                });

            modelBuilder.Entity("VG.CDF.Server.Domain.Entities.Process", b =>
                {
                    b.Navigation("AlarmEventLives");

                    b.Navigation("ParameterValuesGroups");

                    b.Navigation("ParametersProcesses");

                    b.Navigation("ProcessDescription");
                });

            modelBuilder.Entity("VG.CDF.Server.Domain.Entities.Project", b =>
                {
                    b.Navigation("ParameterReportTask");

                    b.Navigation("Processes");

                    b.Navigation("ProjectActionsInfo");

                    b.Navigation("UserProjects");
                });

            modelBuilder.Entity("VG.CDF.Server.Domain.Entities.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("VG.CDF.Server.Domain.Entities.User", b =>
                {
                    b.Navigation("UserProjects");
                });

            modelBuilder.Entity("VG.CDF.Server.Domain.Entities.WorkEmail", b =>
                {
                    b.Navigation("ParametersReportTaskWorkEmails");
                });
#pragma warning restore 612, 618
        }
    }
}