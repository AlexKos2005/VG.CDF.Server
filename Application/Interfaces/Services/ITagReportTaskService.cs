using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VG.CDF.Server.Application.Dto;
using VG.CDF.Server.Application.ParameterReportTasks.Commands;
using VG.CDF.Server.Application.ParameterReportTasks.Queries;
using VG.CDF.Server.Application.WorkEmails.Commands;


namespace VG.CDF.Server.Application.Interfaces.Services;

public interface ITagReportTaskService
{
   Task<IEnumerable<ParameterReportTaskDto>> Get(GetParameterReportTasksListQuery query, CancellationToken cts);
   Task<ParameterReportTaskDto> Create(CreateParameterReportTaskCommand command, CancellationToken cts);
   Task<ParameterReportTaskDto> Update(UpdateParameterReportTaskCommand command, CancellationToken cts);
   Task<ParameterReportTaskDto> AddEmailToTagReportTask(AddWorkEmailToParameterReportTaskCommand command, CancellationToken cts);
   Task<bool> Delete(DeleteParameterReportTaskCommand command, CancellationToken cts);
   
}