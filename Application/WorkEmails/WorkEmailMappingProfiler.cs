using AutoMapper;
using VG.CDF.Server.Application.Dto;
using VG.CDF.Server.Application.WorkEmails.Commands;

namespace VG.CDF.Server.Application.WorkEmails;

public class WorkEmailMappingProfiler : Profile
{
    public WorkEmailMappingProfiler()
    {
        CreateMap<Domain.Entities.WorkEmail, WorkEmailDto>().ReverseMap();
        CreateMap<CreateWorkEmailCommand, Domain.Entities.WorkEmail>().ReverseMap();
        CreateMap<DeleteWorkEmailCommand, Domain.Entities.WorkEmail>().ReverseMap();
        CreateMap<UpdateWorkEmailCommand, Domain.Entities.WorkEmail>().ReverseMap();
        CreateMap<AddWorkEmailToParameterReportTaskCommand, Domain.Entities.WorkEmail>().ReverseMap();
    }
}