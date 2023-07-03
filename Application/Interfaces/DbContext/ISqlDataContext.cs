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
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectActionsInfo> ProjectActionsInfos { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserProject> UsersProjects { get; set; }

        public DbSet<Role> Roles { get; set; }


        public DbSet<ParameterProcess> ParametersProcesses { get; set; }

        public DbSet<Process> Processess { get; set; }

        public DbSet<AlarmEvent> AlarmEvents { get; set; }

        public DbSet<AlarmEventLive> AlarmEventsLive { get; set; }

        public DbSet<AlarmEventDescription> AlarmEventDescriptions { get; set; }

        public DbSet<ParameterValue> ParameterValues { get; set; }

        public DbSet<ParameterDescription> ParameterDescriptions { get; set; }

        public DbSet<ParameterValuesGroup> ParameterValuesGroups { get; set; }

        public DbSet<Parameter> Parameters { get; set; }
        public DbSet<ParameterGroup> ParameterGroups { get; set; }
        
        public DbSet<ProcessDescription> ProcessDescriptions { get; set; }
        
        
        public DbSet<ParameterReportTask> ParameterReportTasks { get; set; }
        
        public DbSet<WorkEmail> WorkEmails { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        public DbSet<TEntity> Set<TEntity>() where TEntity: class;
    }
}
