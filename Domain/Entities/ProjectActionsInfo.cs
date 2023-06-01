using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VG.CDF.Server.Domain.Entities
{
    public class ProjectActionsInfo : EntityBase
    {
      
        public DateTime LastDateTimeConnection { get; set; }

        public DateTime LastDateTimeReportSending { get; set; }

        public DateTimeOffset LastDateTimeConnectionOffset { get; set; }

        public DateTimeOffset LastDateTimeReportSendingOffset { get; set; }

        public int AlarmMessageCounter { get; set; }

        public Guid ProjectId { get; set; }
        public Project? Project { get; set; }
    }
}
