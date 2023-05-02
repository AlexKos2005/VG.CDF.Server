using AutoMapper;
using BreadCommunityWeb.Blz.Application.Dto;
using BreadCommunityWeb.Blz.Application.WorkEmail.Commands;

namespace BreadCommunityWeb.Blz.Application.WorkEmail;

public class WorkEmailMappingProfiler : Profile
{
    public WorkEmailMappingProfiler()
    {
        CreateMap<Domain.Entities.WorkEmail, WorkEmailDto>().ReverseMap();
        CreateMap<CreateWorkEmailCommand, Domain.Entities.WorkEmail>().ReverseMap();
        CreateMap<DeleteWorkEmailCommand, Domain.Entities.WorkEmail>().ReverseMap();
        CreateMap<UpdateWorkEmailCommand, Domain.Entities.WorkEmail>().ReverseMap();
        CreateMap<AddWorkEmailToTagReportTaskCommand, Domain.Entities.WorkEmail>().ReverseMap();
    }
}