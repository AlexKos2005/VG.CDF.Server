using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BreadCommunityWeb.Blz.Application.Dto;
using BreadCommunityWeb.Blz.Application.Interfaces;
using BreadCommunityWeb.Blz.Domain.Enums;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BreadCommunityWeb.Blz.Application.TagReportTask.Queries;

public class GetTagReportTasksListQuery: IRequest<IEnumerable<TagReportTaskDto>>
{
    public int? Id { get; set; } = null;
    public int? FactoryId { get; set; }= null;
    public bool? IsActive { get; set; }= null;
    public  DateTimeOffset? LastSendDt { get; set; }= null;

    public ReportTaskStatus? Status { get; set; } = null;

}

public class GetTagReportTasksListQueryValidator : AbstractValidator<GetTagReportTasksListQuery>
{
    public GetTagReportTasksListQueryValidator(ISqlDataContext dataContext)
    {
    }
}
