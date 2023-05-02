using AutoMapper;
using BreadCommunityWeb.Blz.Application.Dto.RequestDto;
using BreadCommunityWeb.Blz.Application.Dto.ResponseDto;
using BreadCommunityWeb.Blz.Application.Interfaces.Services;
using BreadCommunityWeb.Blz.Domain.Entities;
using BreadCommunityWeb.Blz.Infrastructure.Server.Configurations;
using BreadCommunityWeb.Blz.Infrastructure.Server.DataContext;
using BreadCommunityWeb.Blz.Infrastructure.Server.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadCommunityWeb.Blz.Infrastructure.Server.Services
{
    public class ReportSchemaService : IReportSchemaService
    {
        private readonly DbConnectionConfig _dbConnectionConfig;
        private readonly IMapper _mapper;
        public ReportSchemaService(DbConnectionConfig dbConnectionConfig, IMapper mapper)
        {
            _dbConnectionConfig = dbConnectionConfig;
            _mapper = mapper;
        }
        public async Task Delete(int id)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var reportSchemaRepository = new ReportSchemaRepository(db);
            await reportSchemaRepository.Delete(id);
        }

        public async Task<ReportSchemaResponseDto?> Get(int id)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var reportSchemaRepository = new ReportSchemaRepository(db);
            var result = await reportSchemaRepository.Get(id);
            return _mapper.Map<ReportSchemaResponseDto>(result);
        }

        public async Task<List<DevicesReportSchemasResponseDto>> GetAllReportSchemas(int userId, int factoryId)
        {
            var devRepSchemas = new List<DevicesReportSchemasResponseDto>();
            using var db = new SqlDataContext(_dbConnectionConfig);
            var factoryRepository = new FactoryRepository(db);
            var deviceRepository = new DeviceRepository(db);
            var reportSchemaRepository = new ReportSchemaRepository(db);

            var allDevices = await deviceRepository.GetAll();
            var devices = allDevices.Where(c => c.FactoryId == factoryId).ToList();

            try
            {
                foreach (var device in devices)
                {
                    var reportSchema = await reportSchemaRepository.GetAllReportSchemas(userId, device.Id);

                    var deviceReports = new DevicesReportSchemasResponseDto();
                    deviceReports.TagParamReportsDict.Add(reportSchema[0].ReportSchemaId, _mapper.Map<List<TagParamReportResponseDto>>(reportSchema));
                    deviceReports.UserId = userId;
                    deviceReports.DeviceId = device.Id;
                    deviceReports.DeviceDescription = device.DeviceDescriptions[0].Description;
                }
            }
            catch(Exception e)
            {

            }

            return devRepSchemas;
           
            
        }

        public async Task Save(ReportSchemaRequestDto entity)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var reportSchemaRepository = new ReportSchemaRepository(db);
            await reportSchemaRepository.Save(_mapper.Map<ReportSchema>(entity));
        }

        public async Task<bool> SaveTagReportQueue(int reportSchemaId, TagParamReportRequestDto tagReportQueue)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var reportSchemaRepository = new ReportSchemaRepository(db);
            return await reportSchemaRepository.SaveTagReportQueue(reportSchemaId,_mapper.Map<TagParamReport>(tagReportQueue));
        }

        public async Task<bool> SaveTagsReportQueue(int reportSchemaId, List<TagParamReportRequestDto> tagsReportQueue)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var reportSchemaRepository = new ReportSchemaRepository(db);
            return await reportSchemaRepository.SaveTagsReportQueue(reportSchemaId, _mapper.Map<List<TagParamReport>>(tagsReportQueue));
        }

        public async Task<ReportSchemaResponseDto?> Update(int id, ReportSchemaRequestDto entity)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var reportSchemaRepository = new ReportSchemaRepository(db);
            var result = await reportSchemaRepository.Update(id,_mapper.Map<ReportSchema>(entity));

            if(result == null)
            {
                return null;
            }

            return _mapper.Map<ReportSchemaResponseDto>(result);
        }

        public async Task<bool> UpdateTagReportQueue(int tagReportId, int reportSchemaId, TagParamReportRequestDto tagReportQueue)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var reportSchemaRepository = new ReportSchemaRepository(db);
            return await reportSchemaRepository.UpdateTagReportQueue(tagReportId,reportSchemaId, _mapper.Map<TagParamReport>(tagReportQueue));
        }

        public async Task<bool> UpdateTagReportQueues(int reportSchemaId, List<TagParamReportRequestDto> tagReportsQueue)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var reportSchemaRepository = new ReportSchemaRepository(db);

            foreach (var tagReportQueue in tagReportsQueue)
            {
                var result = await reportSchemaRepository.UpdateTagReportQueue(tagReportQueue.Id, reportSchemaId, _mapper.Map<TagParamReport>(tagReportQueue));
            }

            return true;
        }
    }
}
