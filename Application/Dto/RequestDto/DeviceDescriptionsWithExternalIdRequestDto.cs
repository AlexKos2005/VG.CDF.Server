using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VG.CDF.Server.Application.Dto.RequestDto
{
    public class DeviceDescriptionsWithExternalIdRequestDto
    {
        public int DeviceExternalId { get; set; }

        public DeviceDescriptionRequestDto DeviceDescriptionRequestDto { get;set; }
    }
}
