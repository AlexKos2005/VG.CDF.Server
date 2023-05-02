using BreadCommunityWeb.Blz.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadCommunityWeb.Blz.Domain.Entities
{
    [Index(nameof(DeviceId), nameof(DescriptionsLanguageId), IsUnique = true)]
    public class DeviceDescription
    {
        [Key]
        public int Id { get; set; }

        public string Description { get; set; }

        public int DeviceId { get; set; }

        [ForeignKey(nameof(DeviceId))]
        public Device Device { get; set; }

        public int DescriptionsLanguageId { get; set; }

        [ForeignKey(nameof(DescriptionsLanguageId))]
        public DescriptionsLanguage DescriptionsLanguage { get; set; }
    }
}
