using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadCommunityWeb.Blz.Application.Dto.RequestDto
{
    public class ReportSchemaRequestDto
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int DeviceId { get; set; }

        public string Description { get; set; }

        public List<TagParamReportRequestDto> TagReportsQueue { get; set; } = new List<TagParamReportRequestDto>();
    }
}
