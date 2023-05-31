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
    public class AlarmEvent : EntityBase
    {
        public int ExternalId { get; set; }
        public int CompanyId { get; set; }

        public Company? Company { get; set; }

        public ICollection<AlarmEventDescription> AlarmEventDescriptions { get; set; }

    }
}
