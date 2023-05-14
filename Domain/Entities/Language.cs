using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VG.CDF.Server.Domain.Entities
{
    [Index(nameof(Id), nameof(Acronym), IsUnique = true)]
    public class Language: EntityBase
    {
        public Language()
        {
            ParameterDescriptions = new List<ParameterDescription>();
            ProcessDescriptions = new List<ProcessDescription>();
            AlarmEventDescription = new List<AlarmEventDescription>();
        }
        [Key]
        public override Guid Id { get; set; }

        public int ExternalId { get; set; }
        public string Acronym { get; set; }

        public List<ParameterDescription> ParameterDescriptions { get; set; }
        public List<ProcessDescription> ProcessDescriptions { get; set; }

        public List<AlarmEventDescription> AlarmEventDescription { get; set; }
    }
}
