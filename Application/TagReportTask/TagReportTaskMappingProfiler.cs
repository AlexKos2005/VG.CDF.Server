using AutoMapper;
using VG.CDF.Server.Application.Dto;
using VG.CDF.Server.Application.TagReportTask.Commands;

namespace VG.CDF.Server.Application.TagReportTask;

public class TagReportTaskMappingProfiler : Profile
{
    public TagReportTaskMappingProfiler()
    {
        CreateMap<Domain.Entities.TagReportTask, TagReportTaskDto>().ReverseMap();
        CreateMap<CreateTagReportTaskCommand, Domain.Entities.TagReportTask>().ReverseMap();
        CreateMap<DeleteTagReportTaskCommand, Domain.Entities.TagReportTask>().ReverseMap();
        CreateMap<UpdateTagReportTaskCommand, Domain.Entities.TagReportTask>().ReverseMap();
    }
}