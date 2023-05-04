using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using NLog;
using VG.CDF.Server.Application.Dto.Client;
using VG.CDF.Server.Application.Dto.ResponseDto;
using VG.CDF.Server.Application.Interfaces.Services;
using VG.CDF.Server.Application.Models.ExcelModels;

namespace VG.CDF.Server.Infrastructure.Services
{
    public class TagsLiveReportDataService : IReportDataService<TagParamsReportDataInfo>
    {
        const string DEFAULT_TAG_DESCRIPTION = "DEFAULT_TAG_DESCRIPTION";
        const string DEFAULT_DEVICE_DESCRIPTION = "DEFAULT_DEVICE_DESCRIPTION";
        const string DEFAULT_FACTORY_DESCRIPTION = "DEFAULT_FACTORY_DESCRIPTION";
        private readonly ITagsLiveService _tagsLiveService;
        private readonly IFactoryService _factoryService;
        private readonly ITagParamDescriptionService _tagParamDescriptionService;
        private readonly ILanguageService _languageService;
        private readonly IDeviceDescriptionService _deviceDescriptionService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public TagsLiveReportDataService(
            IFactoryService factoryService,
            ITagsLiveService tagsLiveService,
            ITagParamDescriptionService tagParamDescriptionService,
            IDeviceDescriptionService deviceDescriptionService, 
            ILanguageService languageService,
            IMapper mapper)
        {
            _factoryService = factoryService;
            _tagsLiveService = tagsLiveService;
            _tagParamDescriptionService = tagParamDescriptionService;
            _deviceDescriptionService = deviceDescriptionService;
            _languageService = languageService;
            _mapper = mapper;
            _logger = LogManager.GetCurrentClassLogger();
        }

        public async Task<ExcelReportData?> GetExcelReportData(TagParamsReportDataInfo reportDataInfo)
        {
            var excelReportData = new ExcelReportData();
            var factory = await _factoryService.Get(reportDataInfo.FactoryId);
            if(factory==null)
            {
                return null;
            }
            excelReportData.ExcelFileName = $"{factory.Description} отчет-статистика {reportDataInfo.StartDateTime} - {reportDataInfo.EndDateTime}";

            foreach (var deviceTagParam in reportDataInfo.DeviceTagParams)
            {
                if(deviceTagParam.Device.IsEnabled)
                {
                    var excelSheet = await GetExcelSheet(factory.ExternalId, deviceTagParam.Device.ExternalId, deviceTagParam.TagParams.Where(c=>c.IsEnabled).Select(c => c.ExternalId).ToList(), reportDataInfo.StartDateTime, reportDataInfo.EndDateTime, reportDataInfo.LanguageExternalId);
                    if (excelSheet != null)
                    {
                        excelReportData.ExcelSheets.Add(excelSheet);
                    }
                }
               
            }

            return excelReportData;
        }
        public async Task<ExcelReportData?> GetExcelReportData(int factoryExternalId, int deviceExternalId, DateTime startReportDate, DateTime endReportDate, int languageExternalId)
        {
            var excelReportData = new ExcelReportData();
            var excelSheet = new ExcelSheet();
            var collumnDatas = new List<CollumnData>();

            var tags = await _tagsLiveService.Get(factoryExternalId, deviceExternalId, startReportDate, endReportDate);
            var sortedTags = tags.OrderBy(c => c.TagsGroupId).ThenBy(c => c.Id).ToList();
            var firstTagGroupId = sortedTags[0].TagsGroupId;
            var firstTagsGroup = sortedTags.Where(c => c.TagsGroupId == firstTagGroupId).ToList();

            //проверяем наличие языка в системе
            var language = await _languageService.GetByExternalId(languageExternalId);
            if (language == null)
            {
                return null;
            }

            //добавляем до. инфу на лист
            var listAddInfo = new List<ExcelReportAdditionalInfo>();
            var factory = await _factoryService.GetFactoryByExternalId(factoryExternalId);
            if (factory == null)
            {
                excelSheet.AdditionalInfo.AddRange(await GetAdditionalInfo(DEFAULT_FACTORY_DESCRIPTION));
            }
            else
            {
                excelSheet.AdditionalInfo.AddRange(await GetAdditionalInfo(factory.Description));
            }

            //присваиваем имя листу по названию девайса
            var descriptionForDevice = await _deviceDescriptionService.Get(deviceExternalId, languageExternalId);
            if (descriptionForDevice == null)
            {
                excelSheet.SheetName = DEFAULT_DEVICE_DESCRIPTION;
            }
            else
            {
                excelSheet.SheetName = descriptionForDevice.Description;
            }

            excelSheet.CollumnDatas.AddRange(collumnDatas);

            excelReportData.ExcelFileName = "TestFile";
            excelReportData.ExcelSheets.Add(excelSheet);

            return excelReportData;
        }

