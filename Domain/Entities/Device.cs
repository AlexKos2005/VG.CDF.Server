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
    public class Device
    {
        public Device()
        {
            TagsDevices = new List<TagParamDevice>();
            AlarmEvents = new List<AlarmEvent>();
            DeviceDescriptions = new List<DeviceDescription>();
        }
        [Key]
        public int Id { get; set; }
        public int ExternalId { get; set; }
        public int DeviceCode { get; set; }
        public string DeviceIp { get; set; }

        public int FactoryId { get; set; }

        [ForeignKey(nameof(FactoryId))]
        public Factory Factory { get; set; }

        public List<TagParamDevice> TagsDevices { get; set; }

        public List<AlarmEvent> AlarmEvents { get; set; }

        public List<DeviceDescription> DeviceDescriptions { get; set; }

    }
}
