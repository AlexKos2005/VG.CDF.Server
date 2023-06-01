using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VG.CDF.Server.Domain.Entities
{
    public class Language: EntityBase
    {
        public int ExternalId { get; set; }
        public string Acronym { get; set; }

        public ICollection<ParameterDescription> ParameterDescriptions { get; set; }
        public ICollection<ProcessDescription> ProcessDescriptions { get; set; }

        public ICollection<AlarmEventDescription> AlarmEventDescriptions { get; set; }
    }
}
