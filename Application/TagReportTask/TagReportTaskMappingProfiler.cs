using AutoMapper;
using VG.CDF.Server.Application.Dto;
using VG.CDF.Server.Application.TagReportTask.Commands;

namespace VG.CDF.Server.Application.TagReportTask;

public class TagReportTaskMappingProfiler : Profile
{
    public TagReportTaskMappingProfiler()
    {
        CreateMap<Domain.Entities.ParametersReportTask, TagReportTaskDto>().ReverseMap();
        CreateMap<CreateTagReportTaskCommand, Domain.Entities.ParametersReportTask>().ReverseMap();
        CreateMap<DeleteTagReportTaskCommand, Domain.Entities.ParametersReportTask>().ReverseMap();
        CreateMap<UpdateTagReportTaskCommand, Domain.Entities.ParametersReportTask>().ReverseMap();
    }
}