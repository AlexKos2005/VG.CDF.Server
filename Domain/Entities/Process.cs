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
    public class Process: EntityBase
    {
        public int ExternalId { get; set; }
        public int DeviceCode { get; set; }
        public string DeviceIp { get; set; }
        public Guid ProjectId { get; set; }
        public Project Project { get; set; }
        
        public ICollection<ParameterProcess> ParametersProcesses { get; set; }

        public ICollection<AlarmEventLive> AlarmEventLives { get; set; }

        public ICollection<ParameterValuesGroup> ParameterValuesGroups { get; set; }
        public ProcessDescription ProcessDescription { get; set; }

    }
}
