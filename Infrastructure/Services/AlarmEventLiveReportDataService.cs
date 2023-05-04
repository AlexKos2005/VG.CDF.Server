using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NLog;
using VG.CDF.Server.Application.Dto.Client;
using VG.CDF.Server.Application.Interfaces.Services;
using VG.CDF.Server.Application.Models.ExcelModels;
using VG.CDF.Server.Domain.Entities;
using VG.CDF.Server.Infrastructure.Configurations;
using VG.CDF.Server.Infrastructure.DataContext;

namespace VG.CDF.Server.Infrastructure.Services
{
    public class AlarmEventLiveReportDataService : IReportDataService<AlarmEventsReportDataInfo>
    {
        const string DEFAULT_ALARM_EVENT_DESCRIPTION = "DEFAULT_ALARM_EVENT_DESCRIPTION";
        const string DEFAULT_DEVICE_DESCRIPTION = "DEFAULT_DEVICE_DESCRIPTION";
        const string DEFAULT_FACTORY_DESCRIPTION = "DEFAULT_FACTORY_DESCRIPTION";

        private readonly DbConnectionConfig _dbConnectionConfig;
        private readonly ILogger _logger;
        public AlarmEventLiveReportDataService(
            DbConnectionConfig dbConnectionConfig,
            IMapper mapper)
        {
            _dbConnectionConfig = dbConnectionConfig;
            _logger = LogManager.GetCurrentClassLogger();
        }

        public async Task<ExcelReportData?> GetExcelReportData(AlarmEventsReportDataInfo reportDataInfo)
        {
            var excelReportData = new ExcelReportData();
            var excelSheet = new ExcelSheet();
            var collumnDatas = new List<CollumnData>();
            var devices = new List<Device>();
            using var db = new SqlDataContext(_dbConnectionConfig);
            //находим предприятие
            var factory = await db.Factories.Where(c=>c.Id == reportDataInfo.FactoryId).FirstOrDefaultAsync();
            if (factory == null)
            {
                return null;
            }

            //получаем все девайсы
            foreach (var dev in reportDataInfo.Devices)
            {
                if(dev.IsEnabled)
                {
                    devices.Add(db.Devices.Where(c => c.FactoryId == factory.Id && c.ExternalId == dev.ExternalId)
                .Include(c => c.DeviceDescriptions).ThenInclude(c => c.DescriptionsLanguage).FirstOrDefault());
                }
            }
   
            
            if (devices.Any() == false)
            {
                return null;
            }

            //получаем все параметры тегов
            var alarmEvents = await db.AlarmEvents.Where(c => c.Device.FactoryId == factory.Id)
                .Include(c=>c.AlarmEventDescriptions).ThenInclude(c=>c.DescriptionsLanguage).ToListAsync();

            //ищем все реал-тайм теги по девайсам
            var alarmEventsLive = new List<AlarmEventLive>();
            foreach(var device in devices)
            {
                var alarmsLive = await db.AlarmEventsLive
                    .Where(c => c.DeviceExternalId == device.ExternalId && c.DateTime>=reportDataInfo.StartDateTime && c.DateTime<=reportDataInfo.EndDateTime)
                    .ToListAsync();
                if(alarmsLive.Any())
                {
                    alarmEventsLive.AddRange(alarmsLive);
                }
            }

            //сортируем
            alarmEventsLive = alarmEventsLive.OrderBy(c => c.DateTime).ThenBy(c => c.DeviceExternalId).ToList();

            //заполняем лист данными
            excelReportData.ExcelFileName = $"{factory.Description} отчет-аварии {reportDataInfo.StartDateTime} - {reportDataInfo.EndDateTime}";
            excelSheet.AdditionalInfo = await GetAdditionalInfo(factory.Description);

            //первый столбец - Дата-время
            //второй-девайс
            //третий-имя события

            var collumnData1 = new CollumnData();
            collumnData1.CollumnIdValue = 1;
            collumnData1.CollumnName = "Дата/Время";

            var collumnData2 = new CollumnData();
            collumnData2.CollumnIdValue = 2;
            collumnData2.CollumnName = "Устройство";

            var collumnData3 = new CollumnData();
            collumnData3.CollumnIdValue = 3;
            collumnData3.CollumnName = "Название";

            foreach (var alarmEventLive in alarmEventsLive)
            {
                collumnData1.Values.Add(alarmEventLive.DateTime.ToString());

                var devDescr = devices.Where(c => c.ExternalId == alarmEventLive.DeviceExternalId).FirstOrDefault()?
                        .DeviceDescriptions.Where(c=>c.DescriptionsLanguage.LanguageExternalId == reportDataInfo.LanguageExternalId).FirstOrDefault()?.Description;
                if (devDescr == null)
                {
                    collumnData2.Values.Add(DEFAULT_DEVICE_DESCRIPTION);
                }
                else
                {
                    collumnData2.Values.Add(devDescr);
                }

                var alarmEventDescr = alarmEvents.Where(c => c.ExternalId == alarmEventLive.ExternalId).FirstOrDefault()?
                    .AlarmEventDescriptions.Where(c => c.DescriptionsLanguage.LanguageExternalId == reportDataInfo.LanguageExternalId).FirstOrDefault()?.Description;
                if (alarmEventDescr == null)
                {
                    collumnData3.Values.Add(DEFAULT_ALARM_EVENT_DESCRIPTION);
                }
                else
                {
                    collumnData3.Values.Add(alarmEventDescr);
                }


            }

            collumnDatas.Add(collumnData1);
            collumnDatas.Add(collumnData2);
            collumnDatas.Add(collumnData3);
            excelSheet.CollumnDatas.AddRange(collumnDatas);
            excelSheet.SheetName = "Аварийные события";

            excelReportData.ExcelSheets.Add(excelSheet);

            return excelReportData;
        }

        public async Task<ExcelReportData?> GetExcelReportData(int factoryExternalId, int deviceExternalId, DateTime startReportDate, DateTime endReportDate, int languageId)
        {
            var excelReportData = new ExcelReportData();
            var excelSheet = new ExcelSheet();
            var collumnDatas = new List<CollumnData>();

            //var alarmEvents = await _alarmEventLiveService.GetAlarmEventsByFactoryExternalIdAndDeviceExternalId(factoryExternalId, deviceExternalId, startReportDate, endReportDate);
            //var sortedAlarmEvents = alarmEvents.OrderBy(c => c.FactoryExternalId).ThenBy(c => c.DeviceExternalId).ToList();
            //var firstAlarmGroupId = sortedTags[0].TagsGroupId;
            //var firstTagsGroup = sortedTags.Where(c => c.TagsGroupId == firstTagGroupId).ToList();


            return new ExcelReportData();
        }


        private async Task<List<ExcelReportAdditionalInfo>> GetAdditionalInfo(string factoryDescription)
        {
            var listAddInfo = new List<ExcelReportAdditionalInfo>();

            var addInfo1 = new ExcelReportAdditionalInfo();
            addInfo1.CollumnAddress = 1;
            addInfo1.RowAddress = 1;
            addInfo1.Value = "Объект:";
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
