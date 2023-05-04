using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VG.CDF.Server.Application.Dto.ResponseDto
{
    public class DevicesReportSchemasResponseDto
    {
        public int UserId { get; set; }

        public int DeviceId { get; set; }

        public string DeviceDescription { get; set; }

        public Dictionary<int, List<TagParamReportResponseDto>> TagParamReportsDict { get; set; } = new Dictionary<int, List<TagParamReportResponseDto>>();
    }
}
