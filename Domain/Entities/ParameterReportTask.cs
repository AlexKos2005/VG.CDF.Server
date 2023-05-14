﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VG.CDF.Server.Domain.Entities
{
    [Index(nameof(ProjectId), IsUnique = true)]
    public class ParameterReportTask : EntityBase
    {
        public ParameterReportTask()
        {
            WorkEmails = new List<WorkEmail>();
        }
        [Key]
        public override Guid Id { get; set; }
        public Guid ProjectId { get; set; }

        [ForeignKey(nameof(ProjectId))]
        public Project Project { get; set; }

        public bool IsActive { get; set; }

        public DateTime? LastSendDt { get; set; }
        
        public ReportTaskStatus Status { get; set; }
        
        public ICollection<WorkEmail> WorkEmails { get; set; }

    }
}