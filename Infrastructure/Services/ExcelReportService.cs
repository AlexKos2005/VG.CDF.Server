using System.Collections.Generic;
using OfficeOpenXml;
using VG.CDF.Server.Application.Interfaces.Services;
using VG.CDF.Server.Application.Models.ExcelModels;


namespace VG.CDF.Server.Infrastructure.Services
{
    public class ExcelReportService : IReportService<ExcelPackage>
    {
        private int START_ROW_DATA = 5;
        private int START_COLLUMN_DATA = 1;
        private readonly ExcelReportData _excelReportData;
        public ExcelReportService(ExcelReportData excelReportData)
        {
            ExcelPackage.LicenseContext = LicenseContext.Commercial;
            _excelReportData = excelReportData;
        }
        public ExcelPackage MakeReport()
        {
            var excelPackage = new ExcelPackage();

            foreach (var sheet in _excelReportData.ExcelSheets)
            {
                ExcelWorksheet ws = excelPackage.Workbook.Worksheets.Add(sheet.SheetName);
                SetAdditionalInfo(sheet.AdditionalInfo, ws);
                SetCollumnsNames(sheet.CollumnDatas, ws);
            }

            return excelPackage;
        }

        private void SetAdditionalInfo(List<ExcelReportAdditionalInfo> additionalInfo, ExcelWorksheet ws)
        {
            foreach (var info in additionalInfo)
            {
                ws.Cells[info.RowAddress, info.CollumnAddress].Value = info.Value;
                ws.Cells[info.RowAddress, info.CollumnAddress].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
            }
        }

        private void SetCollumnsNames(List<CollumnData> collumnData, ExcelWorksheet ws)
        {
            int currentCollumn = START_COLLUMN_DATA;
           
            foreach (var collumn in collumnData)
            {
                int currentRow = START_ROW_DATA;
                ws.Cells[currentRow, currentCollumn].Value = collumn.CollumnName;
                ws.Cells[currentRow, currentCollumn].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                currentRow++;

                foreach (var value in collumn.Values)
                {
                    ws.Cells[currentRow, currentCollumn].Value = value;
                    ws.Cells[currentRow, currentCollumn].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    currentRow++;
                }

                currentCollumn++;
            }
        }
    }
}
