using AutoMapper;
using VG.CDF.Server.Application.Dto;
using VG.CDF.Server.Application.Projects.Commands;
using VG.CDF.Server.Domain.Entities;

namespace VG.CDF.Server.Application.Projects;

public class ProjectMappingProfile : Profile
{
    public ProjectMappingProfile()
    {
        CreateMap<Project, ProjectDto>().ReverseMap();
        CreateMap<CreateProjectCommand, Project>().ReverseMap();
        CreateMap<DeleteProjectCommand, EntityBase>().ReverseMap();
        CreateMap<UpdateProjectCommand, Project>().ReverseMap();
    }
}