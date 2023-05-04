using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BreadCommunityWeb.Blz.Application.Interfaces.Services;
using VG.CDF.Server.Application.Dto.RequestDto;
using VG.CDF.Server.Application.Dto.ResponseDto;
using VG.CDF.Server.Application.Interfaces.Repositories;

namespace VG.CDF.Server.Infrastructure.Services
{
    public class DoseWaService : IDoseWaService
    {
        private readonly IDoseWaRepository _doseWaRepository;
        private readonly IMapper _mapper;
        public DoseWaService(IDoseWaRepository doseWaRepository, IMapper mapper)
        {
            _doseWaRepository = doseWaRepository;
            _mapper = mapper;
            
        }
        public async Task<List<DoseWaResponseDto>> GetDosesWaByEnterpriseUIdAndDatesWithResult(int factoryExternalId, string ip, string code, DateTime startDate, DateTime endDate)
        {
            var result = await _doseWaRepository.GetDosesWaByEnterpriseUIdAndDatesWithResult(factoryExternalId, ip, code, startDate, endDate);
            if (result == null)
            {
                return new List<DoseWaResponseDto>();
            }

            return _mapper.Map<List<DoseWaResponseDto>>(result);
        }

        public async Task<List<DoseWaResponseDto>?> GetDosesWaWithResult(int factoryExternalId)
        {
            throw new NotImplementedException();
        }

        public async Task SetDosesWaWithResult(List<DoseWaRequestDto> dosesWa)
        {
            throw new NotImplementedException();
        }
    }
}
