using System;
using System.Collections.Generic;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VG.CDF.Server.Application.Dto;
using VG.CDF.Server.Application.Interfaces;
using VG.CDF.Server.Domain.Entities;

namespace VG.CDF.Server.Application.TagReportTask.Queries;

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
