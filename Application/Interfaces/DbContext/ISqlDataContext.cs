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
        
        public DbSet<Domain.Entities.TagReportTask> TagReportTasks { get; set; }
        
        public DbSet<Domain.Entities.WorkEmail> WorkEmails { get; set; }
        
        //public DbSet<TagReportTaskWorkEmail> TagReportTaskWorkEmail { get; set; }
        
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        public DbSet<TEntity> Set<TEntity>() where TEntity: class;
    }
}
