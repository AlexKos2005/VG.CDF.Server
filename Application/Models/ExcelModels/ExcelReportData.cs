using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VG.CDF.Server.Application.Models.ExcelModels
{
    public class ExcelReportData
    {
        public string ExcelFileName { get; set; } = string.Empty;
        public List<ExcelSheet> ExcelSheets { get; set; } = new List<ExcelSheet>();

    }
}
