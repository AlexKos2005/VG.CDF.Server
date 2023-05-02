using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BreadCommunityWeb.Blz.Application.Dto;
using BreadCommunityWeb.Blz.Application.TagReportTask.Commands;
using BreadCommunityWeb.Blz.Application.TagReportTask.Queries;
using BreadCommunityWeb.Blz.Application.WorkEmail.Commands;

namespace BreadCommunityWeb.Blz.Application.Interfaces.Services;

public interface ITagReportTaskService
{
   Task<IEnumerable<TagReportTaskDto>> Get(GetTagReportTasksListQuery query, CancellationToken cts);
   Task<TagReportTaskDto> Create(CreateTagReportTaskCommand command, CancellationToken cts);
   Task<TagReportTaskDto> Update(UpdateTagReportTaskCommand command, CancellationToken cts);
   Task<TagReportTaskDto> AddEmailToTagReportTask(AddWorkEmailToTagReportTaskCommand command, CancellationToken cts);
   Task<bool> Delete(DeleteTagReportTaskCommand command, CancellationToken cts);
   
}