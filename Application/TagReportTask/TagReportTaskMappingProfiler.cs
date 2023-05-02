using AutoMapper;
using BreadCommunityWeb.Blz.Application.Dto;
using BreadCommunityWeb.Blz.Application.TagReportTask.Commands;

namespace BreadCommunityWeb.Blz.Application.TagReportTask;

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