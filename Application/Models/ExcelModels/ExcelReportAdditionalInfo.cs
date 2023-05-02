using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadCommunityWeb.Blz.Application.Models.ExcelModels
{
   public class ExcelReportAdditionalInfo
    {
        public int CollumnAddress { get; set; }

        public int RowAddress { get; set; }

        public string Value { get; set; }= string.Empty;
    }
}
