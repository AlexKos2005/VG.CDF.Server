using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VG.CDF.Server.Application.Dto.Client
{
    public class DeviceWithDescriptionsDto
    {
        public int Id { get; set; }
        public int ExternalId { get; set; }
        public int DeviceCode { get; set; }
        public string DeviceIp { get; set; }

        public int FactoryId { get; set; }

        public bool IsEnabled { get; set; }

        public List<DescriptionDto> DeviceDescriptions { get; set; }
    }
}
