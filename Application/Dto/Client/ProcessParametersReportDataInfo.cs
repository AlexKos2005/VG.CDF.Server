using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VG.CDF.Server.Application.Dto.Client
{
    public class ProcessParametersReportDataInfo
    {
        public Guid ProjectId { get; set; }

        public int LanguageAcronymInt { get; set; }

        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }

        public List<ProcessParametersResponseDto> ProcessParameters { get; set; }
    }
}
