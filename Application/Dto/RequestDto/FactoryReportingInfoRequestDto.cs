using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VG.CDF.Server.Application.Dto.RequestDto
{
    public class FactoryReportingInfoRequestDto
    {
        public int FactoryExternalId { get; set; }

        public DateTime DateTime { get; set; }

        public DateTimeOffset DateTimeOffset { get; set; }
    }
}
