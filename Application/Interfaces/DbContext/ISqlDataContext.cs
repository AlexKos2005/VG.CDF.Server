using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VG.CDF.Server.Domain.Entities;

namespace VG.CDF.Server.Application.Interfaces
{
    public interface ISqlDataContext : IDisposable
    {
        public DbSet<Project> Factories { get; set; }
        public DbSet<ProjectActionsInfo> FactoryActionsInfos { get; set; }
        public DbSet<DoseWa> DosesWa { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserProject> UsersFactories { get; set; }

        public DbSet<Role> Roles { get; set; }
        public DbSet<Folder> Folders { get; set; }
        public DbSet<File> Files { get; set; }

       
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

        public DbSet<Language> DescriptionsLanguages { get; set; }

        public DbSet<ReportSchema> ReportSchemas { get; set; }

        public DbSet<ParameterReport> TagReportQueues { get; set; }
        
        public DbSet<Domain.Entities.ParameterReportTask> TagReportTasks { get; set; }
        
        public DbSet<Domain.Entities.WorkEmail> WorkEmails { get; set; }
        
        //public DbSet<ParametersReportTaskWorkEmail> ParametersReportTaskWorkEmail { get; set; }
        
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        public DbSet<TEntity> Set<TEntity>() where TEntity: class;
    }
}
