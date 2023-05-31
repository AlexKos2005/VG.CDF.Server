using System;
using Microsoft.EntityFrameworkCore;
using VG.CDF.Server.Application.Dto;
using VG.CDF.Server.Application.Interfaces;
using VG.CDF.Server.Application.Interfaces.Configurations;
using VG.CDF.Server.Domain.Entities;


namespace VG.CDF.Server.WebApi.DataBaseContext
{
    public class SqlDataContext : DbContext, ISqlDataContext
    {
        private readonly IDbConnectionConfig _dbConnection;

        public DbSet<Project> Projects { get; set; } = null!;
        public DbSet<ProjectActionsInfo> ProjectActionsInfos { get; set; }= null!;
        public DbSet<DoseWa> DosesWa { get; set; }= null!;
        public DbSet<User> Users { get; set; }= null!;
        public DbSet<UserProject> UsersProjects { get; set; }= null!;

        public DbSet<Role> Roles { get; set; }= null!;
        public DbSet<Folder> Folders { get; set; }= null!;
        public DbSet<File> Files { get; set; }= null!;

       
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

        public DbSet<Language> Languages { get; set; }= null!;
        public DbSet<ReportSchema> ReportSchemas { get; set; }= null!;
        public DbSet<ParameterReport> ParameterReports { get; set; }= null!;
        public DbSet<ParameterReportTask> ParameterReportTasks { get; set; }= null!;
        public DbSet<WorkEmail> WorkEmails { get; set; }= null!;
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(_dbConnection.ConnectionString);
            //optionsBuilder.UseSqlServer(@"Data Source = 31.31.198.169; Database = u1135159_BreadCommWeb; Integrated Security = False; User ID = u1135159_brcomm; Password = Qwerty12345");
            //optionsBuilder.UseSqlServer(@"Data Source = 37.140.192.55; Database = u1135159_BreadCommWeb; Integrated Security = False; User ID = u1135159_brcomm; Password = Qwerty12345");
            //optionsBuilder.UseSqlServer(@"Data Source = WIN-5ADDIEFMN79\SQLEXPRESS; Initial Catalog = Ent5; Integrated Security = True");
            optionsBuilder.UseNpgsql(_dbConnection.ConnectionString);

            //@"Data Source = WIN-5ADDIEFMN79\SQLEXPRESS; Initial Catalog = Ent5; Integrated Security = True"
        }

        public SqlDataContext(IDbConnectionConfig dbConnection)
        {
            _dbConnection = dbConnection;
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
                .OnDelete(DeleteBehavior.SetNull);
            
            modelBuilder.Entity<Process>()
                .HasOne(sc => sc.Project)
                .WithMany(s => s.Processes)
                .HasForeignKey(v => v.ProjectId)
                .OnDelete(DeleteBehavior.SetNull);
            
            modelBuilder.Entity<Parameter>()
                .HasOne(sc => sc.Company)
                .WithMany(s => s.Parameters)
                .HasForeignKey(v => v.CompanyId)
                .OnDelete(DeleteBehavior.SetNull);
            
            modelBuilder.Entity<ParameterProcess>()
                .HasOne(sc => sc.Parameter)
                .WithMany(s => s.ParametersProcesses)
                .HasForeignKey(v => v.ParameterId)
                .OnDelete(DeleteBehavior.SetNull);
            
            modelBuilder.Entity<ParameterProcess>()
                .HasOne(sc => sc.Process)
                .WithMany(s => s.ParametersProcesses)
                .HasForeignKey(v => v.ProcessId)
                .OnDelete(DeleteBehavior.SetNull);
            
            modelBuilder.Entity<ProjectActionsInfo>()
                .HasOne(sc => sc.Project)
                .WithOne(s => s.ProjectActionsInfo)
                .HasForeignKey<ProjectActionsInfo>(v => v.ProjectId)
                .OnDelete(DeleteBehavior.SetNull);
            
            modelBuilder.Entity<UserProject>()
                .HasOne(sc => sc.User)
                .WithMany(s => s.UserProjects)
                .HasForeignKey(v => v.UserId)
                .OnDelete(DeleteBehavior.SetNull);
            
            modelBuilder.Entity<UserProject>()
                .HasOne(sc => sc.Project)
                .WithMany(s => s.UserProjects)
                .HasForeignKey(v => v.ProjectId)
                .OnDelete(DeleteBehavior.SetNull);
            
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
                    v => (RoleCodes)Enum.Parse(typeof(RoleCodes),v))
                .IsUnicode(false);

            modelBuilder.Entity<ParameterReportTask>()
                .HasOne(c => c.Project)
                .WithOne(c => c.ParameterReportTask)
                .OnDelete(DeleteBehavior.SetNull);

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
                .OnDelete(DeleteBehavior.SetNull);
            
            modelBuilder.Entity<ParametersReportTaskWorkEmail>()
                .HasOne(sc => sc.WorkEmail)
                .WithMany(s => s.ParametersReportTaskWorkEmails)
                .HasForeignKey(v => v.WorkEmailId)
                .OnDelete(DeleteBehavior.SetNull);

//-------------------------------------------------------------------------------------


            
            
            modelBuilder.Entity<ParameterReportTask>()
                .Property(s => s.Status)
                .HasConversion<int>();
        }


    }
}
