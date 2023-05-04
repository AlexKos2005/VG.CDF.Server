using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VG.CDF.Server.Application.Dto;
using VG.CDF.Server.Application.TagReportTask.Commands;
using VG.CDF.Server.Application.TagReportTask.Queries;
using VG.CDF.Server.Application.WorkEmail.Commands;


namespace VG.CDF.Server.Application.Interfaces.Services;

public interface ITagReportTaskService
{
   Task<IEnumerable<TagReportTaskDto>> Get(GetTagReportTasksListQuery query, CancellationToken cts);
   Task<TagReportTaskDto> Create(CreateTagReportTaskCommand command, CancellationToken cts);
   Task<TagReportTaskDto> Update(UpdateTagReportTaskCommand command, CancellationToken cts);
   Task<TagReportTaskDto> AddEmailToTagReportTask(AddWorkEmailToTagReportTaskCommand command, CancellationToken cts);
   Task<bool> Delete(DeleteTagReportTaskCommand command, CancellationToken cts);
   
}