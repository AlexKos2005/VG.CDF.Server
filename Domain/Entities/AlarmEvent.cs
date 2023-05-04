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
    public class AlarmEvent
    {
        public AlarmEvent()
        {
            AlarmEventDescriptions = new List<AlarmEventDescription>();
        }
        [Key]
        public int Id { get; set; }

        public int ExternalId { get; set; }

        public int DeviceId { get; set; }

        [ForeignKey(nameof(DeviceId))]
        public Device Device { get; set; }

        public List<AlarmEventDescription> AlarmEventDescriptions { get; set; }

    }
}
