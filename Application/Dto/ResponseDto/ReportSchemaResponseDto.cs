using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VG.CDF.Server.Application.Dto.ResponseDto
{
    public class ReportSchemaResponseDto
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int DeviceId { get; set; }

        public string Description { get; set; }

        public List<TagParamReportResponseDto> TagReportsQueue { get; set; } = new List<TagParamReportResponseDto>();
    }
}
