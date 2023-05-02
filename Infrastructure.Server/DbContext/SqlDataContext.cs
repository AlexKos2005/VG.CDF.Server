using System;
using System.Collections.Generic;
using System.Text;
using BreadCommunityWeb.Blz.Application.Interfaces;
using BreadCommunityWeb.Blz.Domain.Entities;
using BreadCommunityWeb.Blz.Infrastructure.Server.Configurations;
using BreadCommunityWeb.Blz.Infrastructure.Server.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BreadCommunityWeb.Blz.Infrastructure.Server.DataContext
{
    public class SqlDataContext : DbContext, ISqlDataContext
    {
        private readonly IDbConnectionConfig _dbConnection;
        public DbSet<Factory> Factories { get; set; }
        public DbSet<FactoryActionsInfo> FactoryActionsInfos { get; set; }
        public DbSet<DoseWa> DosesWa { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserFactory> UsersFactories { get; set; }

        public DbSet<Role> Roles { get; set; }
        public DbSet<Folder> Folders { get; set; }
        public DbSet<File> Files { get; set; }

       
        public DbSet<TagParamDevice> TagParamsDevices { get; set; }

        public DbSet<Device> Devices { get; set; }

        public DbSet<AlarmEvent> AlarmEvents { get; set; }

        public DbSet<AlarmEventLive> AlarmEventsLive { get; set; }

        public DbSet<AlarmEventDescription> AlarmEventDescriptions { get; set; }

        public DbSet<TagLive> TagsLive { get; set; }

        public DbSet<TagParamDescription> TagParamDescriptions { get; set; }

        public DbSet<TagsGroup> TagsGroups { get; set; }

        public DbSet<TagParam> TagParams { get; set; }
        public DbSet<ParameterGroup> ParameterGroups { get; set; }


        public DbSet<DeviceDescription> DeviceDescriptions { get; set; }

        public DbSet<DescriptionsLanguage> DescriptionsLanguages { get; set; }

        public DbSet<ReportSchema> ReportSchemas { get; set; }

        public DbSet<TagParamReport> TagReportQueues { get; set; }
        
        public DbSet<TagReportTask> TagReportTasks { get; set; }
        
        public DbSet<WorkEmail> WorkEmails { get; set; }

       // public DbSet<TagReportTaskWorkEmail> TagReportTaskWorkEmail { get; set; }

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

            modelBuilder.Entity<Factory>()
                .HasOne(sc => sc.FactoryActionsInfo)
                .WithOne(s => s.Factory)
                .HasForeignKey<FactoryActionsInfo>(s => s.FactoryId);

            modelBuilder.Entity<Factory>()
                .HasOne(sc => sc.TagReportTask)
                .WithOne(s => s.Factory)
                .HasForeignKey<TagReportTask>(s=>s.FactoryId);
            
            modelBuilder.Entity<TagReportTask>()
                .Property(s => s.Status)
                .HasConversion<int>();



        }


    }
}
