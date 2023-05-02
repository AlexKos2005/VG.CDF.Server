using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadCommunityWeb.Blz.Application.Models.ExcelModels
{
    public class ExcelSheet
    {
        public string SheetName { get; set; } = string.Empty;
        public List<ExcelReportAdditionalInfo> AdditionalInfo { get; set; } = new List<ExcelReportAdditionalInfo>();
        public List<CollumnData> CollumnDatas { get; set; } = new List<CollumnData>();
    }
}
