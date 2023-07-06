using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NLog;
using VG.CDF.Server.Application.Dto.Client;
using VG.CDF.Server.Application.Dto.ResponseDto;
using VG.CDF.Server.Application.Interfaces;
using VG.CDF.Server.Application.Interfaces.Services;
using VG.CDF.Server.Application.Models.ExcelModels;
using VG.CDF.Server.Domain.Entities;
using VG.CDF.Server.Domain.Enums;

namespace VG.CDF.Server.Infrastructure.Services
{
    public class ParameterValueReportDataService : IReportDataService<ProcessParametersReportDataInfo>
    {
        const string DEFAULT_TAG_DESCRIPTION = "DEFAULT_TAG_DESCRIPTION";
        const string DEFAULT_DEVICE_DESCRIPTION = "DEFAULT_DEVICE_DESCRIPTION";
        const string DEFAULT_FACTORY_DESCRIPTION = "DEFAULT_FACTORY_DESCRIPTION";
        private readonly ISqlDataContext _sqlDataContext;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public ParameterValueReportDataService(
            
            ISqlDataContext sqlDataContext,
            IMapper mapper)
        {
           
            _sqlDataContext = sqlDataContext;
            _mapper = mapper;
            _logger = LogManager.GetCurrentClassLogger();
        }


        public Task<ExcelReportData?> GetExcelReportData(int projectExternalId, int processExternalId, DateTime startReportDate, DateTime endReportDate,
            LanguageAcronyms languageAcronym)
        {
            throw new NotImplementedException();
        }

        public async Task<ExcelReportData?> GetExcelReportData(ProcessParametersReportDataInfo reportDataInfo)
        {
            var excelReportData = new ExcelReportData();
            var project = await _sqlDataContext.Set<Project>().FirstOrDefaultAsync(c=>c.Id == reportDataInfo.ProjectId);
            if(project==null)
            {
                return null;
            }
            excelReportData.ExcelFileName = $"{project.Description} отчет-статистика {reportDataInfo.StartDateTime} - {reportDataInfo.EndDateTime}";

            foreach (var processParam in reportDataInfo.ProcessParameters)
            {
                if(processParam.Process.IsEnabled)
                {
                    var excelSheet = await GetExcelSheet(project.Id, processParam.Process.Id, processParam.Parameters
                        .Where(c=>c.IsEnabled).Select(c => c.ExternalId).ToList(), 
                        reportDataInfo.StartDateTime, reportDataInfo.EndDateTime, reportDataInfo.LanguageAcronymInt);
                    if (excelSheet != null)
                    {
                        excelReportData.ExcelSheets.Add(excelSheet);
                    }
                }
               
            }

            return excelReportData;
        }
        /*public async Task<ExcelReportData?> GetExcelReportData(int projectExternalId, int processExternalId, DateTime startReportDate, DateTime endReportDate,
            LanguageAcronyms languageAcronym)
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
        }*/

