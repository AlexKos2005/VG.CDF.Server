using System;
using Microsoft.EntityFrameworkCore;
using VG.CDF.Server.Application.Dto;
using VG.CDF.Server.Application.Interfaces;
using VG.CDF.Server.Application.Interfaces.Configurations;
using VG.CDF.Server.Domain.Entities;
using VG.CDF.Server.Domain.Enums;


namespace VG.CDF.Server.WebApi.DataBaseContext
{
    public class SqlDataContext : DbContext, ISqlDataContext
    {

        public DbSet<Project> Projects { get; set; } = null!;
        public DbSet<ProjectActionsInfo> ProjectActionsInfos { get; set; }= null!;
        public DbSet<User> Users { get; set; }= null!;
        public DbSet<UserProject> UsersProjects { get; set; }= null!;

        public DbSet<Role> Roles { get; set; }= null!;


        public DbSet<ParameterProcess> ParametersProcesses { get; set; }= null!;

        public DbSet<Process> Processess { get; set; }= null!;

        public DbSet<AlarmEvent> AlarmEvents { get; set; }= null!;

        public DbSet<AlarmEventLive> AlarmEventsLive { get; set; }= null!;

        public DbSet<AlarmEventDescription> AlarmEventDescriptions { get; set; }= null!;

        public DbSet<ParameterValue> ParameterValues { get; set; }= null!;

        public DbSet<ParameterDescription> ParameterDescriptions { get; set; }= null!;

        public DbSet<ParameterValuesGroup> ParameterValuesGroups { get; set; }= null!;

        public DbSet<Parameter> Parameters { get; set; }= null!;
        public DbSet<ParameterGroup> ParameterGroups { get; set; }= null!;
        
        public DbSet<ProcessDescription> ProcessDescriptions { get; set; }= null!;
        
        public DbSet<ParameterReportTask> ParameterReportTasks { get; set; }= null!;
        public DbSet<WorkEmail> WorkEmails { get; set; }= null!;
        

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseNpgsql(_dbConnection.ConnectionString);
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=volgor_asud;Username=postgres;Password=sa;");
        }*/

        public SqlDataContext(DbContextOptions<SqlDataContext> options)
        :base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>()
                .HasIndex(c => c.Id);

            modelBuilder.Entity<Project>()
                .HasOne(sc => sc.Company)
                .WithMany(s => s.Projects)
                .HasForeignKey(v => v.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<Process>()
                .HasOne(sc => sc.Project)
                .WithMany(s => s.Processes)
                .HasForeignKey(v => v.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<Process>()
                .HasOne(sc => sc.ProcessDescription)
                .WithOne(s => s.Process)
                .HasForeignKey<ProcessDescription>(v => v.ProcessId)
                .OnDelete(DeleteBehavior.Cascade);
            
     
            modelBuilder.Entity<Parameter>()
                .HasOne(sc => sc.Company)
                .WithMany(s => s.Parameters)
                .HasForeignKey(v => v.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<Parameter>()
                .HasOne(sc => sc.ParameterGroup)
                .WithMany(s => s.Parameters)
                .HasForeignKey(v => v.ParameterGroupId)
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<Parameter>()
                .HasOne(sc => sc.ParametersDescription)
                .WithOne(s => s.Parameter)
                .HasForeignKey<ParameterDescription>(v => v.ParameterId)
                .OnDelete(DeleteBehavior.Cascade);
            
            
            modelBuilder.Entity<ParameterProcess>()
                .HasOne(sc => sc.Parameter)
                .WithMany(s => s.ParametersProcesses)
                .HasForeignKey(v => v.ParameterId)
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<ParameterProcess>()
                .HasOne(sc => sc.Process)
                .WithMany(s => s.ParametersProcesses)
                .HasForeignKey(v => v.ProcessId)
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<ParameterValuesGroup>()
                .HasOne(sc => sc.Process)
                .WithMany(s => s.ParameterValuesGroups)
                .HasForeignKey(v => v.ProcessId)
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<ParameterValue>()
                .HasOne(sc => sc.ParameterValuesGroup)
                .WithMany(s => s.ParameterValues)
                .HasForeignKey(v => v.ParameterValuesGroupId)
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<AlarmEvent>()
                .HasOne(sc => sc.Company)
                .WithMany(s => s.AlarmEvents)
                .HasForeignKey(v => v.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<AlarmEvent>()
                .HasOne(sc => sc.AlarmEventDescription)
                .WithOne(s => s.AlarmEvent)
                .HasForeignKey<AlarmEventDescription>(v => v.AlarmEventId)
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<AlarmEventLive>()
                .HasOne(sc => sc.Process)
                .WithMany(s => s.AlarmEventLives)
                .HasForeignKey(v => v.ProcessId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProjectActionsInfo>()
                .HasOne(sc => sc.Project)
                .WithOne(s => s.ProjectActionsInfo)
                .HasForeignKey<ProjectActionsInfo>(v => v.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<UserProject>()
                .HasOne(sc => sc.User)
                .WithMany(s => s.UserProjects)
                .HasForeignKey(v => v.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<UserProject>()
                .HasOne(sc => sc.Project)
                .WithMany(s => s.UserProjects)
                .HasForeignKey(v => v.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<User>()
                .HasOne(sc => sc.Role)
                .WithMany(s => s.Users)
                .HasForeignKey(v => v.RoleId);

            modelBuilder.Entity<Role>()
                .Property(sc => sc.RoleName)
                .HasMaxLength(50);
            
            modelBuilder.Entity<Role>()
                .Property(sc => sc.RoleCode)
                .HasMaxLength(50)
                .HasConversion(
                    v => v.ToString(),
                    v => (RoleCode)Enum.Parse(typeof(RoleCode),v))
                .IsUnicode(false);

            modelBuilder.Entity<ParameterReportTask>()
                .HasOne(c => c.Project)
                .WithOne(c => c.ParameterReportTask)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ParameterReportTask>()
                .Property(sc => sc.Status)
                .HasMaxLength(50)
                .HasConversion(
                    v => v.ToString(),
                    v => (ReportTaskStatus)Enum.Parse(typeof(ReportTaskStatus),v))
                .IsUnicode(false);
           
            modelBuilder.Entity<ParametersReportTaskWorkEmail>()
                .HasOne(sc => sc.ParameterReportTask)
                .WithMany(s => s.ParametersReportTaskWorkEmails)
                .HasForeignKey(v => v.ParameterReportTaskId)
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<ParametersReportTaskWorkEmail>()
                .HasOne(sc => sc.WorkEmail)
                .WithMany(s => s.ParametersReportTaskWorkEmails)
                .HasForeignKey(v => v.WorkEmailId)
                .OnDelete(DeleteBehavior.Cascade);
            
        }


    }
}
