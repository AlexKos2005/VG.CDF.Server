using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VG.CDF.Server.Application.Dto;
using VG.CDF.Server.Application.WorkEmails.Commands;

namespace VG.CDF.Server.Application.Interfaces.Services;

public interface IWorkEmailService
{
   Task<IEnumerable<WorkEmailDto>> Get(GetWorkEmailsListQuery query, CancellationToken cts);
   Task<WorkEmailDto> Create(CreateWorkEmailCommand command, CancellationToken cts);
   Task<WorkEmailDto> Update(UpdateWorkEmailCommand command, CancellationToken cts);
   Task<bool> Delete(DeleteWorkEmailCommand command, CancellationToken cts);
   
   Task<bool> AddWorkEmailToTagReportTask(AddWorkEmailToParameterReportTaskCommand command, CancellationToken cts);
   
}