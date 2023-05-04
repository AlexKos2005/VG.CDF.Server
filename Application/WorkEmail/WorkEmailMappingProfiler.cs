using AutoMapper;
using VG.CDF.Server.Application.Dto;
using VG.CDF.Server.Application.WorkEmail.Commands;

namespace VG.CDF.Server.Application.WorkEmail;

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