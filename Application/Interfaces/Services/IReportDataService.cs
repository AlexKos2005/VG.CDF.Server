using BreadCommunityWeb.Blz.Application.Dto.Client;
using BreadCommunityWeb.Blz.Application.Models.ExcelModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadCommunityWeb.Blz.Application.Interfaces.Services
{
    public interface IReportDataService<T>
    {
        Task<ExcelReportData?> GetExcelReportData(int factoryExternalId, int deviceExternalId, DateTime startReportDate, DateTime endReportDate, int languageExternalId);

        Task<ExcelReportData?> GetExcelReportData(T reportDataInfo);
    }
}
