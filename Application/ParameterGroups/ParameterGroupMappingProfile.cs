using AutoMapper;
using VG.CDF.Server.Application.Dto;
using VG.CDF.Server.Application.ParameterDescriptions.Commands;
using VG.CDF.Server.Application.ParameterGroups.Commands;
using VG.CDF.Server.Application.ProcessDescriptions.Commands;
using VG.CDF.Server.Application.Processes.Commands;
using VG.CDF.Server.Application.Projects.Commands;
using VG.CDF.Server.Domain.Entities;

namespace VG.CDF.Server.Application.ParameterGroups;

public class ParameterGroupMappingProfile : Profile
{
    public ParameterGroupMappingProfile()
    {
        CreateMap<ParameterGroup, ParameterGroupDto>().ReverseMap();
        CreateMap<CreateParameterGroupCommand, EntityBase>().ReverseMap();
        CreateMap<DeleteParameterGroupCommand, EntityBase>().ReverseMap();
        CreateMap<UpdateParameterGroupCommand, EntityBase>().ReverseMap();
    }
}