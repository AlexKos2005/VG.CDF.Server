using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VG.CDF.Server.Domain.Entities
{
    [Index(nameof(FactoryId), IsUnique = true)]
    public class TagReportTask
    {
        public TagReportTask()
        {
            WorkEmails = new List<WorkEmail>();
        }
        [Key]
        public int Id { get; set; }
        public int FactoryId { get; set; }

        [ForeignKey(nameof(FactoryId))]
        public Factory Factory { get; set; }

        public bool IsActive { get; set; }

        public DateTime? LastSendDt { get; set; }
        
        public ReportTaskStatus Status { get; set; }
        
        public ICollection<WorkEmail> WorkEmails { get; set; }

    }
}
