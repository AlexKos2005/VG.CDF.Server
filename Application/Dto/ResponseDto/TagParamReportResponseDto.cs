using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadCommunityWeb.Blz.Application.Dto.ResponseDto
{
    public class TagParamReportResponseDto
    {
        public int Id { get; set; }

        public int NumberInQueue { get; set; }

        public int ReportSchemaId { get; set; }
        public int TagParamId { get; set; }
    }
}