        public async Task<ExcelSheet?> GetExcelSheet(int factoryExternalId, int deviceExternalId,List<int> tagParamExternalIds, DateTime startReportDate, DateTime endReportDate, int languageExternalId)
        {
            var excelSheet = new ExcelSheet();
            var collumnDatas = new List<CollumnData>();

            //проверяем наличие языка в системе
            var language = await _languageService.GetByExternalId(languageExternalId);
            if (language == null)
            {
                return null;
            }

            //добавляем до. инфу на лист
            var listAddInfo = new List<ExcelReportAdditionalInfo>();
            var factory = await _factoryService.GetFactoryByExternalId(factoryExternalId);
            if (factory == null)
            {
                excelSheet.AdditionalInfo.AddRange(await GetAdditionalInfo(DEFAULT_FACTORY_DESCRIPTION));
            }
            else
            {
                excelSheet.AdditionalInfo.AddRange(await GetAdditionalInfo(factory.Description));
            }

            //присваиваем имя листу по названию девайса
            var descriptionForDevice = await _deviceDescriptionService.Get(deviceExternalId, languageExternalId);
            if (descriptionForDevice == null)
            {
                excelSheet.SheetName = DEFAULT_DEVICE_DESCRIPTION;
            }
            else
            {
                excelSheet.SheetName = descriptionForDevice.Description;
            }

            //проверяем, есть ли теги по нужному устройству и периоду
            var tags = await _tagsLiveService.Get(factoryExternalId, deviceExternalId, startReportDate, endReportDate);

            //если нет, то просто заполняем названия столбцов по входным tagParamExternalId
            if(tags.Any() == false)
            {
                collumnDatas.AddRange(await GetColumnDatasByTagExternalIds(factoryExternalId, tagParamExternalIds, languageExternalId));
            }
            //заполняем по первой строке тегов
            else
            {
                var concreteTags = GetTagParamsByConcreteExternalIdList(tags, tagParamExternalIds);
                var sortedGroupId = concreteTags.OrderBy(c => c.TagsGroupId).OrderBy(c => c.DateTime).GroupBy(c => c.TagsGroupId);

                collumnDatas.AddRange(await SetCollumnNames(tagParamExternalIds, languageExternalId));

                foreach (var columnData in collumnDatas)
                {
                    foreach (var item in sortedGroupId)
                    {
                        PutDataToColumn(columnData.CollumnIdValue, columnData, item.Select(c => c));
                    }
                }
            }

            excelSheet.CollumnDatas.AddRange(collumnDatas);
            return excelSheet;
        }

        private async Task<List<CollumnData>> GetColumnDatasByTagExternalIds(int factoryExternalId, List<int> tagParamExternalIds,int languageExternalId)
        {
            var collumnDatas = new  List<CollumnData>();
            //заполнили навазния столбцов
            foreach (var tagParamExternalId in tagParamExternalIds)
            {
                var collumnData = new CollumnData();
                collumnData.CollumnIdValue = tagParamExternalId;
                var tagParamDesc = await _tagParamDescriptionService.Get(tagParamExternalId, languageExternalId);
                if (tagParamDesc == null)
                {
                    collumnData.CollumnName = DEFAULT_TAG_DESCRIPTION;
                }
                else
                {
                    collumnData.CollumnName = tagParamDesc.Description;
                }

                collumnDatas.Add(collumnData);
            }

            return collumnDatas;
        }

        private async Task<List<CollumnData>> SetCollumnNames(List<int> tagParamExternalIds, int languageExternalId)
        {
            var collumnDatas = new List<CollumnData>();

            //заполнили навазния столбцов
            foreach (var extId in tagParamExternalIds)
            {
                var collumnData = new CollumnData();

                var tagParamDesc = await _tagParamDescriptionService.Get(extId, languageExternalId);

                collumnData.CollumnIdValue = extId;
               
                if (tagParamDesc == null)
                {
                    collumnData.CollumnName = DEFAULT_TAG_DESCRIPTION;
                }
                else
                {
                    collumnData.CollumnName = tagParamDesc.Description;
                }

                collumnDatas.Add(collumnData);
            }

            return collumnDatas;
        }

        private void PutDataToColumn(int tagParamsExternalId, CollumnData editableColumnData, IEnumerable<TagLiveResponseDto> firstTagsGroup)
        {
            //добавляем в столбец значение столбец значениями

            var tag = firstTagsGroup.Where(c => c.TagParamExternalId == tagParamsExternalId).FirstOrDefault();

            if (tag == null)
            {
                editableColumnData.Values.Add("0");
            }
            else
            {
                editableColumnData.Values.Add(tag.Value);
            }

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

        private List<TagLiveResponseDto> GetTagParamsByConcreteExternalIdList(List<TagLiveResponseDto> tagsLive, List<int> externalIdList)
        {
            var concreteExtIdTagParams = new List<TagLiveResponseDto>();

            foreach (var tagLive in tagsLive)
            {
                var tag = externalIdList.Where(c => c == tagLive.TagParamExternalId).FirstOrDefault();
                if(tag != default)
                {
                    concreteExtIdTagParams.Add(tagLive);
                }
            }

            return concreteExtIdTagParams;
        }

    }


}
