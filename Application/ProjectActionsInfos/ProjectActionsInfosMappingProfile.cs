using AutoMapper;
using VG.CDF.Server.Application.Dto;
using VG.CDF.Server.Application.ProjectActionsInfos.Commands;
using VG.CDF.Server.Application.Projects.Commands;
using VG.CDF.Server.Domain.Entities;

namespace VG.CDF.Server.Application.ProjectActionsInfos;

public class ProjectActionsInfoMappingProfile : Profile
{
    public ProjectActionsInfoMappingProfile()
    {
        CreateMap<ProjectActionsInfo, ProjectActionsInfoDto>().ReverseMap();
        CreateMap<CreateProjectActionsInfoCommand, EntityBase>().ReverseMap();
        CreateMap<UpdateProjectActionsInfoCommand, EntityBase>().ReverseMap();
    }
}