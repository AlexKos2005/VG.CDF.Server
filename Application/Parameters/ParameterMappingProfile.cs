using AutoMapper;
using VG.CDF.Server.Application.Dto;
using VG.CDF.Server.Application.ParameterDescriptions.Commands;
using VG.CDF.Server.Application.Parameters.Commands;
using VG.CDF.Server.Application.ProcessDescriptions.Commands;
using VG.CDF.Server.Application.Processes.Commands;
using VG.CDF.Server.Application.Projects.Commands;
using VG.CDF.Server.Domain.Entities;

namespace VG.CDF.Server.Application.Parameters;

public class ParameterMappingProfile : Profile
{
    public ParameterMappingProfile()
    {
        CreateMap<Parameter, ParameterDto>().ReverseMap();
        CreateMap<CreateParameterCommand, Parameter>().ReverseMap();
        CreateMap<DeleteParameterCommand, EntityBase>().ReverseMap();
        CreateMap<UpdateParameterCommand, Parameter>().ReverseMap();
    }
}