        public async Task<ExcelSheet?> GetExcelSheet(Guid projectId, Guid processId,List<int> paramsExternalIds, DateTime startReportDate, DateTime endReportDate, int languageExternalId)
        {
            var excelSheet = new ExcelSheet();
            var collumnDatas = new List<CollumnData>();

            /*//проверяем наличие языка в системе
            var language = await _languageService.GetByExternalId(languageExternalId);
            if (language == null)
            {
                return null;
            }*/

            //добавляем до. инфу на лист
            var listAddInfo = new List<ExcelReportAdditionalInfo>();
            var project = await _sqlDataContext.Set<Project>().FirstOrDefaultAsync(c=>c.Id == projectId);
            if (project == null)
            {
                excelSheet.AdditionalInfo.AddRange(await GetAdditionalInfo(DEFAULT_FACTORY_DESCRIPTION));
            }
            else
            {
                excelSheet.AdditionalInfo.AddRange(await GetAdditionalInfo(project.Description));
            }

            //присваиваем имя листу по названию девайса
            var descriptionForDevice = await _sqlDataContext.Set<ProcessDescription>()
                .FirstOrDefaultAsync(c => c.ProcessId == processId);
            if (descriptionForDevice == null)
            {
                excelSheet.SheetName = DEFAULT_DEVICE_DESCRIPTION;
            }
            else
            {
               
                if(languageExternalId == (int)LanguageAcronyms.Ukr)
                {
                    excelSheet.SheetName = descriptionForDevice.UkrDescription;
                }
                else
                {
                    excelSheet.SheetName = descriptionForDevice.RusDescription;
                }
            }
            
            //проверяем, есть ли теги по нужному устройству и периоду
            var paramsLive = await _sqlDataContext.Set<ParameterValue>()
                .Where(c => c.ProcessId == processId && c.DateTime >= startReportDate.ToUniversalTime() && c.DateTime <= endReportDate.ToUniversalTime())
                .ToListAsync();

            //если нет, то просто заполняем названия столбцов по входным tagParamExternalId
            if(paramsLive.Any() == false)
            {
                collumnDatas.AddRange(await GetColumnDatasByTagExternalIds(processId, paramsExternalIds, languageExternalId));
            }
            //заполняем по первой строке тегов
            else
            {
                var concreteTags = GetTagParamsByConcreteExternalIdList(paramsLive, paramsExternalIds);
                var sortedGroupId = concreteTags.OrderBy(c => c.ParameterExternalId).OrderBy(c => c.DateTime).GroupBy(c => c.ParameterValuesGroupId);

                collumnDatas.AddRange(await SetCollumnNames(paramsExternalIds, languageExternalId));

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

        private async Task<List<CollumnData>> GetColumnDatasByTagExternalIds(Guid processId, List<int> parametersExternalIds,int languageExternalId)
        {
            var collumnDatas = new  List<CollumnData>();
            //заполнили навазния столбцов
            foreach (var tagParamExternalId in parametersExternalIds)
            {
                var collumnData = new CollumnData();
                collumnData.CollumnIdValue = tagParamExternalId;
                var paramDescr = await _sqlDataContext.Set<ParameterDescription>()
                    .FirstOrDefaultAsync(c => c.Parameter.ExternalId == tagParamExternalId);
   
                if (paramDescr == null)
                {
                    collumnData.CollumnName = DEFAULT_TAG_DESCRIPTION;
                }
                else if(languageExternalId == (int)LanguageAcronyms.Ukr)
                {
                    collumnData.CollumnName = paramDescr.UkrDescription;
                }
                else
                {
                    collumnData.CollumnName = paramDescr.RusDescription;
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

                var paramDescr = await _sqlDataContext.Set<ParameterDescription>()
                    .FirstOrDefaultAsync(c => c.Parameter.ExternalId == extId);

                collumnData.CollumnIdValue = extId;
               
                if (paramDescr == null)
                {
                    collumnData.CollumnName = DEFAULT_TAG_DESCRIPTION;
                }
                else if(languageExternalId == (int)LanguageAcronyms.Ukr)
                {
                    collumnData.CollumnName = paramDescr.UkrDescription;
                }
                else
                {
                    collumnData.CollumnName = paramDescr.RusDescription;
                }

                collumnDatas.Add(collumnData);
            }

            return collumnDatas;
        }

        private void PutDataToColumn(int tagParamsExternalId, CollumnData editableColumnData, IEnumerable<ParameterValue> firstTagsGroup)
        {
            //добавляем в столбец значение столбец значениями

            var tag = firstTagsGroup.FirstOrDefault(c => c.ParameterExternalId == tagParamsExternalId);

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

        private List<ParameterValue> GetTagParamsByConcreteExternalIdList(List<ParameterValue> tagsLive, List<int> externalIdList)
        {
            var concreteExtIdTagParams = new List<ParameterValue>();

            foreach (var tagLive in tagsLive)
            {
                var tag = externalIdList.FirstOrDefault(c => c == tagLive.ParameterExternalId);
                if(tag != default)
                {
                    concreteExtIdTagParams.Add(tagLive);
                }
            }

            return concreteExtIdTagParams;
        }

    }


}
