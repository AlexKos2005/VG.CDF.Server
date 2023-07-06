using AutoMapper;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VG.CDF.Server.Application.Dto;
using VG.CDF.Server.Application.Dto.Client;
using VG.CDF.Server.Application.Interfaces;
using VG.CDF.Server.Application.Interfaces.Services;
using VG.CDF.Server.Application.Models.ExcelModels;
using VG.CDF.Server.Domain.Entities;
using VG.CDF.Server.Domain.Enums;
using VG.CDF.Server.Infrastructure.Configurations;

namespace VG.CDF.Server.Infrastructure.Services
{
    public class AlarmEventLiveReportDataService : IReportDataService<AlarmEventsReportDataInfo>
    {
        const string DEFAULT_ALARM_EVENT_DESCRIPTION = "DEFAULT_ALARM_EVENT_DESCRIPTION";
        const string DEFAULT_DEVICE_DESCRIPTION = "DEFAULT_DEVICE_DESCRIPTION";
        const string DEFAULT_FACTORY_DESCRIPTION = "DEFAULT_FACTORY_DESCRIPTION";

        private readonly DbConnectionConfig _dbConnectionConfig;
        private readonly ILogger _logger;
        private readonly ISqlDataContext _sqlDataContext;

        public AlarmEventLiveReportDataService(
            DbConnectionConfig dbConnectionConfig,
            IMapper mapper,
            ISqlDataContext sqlDataContext)
        {
            _dbConnectionConfig = dbConnectionConfig;
            _sqlDataContext = sqlDataContext;
            _logger = LogManager.GetCurrentClassLogger();
        }

        public Task<ExcelReportData?> GetExcelReportData(int projectExternalId, int processExternalId,
            DateTime startReportDate, DateTime endReportDate,
            LanguageAcronyms languageAcronym)
        {
            throw new NotImplementedException();
        }

        public async Task<ExcelReportData?> GetExcelReportData(AlarmEventsReportDataInfo reportDataInfo)
        {
            var excelReportData = new ExcelReportData();
            var excelSheet = new ExcelSheet();
            var collumnDatas = new List<CollumnData>();
            var processes = new List<Process>();
            //находим проект
            var project = await _sqlDataContext.Set<Project>()
                .FirstOrDefaultAsync(c => c.Id == reportDataInfo.ProjectId);
            if (project == null)
            {
                return null;
            }

            //получаем все процессы
            foreach (var process in reportDataInfo.Processes)
            {
                if (process.IsEnabled)
                {
                    processes.Add(
                        await _sqlDataContext.Set<Process>().Where(c => c.Id == process.Id).FirstAsync());
                }


                if (processes.Any() == false)
                {
                    return null;
                }

                //ищем все реал-тайм теги по девайсам
                var alarmEventsLive = new List<AlarmEventLive>();
                foreach (var proc in processes)
                {
                    alarmEventsLive.AddRange(await _sqlDataContext.Set<AlarmEventLive>()
                        .Where(c =>
                            c.ProcessId == proc.Id && c.DateTime >= reportDataInfo.StartDateTime.ToUniversalTime()
                                                   && c.DateTime <= reportDataInfo.EndDateTime.ToUniversalTime())
                        .ToListAsync());
                }

                //сортируем
                alarmEventsLive = alarmEventsLive.OrderBy(c => c.DateTime).ThenBy(c => c.Process.ExternalId).ToList();

                //заполняем лист данными
                excelReportData.ExcelFileName =
                    $"{project.Description} отчет-аварии {reportDataInfo.StartDateTime} - {reportDataInfo.EndDateTime}";
                excelSheet.AdditionalInfo = await GetAdditionalInfo(project.Description);

                //первый столбец - Дата-время
                //второй-девайс
                //третий-имя события

                var collumnData1 = new CollumnData();
                collumnData1.CollumnIdValue = 1;
                collumnData1.CollumnName = "Дата/Время";

                var collumnData2 = new CollumnData();
                collumnData2.CollumnIdValue = 2;
                collumnData2.CollumnName = "Процесс";

                var collumnData3 = new CollumnData();
                collumnData3.CollumnIdValue = 3;
                collumnData3.CollumnName = "Название";

                foreach (var alarmEventLive in alarmEventsLive)
                {
                    collumnData1.Values.Add(alarmEventLive.DateTime.ToString());

                    var processDescr = await _sqlDataContext.Set<ProcessDescription>()
                        .FirstOrDefaultAsync(c => c.ProcessId == alarmEventLive.ProcessId);

                    if (processDescr == null)
                    {
                        collumnData2.Values.Add(DEFAULT_ALARM_EVENT_DESCRIPTION);
                    }
                    else if (reportDataInfo.LanguageAcronymInt == (int)LanguageAcronyms.Ukr)
                    {
                        collumnData2.Values.Add(processDescr.UkrDescription);
                    }
                    else
                    {
                        collumnData2.Values.Add(processDescr.RusDescription);
                    }

                    var alarmEventDescr = await _sqlDataContext.Set<AlarmEventDescription>()
                        .FirstOrDefaultAsync(c =>
                            c.AlarmEvent != null && c.AlarmEvent.ExternalId == alarmEventLive.ExternalId);
                    if (alarmEventDescr == null)
                    {
                        collumnData3.Values.Add(DEFAULT_ALARM_EVENT_DESCRIPTION);
                    }
                    else if (reportDataInfo.LanguageAcronymInt == (int)LanguageAcronyms.Ukr)
                    {
                        collumnData3.Values.Add(alarmEventDescr.UkrDescription);
                    }
                    else
                    {
                        collumnData3.Values.Add(alarmEventDescr.RusDescription);
                    }

                }

                collumnDatas.Add(collumnData1);
                collumnDatas.Add(collumnData2);
                collumnDatas.Add(collumnData3);
                excelSheet.CollumnDatas.AddRange(collumnDatas);
                excelSheet.SheetName = "Аварийные события";

                excelReportData.ExcelSheets.Add(excelSheet);

            }
            return excelReportData;
        }
        
            private async Task<List<ExcelReportAdditionalInfo>> GetAdditionalInfo(string factoryDescription)
            {
                var listAddInfo = new List<ExcelReportAdditionalInfo>();

                var addInfo1 = new ExcelReportAdditionalInfo();
                addInfo1.CollumnAddress = 1;
                addInfo1.RowAddress = 1;
                addInfo1.Value = "Проект:";
                listAddInfo.Add(addInfo1);

                var addInfo2 = new ExcelReportAdditionalInfo();
                addInfo2.CollumnAddress = 2;
                addInfo2.RowAddress = 1;
                addInfo2.Value = factoryDescription;
                listAddInfo.Add(addInfo2);

                var addInfo3 = new ExcelReportAdditionalInfo();
                addInfo3.CollumnAddress = 1;
                addInfo3.RowAddress = 2;
                addInfo3.Value = "Дата создания:";
                listAddInfo.Add(addInfo3);

                var addInfo4 = new ExcelReportAdditionalInfo();
                addInfo4.CollumnAddress = 2;
                addInfo4.RowAddress = 2;
                addInfo4.Value = DateTime.Now.ToString();
                listAddInfo.Add(addInfo4);


                return listAddInfo;

            }
        }
    
}
