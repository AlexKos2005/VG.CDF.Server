using AutoMapper;
using VG.CDF.Server.Application.Dto;
using VG.CDF.Server.Application.ProcessDescriptions.Commands;
using VG.CDF.Server.Application.Processes.Commands;
using VG.CDF.Server.Application.Projects.Commands;
using VG.CDF.Server.Domain.Entities;

namespace VG.CDF.Server.Application.ProcessDescriptions;

public class ProcessDescriptionMappingProfile : Profile
{
    public ProcessDescriptionMappingProfile()
    {
        CreateMap<ProcessDescription, ProcessDescriptionDto>().ReverseMap();
        CreateMap<CreateProcessDescriptionCommand, ProcessDescription>().ReverseMap();
        CreateMap<DeleteProcessDescriptionCommand, EntityBase>().ReverseMap();
        CreateMap<UpdateProcessDescriptionCommand, ProcessDescription>().ReverseMap();
    }
}