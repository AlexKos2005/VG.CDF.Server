using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadCommunityWeb.Blz.Domain.Entities
{
    [Index(nameof(Id), nameof(LanguageLabel), IsUnique = true)]
    public class DescriptionsLanguage
    {
        public DescriptionsLanguage()
        {
            TagDescriptions = new List<TagParamDescription>();
            DeviceDescriptions = new List<DeviceDescription>();
            AlarmEventDescription = new List<AlarmEventDescription>();
        }
        [Key]
        public int Id { get; set; }

        public int LanguageExternalId { get; set; }
        public string LanguageLabel { get; set; }

        public List<TagParamDescription> TagDescriptions { get; set; }
        public List<DeviceDescription> DeviceDescriptions { get; set; }

        public List<AlarmEventDescription> AlarmEventDescription { get; set; }
    }
}
