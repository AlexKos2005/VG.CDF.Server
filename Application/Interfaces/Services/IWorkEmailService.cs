using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BreadCommunityWeb.Blz.Application.Dto;
using BreadCommunityWeb.Blz.Application.TagReportTask.Commands;
using BreadCommunityWeb.Blz.Application.WorkEmail.Commands;

namespace BreadCommunityWeb.Blz.Application.Interfaces.Services;

public interface IWorkEmailService
{
   Task<IEnumerable<WorkEmailDto>> Get(GetWorkEmailsListQuery query, CancellationToken cts);
   Task<WorkEmailDto> Create(CreateWorkEmailCommand command, CancellationToken cts);
   Task<WorkEmailDto> Update(UpdateWorkEmailCommand command, CancellationToken cts);
   Task<bool> Delete(DeleteWorkEmailCommand command, CancellationToken cts);
   
   Task<bool> AddWorkEmailToTagReportTask(AddWorkEmailToTagReportTaskCommand command, CancellationToken cts);
   
}