using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VG.CDF.Server.Domain.Entities
{
    [Index(nameof(ExternalId), IsUnique = true)]
    public class Process
    {
        public Process()
        {
            TagsDevices = new List<ParameterProcess>();
            AlarmEvents = new List<AlarmEvent>();
            ProcessDescriptions = new List<ProcessDescription>();
        }
        [Key]
        public Guid Id { get; set; }
        public int ExternalId { get; set; }
        public int DeviceCode { get; set; }
        public string DeviceIp { get; set; }

        public int ProjectId { get; set; }

        [ForeignKey(nameof(ProjectId))]
        public Project Project { get; set; }

        public List<ParameterProcess> TagsDevices { get; set; }

        public List<AlarmEvent> AlarmEvents { get; set; }

        public List<ProcessDescription> ProcessDescriptions { get; set; }

    }
}
