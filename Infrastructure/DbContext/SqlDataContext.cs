using Microsoft.EntityFrameworkCore;
using VG.CDF.Server.Application.Interfaces;
using VG.CDF.Server.Application.Interfaces.Configurations;
using VG.CDF.Server.Domain.Entities;


namespace VG.CDF.Server.Infrastructure.DataContext
{
    public class SqlDataContext : DbContext, ISqlDataContext
    {
        private readonly IDbConnectionConfig _dbConnection;
        public DbSet<Project> Factories { get; set; }
        public DbSet<ProjectActionsInfo> FactoryActionsInfos { get; set; }
        public DbSet<DoseWa> DosesWa { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserProject> UsersFactories { get; set; }

        public DbSet<Role> Roles { get; set; }
        public DbSet<Folder> Folders { get; set; }
        public DbSet<Domain.Entities.File> Files { get; set; }

       
        public DbSet<ParameterProcess> TagParamsDevices { get; set; }

        public DbSet<Process> Devices { get; set; }

        public DbSet<AlarmEvent> AlarmEvents { get; set; }

        public DbSet<AlarmEventLive> AlarmEventsLive { get; set; }

        public DbSet<AlarmEventDescription> AlarmEventDescriptions { get; set; }

        public DbSet<ParameterValue> TagsLive { get; set; }

        public DbSet<ParameterDescription> TagParamDescriptions { get; set; }

        public DbSet<ParameterValuesGroup> TagsGroups { get; set; }

        public DbSet<Parameter> TagParams { get; set; }
        public DbSet<ParameterGroup> ParameterGroups { get; set; }


        public DbSet<ProcessDescription> DeviceDescriptions { get; set; }

        public DbSet<DescriptionsLanguage> DescriptionsLanguages { get; set; }

        public DbSet<ReportSchema> ReportSchemas { get; set; }

        public DbSet<ParameterReport> TagReportQueues { get; set; }
        
        public DbSet<ParametersReportTask> TagReportTasks { get; set; }
        
        public DbSet<WorkEmail> WorkEmails { get; set; }

       // public DbSet<ParametersReportTaskWorkEmail> ParametersReportTaskWorkEmail { get; set; }

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
            modelBuilder.Entity<User>()
                .HasOne(sc => sc.Role)
                .WithMany(s => s.Users)
                .HasForeignKey(v => v.RoleId);

            modelBuilder.Entity<Project>()
                .HasOne(sc => sc.ProjectActionsInfo)
                .WithOne(s => s.Project)
                .HasForeignKey<ProjectActionsInfo>(s => s.FactoryId);

            modelBuilder.Entity<Project>()
                .HasOne(sc => sc.ParametersReportTask)
                .WithOne(s => s.Project)
                .HasForeignKey<ParametersReportTask>(s=>s.ProjectId);
            
            modelBuilder.Entity<ParametersReportTask>()
                .Property(s => s.Status)
                .HasConversion<int>();



        }


    }
}
