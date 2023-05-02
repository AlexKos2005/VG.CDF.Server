﻿using AutoMapper;
using BreadCommunityWeb.Blz.Application.Dto.RequestDto;
using BreadCommunityWeb.Blz.Application.Dto.ResponseDto;
using BreadCommunityWeb.Blz.Application.Interfaces.Services;
using BreadCommunityWeb.Blz.Domain.Entities;
using BreadCommunityWeb.Blz.Domain.Enums;
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
    public class DeviceDescriptionService : IDeviceDescriptionService
    {
        private readonly DbConnectionConfig _dbConnectionConfig;
        private readonly IMapper _mapper;
        public DeviceDescriptionService(DbConnectionConfig dbConnectionConfig, IMapper mapper)
        {
            _dbConnectionConfig = dbConnectionConfig;
            _mapper = mapper;
        }

        public async Task Delete(int id)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var deviceDescriptionRepository = new DeviceDescriptionRepository(db);
            await deviceDescriptionRepository.Delete(id);
        }

        public async Task<DeviceDescriptionResponseDto?> Get(int id)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var deviceDescriptionRepository = new DeviceDescriptionRepository(db);
            var result = await deviceDescriptionRepository.Get(id);
            if (result == null)
            {
                return null;
            }
            return _mapper.Map<DeviceDescriptionResponseDto>(result);
        }

        public async Task<DeviceDescriptionResponseDto?> Get(int deviceParamExternalId, int languageExternalId)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var deviceDescriptionRepository = new DeviceDescriptionRepository(db);
            var languageRepository = new LanguageRepository(db);
            var languages = await languageRepository.GetAll();
            var language = languages.Where(c => c.LanguageExternalId == languageExternalId).FirstOrDefault();
            if (language == null)
            {
                return null;
            }

            var descriptionsForDevice = await deviceDescriptionRepository.GetAllByExternalId(deviceParamExternalId);
            if (descriptionsForDevice.Any() == false)
            {
                return null;
            }

            var targetLangDescription = descriptionsForDevice.Where(c => c.DescriptionsLanguageId == language.Id).FirstOrDefault();
            if (targetLangDescription == null)
            {
                return null;
            }

            return _mapper.Map<DeviceDescriptionResponseDto>(targetLangDescription);
        }

        public async Task<List<DeviceDescriptionResponseDto>> GetAll()
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var deviceDescriptionRepository = new DeviceDescriptionRepository(db);
            var result = await deviceDescriptionRepository.GetAll();
            return _mapper.Map<List<DeviceDescriptionResponseDto>>(result);
        }

        public async Task<List<DeviceDescriptionResponseDto>> GetAllDescriptionsByDeviceExternalId(int deviceParamExternalId)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var deviceDescriptionRepository = new DeviceDescriptionRepository(db);
            var descriptionsForDevice = await deviceDescriptionRepository.GetAllByExternalId(deviceParamExternalId);
            if (descriptionsForDevice.Any() == false)
            {
                return new List<DeviceDescriptionResponseDto>();
            }

            return _mapper.Map<List<DeviceDescriptionResponseDto>>(descriptionsForDevice);
        }

        public async Task<LanguageResponseDto?> GetLanguage(int tagDescriptionId)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var deviceDescriptionRepository = new DeviceDescriptionRepository(db);
            var result = await deviceDescriptionRepository.GetLanguage(tagDescriptionId);
            if(result == null)
            {
                return null;
            }
            return _mapper.Map<LanguageResponseDto>(result);
        }

        public async Task Save(DeviceDescriptionRequestDto entity)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var deviceDescriptionRepository = new DeviceDescriptionRepository(db);
            await deviceDescriptionRepository.Save(_mapper.Map<DeviceDescription>(entity));
        }

        public async Task Save(List<DeviceDescriptionRequestDto> tagDescriptions)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var deviceDescriptionRepository = new DeviceDescriptionRepository(db);
            await deviceDescriptionRepository.Save(_mapper.Map<List<DeviceDescription>>(tagDescriptions));
        }

        public async Task<DeviceDescriptionResponseDto?> Update(int id, DeviceDescriptionRequestDto entity)
        {
            using var db = new SqlDataContext(_dbConnectionConfig);
            var deviceDescriptionRepository = new DeviceDescriptionRepository(db);
            var result = await deviceDescriptionRepository.Update(id, _mapper.Map<DeviceDescription>(entity));
            if (result == null)
            {
                return null;
            }

            return _mapper.Map<DeviceDescriptionResponseDto>(result);
        }
    }
}