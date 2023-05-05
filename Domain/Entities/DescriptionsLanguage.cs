using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VG.CDF.Server.Domain.Entities
{
    [Index(nameof(Id), nameof(Label), IsUnique = true)]
    public class DescriptionsLanguage
    {
        public DescriptionsLanguage()
        {
            ParameterDescriptions = new List<ParameterDescription>();
            ProcessDescriptions = new List<ProcessDescription>();
            AlarmEventDescription = new List<AlarmEventDescription>();
        }
        [Key]
        public Guid Id { get; set; }

        public int ExternalId { get; set; }
        public string Label { get; set; }

        public List<ParameterDescription> ParameterDescriptions { get; set; }
        public List<ProcessDescription> ProcessDescriptions { get; set; }

        public List<AlarmEventDescription> AlarmEventDescription { get; set; }
    }
}
