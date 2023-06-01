using AutoMapper;
using VG.CDF.Server.Application.Dto;
using VG.CDF.Server.Application.ParameterReportTasks.Commands;

namespace VG.CDF.Server.Application.ParameterReportTasks;

public class ParameterReportTaskMappingProfiler : Profile
{
    public ParameterReportTaskMappingProfiler()
    {
        CreateMap<Domain.Entities.ParameterReportTask, ParameterReportTaskDto>().ReverseMap();
        CreateMap<CreateParameterReportTaskCommand, Domain.Entities.ParameterReportTask>().ReverseMap();
        CreateMap<DeleteParameterReportTaskCommand, Domain.Entities.ParameterReportTask>().ReverseMap();
        CreateMap<UpdateParameterReportTaskCommand, Domain.Entities.ParameterReportTask>().ReverseMap();
    }
}