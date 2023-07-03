using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VG.CDF.Server.Domain.Entities
{
    public class ParameterReportTask : EntityBase
    {
        public Guid? ProjectId { get; set; }
        
        public Project? Project { get; set; }

        public bool IsActive { get; set; }

        public DateTime? LastSendDt { get; set; }
        
        public ReportTaskStatus Status { get; set; }
        
        public ICollection<ParametersReportTaskWorkEmail> ParametersReportTaskWorkEmails { get; set; }

    }
}
