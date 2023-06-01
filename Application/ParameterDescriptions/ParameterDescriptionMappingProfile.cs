using AutoMapper;
using VG.CDF.Server.Application.Dto;
using VG.CDF.Server.Application.ParameterDescriptions.Commands;
using VG.CDF.Server.Application.ParameterGroups.Commands;
using VG.CDF.Server.Application.ProcessDescriptions.Commands;
using VG.CDF.Server.Application.Processes.Commands;
using VG.CDF.Server.Application.Projects.Commands;
using VG.CDF.Server.Domain.Entities;

namespace VG.CDF.Server.Application.ParameterDescriptions;

public class ParameterDescriptionMappingProfile : Profile
{
    public ParameterDescriptionMappingProfile()
    {
        CreateMap<ParameterDescription, ParameterDescriptionDto>().ReverseMap();
        CreateMap<CreateParameterDescriptionCommand, EntityBase>().ReverseMap();
        CreateMap<DeleteParameterDescriptionCommand, EntityBase>().ReverseMap();
        CreateMap<UpdateParameterDescriptionCommand, EntityBase>().ReverseMap();
    }
}