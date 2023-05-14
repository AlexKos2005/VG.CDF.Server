using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace VG.CDF.Server.Domain.Entities
{
    [Index(nameof(ExternalId), IsUnique = true)]
    public class Project : EntityBase
    {
        public Project()
        {
            UsersFactories = new List<UserProject>();
            Processes = new List<Process>();
            Folders = new List<Folder>();
        }
        [Key]
        public override Guid Id { get; set; }
        public int ExternalId { get; set; }

        public int UtcOffset { get; set; }

        public string Description { get; set; }
        
        public int CompanyId { get; set; }

        [ForeignKey(nameof(CompanyId))]
        public Company Company { get; set; }
        public List<UserProject> UsersFactories { get; set; }

        public List<Process> Processes { get; set; }

        public List<Folder> Folders { get; set; }
        public ProjectActionsInfo ProjectActionsInfo { get; set; }
        
        public ParametersReportTask ParametersReportTask { get; set; }
    }
}
