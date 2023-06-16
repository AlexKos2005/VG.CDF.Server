using AutoMapper;
using VG.CDF.Server.Application.Dto;
using VG.CDF.Server.Application.Processes.Commands;
using VG.CDF.Server.Application.Projects.Commands;
using VG.CDF.Server.Domain.Entities;

namespace VG.CDF.Server.Application.Processes;

public class ProcessMappingProfile : Profile
{
    public ProcessMappingProfile()
    {
        CreateMap<Process, ProcessDto>().ReverseMap();
        CreateMap<CreateProcessCommand, Process>().ReverseMap();
        CreateMap<DeleteProcessCommand, EntityBase>().ReverseMap();
        CreateMap<UpdateProcessCommand, Process>().ReverseMap();
        
    }
}