using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VG.CDF.Server.Application.Models.ExcelModels;

namespace VG.CDF.Server.Application.Interfaces.Services
{
    public interface IReportDataService<T>
    {
        Task<ExcelReportData?> GetExcelReportData(int factoryExternalId, int deviceExternalId, DateTime startReportDate, DateTime endReportDate, int languageExternalId);

        Task<ExcelReportData?> GetExcelReportData(T reportDataInfo);
    }
}
