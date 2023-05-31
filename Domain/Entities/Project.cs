using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace VG.CDF.Server.Domain.Entities
{
    public class Project : EntityBase
    {
        public int ExternalId { get; set; }

        public int UtcOffset { get; set; }

        public string Description { get; set; }
        
        public Guid CompanyId { get; set; }
        
        public Company? Company { get; set; }
        public ICollection<UserProject> UserProjects { get; set; }

        public ICollection<Process> Processes { get; set; }

        public ICollection<Folder> Folders { get; set; }
        public ProjectActionsInfo? ProjectActionsInfo { get; set; }
        
        public ParameterReportTask ParameterReportTask { get; set; }
    }
}
