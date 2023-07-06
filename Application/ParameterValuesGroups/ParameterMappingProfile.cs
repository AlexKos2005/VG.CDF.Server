using AutoMapper;
using VG.CDF.Server.Application.Dto;
using VG.CDF.Server.Application.ParameterDescriptions.Commands;
using VG.CDF.Server.Application.ProcessDescriptions.Commands;
using VG.CDF.Server.Application.Processes.Commands;
using VG.CDF.Server.Application.Projects.Commands;
using VG.CDF.Server.Domain.Entities;

namespace VG.CDF.Server.Application.ParameterValuesGroups;

public class ParameterValuesGroupMappingProfile : Profile
{
    public ParameterValuesGroupMappingProfile()
    {
        CreateMap<ParameterValuesGroupDto, ParameterValuesGroup>().ReverseMap();
    }
}