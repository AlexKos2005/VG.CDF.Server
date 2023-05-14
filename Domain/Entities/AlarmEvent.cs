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
    public class AlarmEvent : EntityBase
    {
        public AlarmEvent()
        {
            AlarmEventDescriptions = new List<AlarmEventDescription>();
        }
        [Key]
        public override Guid Id { get; set; }

        public int ExternalId { get; set; }

        public int CompanyId { get; set; }
        [ForeignKey(nameof(CompanyId))]
        public Company Company { get; set; }

        public List<AlarmEventDescription> AlarmEventDescriptions { get; set; }

    }
}
