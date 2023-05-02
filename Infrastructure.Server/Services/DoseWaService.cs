using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BreadCommunityWeb.Blz.Application.Dto.RequestDto;
using BreadCommunityWeb.Blz.Application.Dto.ResponseDto;
using BreadCommunityWeb.Blz.Application.Interfaces.Repositories;
using BreadCommunityWeb.Blz.Application.Interfaces.Services;

namespace BreadCommunityWeb.Blz.Infrastructure.Server.Services
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
