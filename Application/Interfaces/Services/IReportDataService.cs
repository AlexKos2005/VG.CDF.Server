using System;
using System.Threading.Tasks;
using VG.CDF.Server.Application.Dto.Client;
using VG.CDF.Server.Application.Models.ExcelModels;
using VG.CDF.Server.Domain.Enums;

namespace VG.CDF.Server.Application.Interfaces.Services;

public interface IReportDataService<T>
{
    Task<ExcelReportData?> GetExcelReportData(int projectExternalId, int processExternalId, DateTime startReportDate, DateTime endReportDate, LanguageAcronyms languageAcronym);

    Task<ExcelReportData?> GetExcelReportData(T reportDataInfo);
}