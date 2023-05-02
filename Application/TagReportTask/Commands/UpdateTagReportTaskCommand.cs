using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BreadCommunityWeb.Blz.Application.Dto;
using BreadCommunityWeb.Blz.Application.Interfaces;
using BreadCommunityWeb.Blz.Domain.Enums;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BreadCommunityWeb.Blz.Application.TagReportTask.Commands;

public class UpdateTagReportTaskCommand
{
    public int Id { get; set; }
    public bool IsActive { get; set; }
    public  DateTime LastSendDt { get; set; }
    public  ReportTaskStatus Status { get; set; }
    
}

public class UpdateTagReportTaskCommandValidator : AbstractValidator<UpdateTagReportTaskCommand>
{
    public UpdateTagReportTaskCommandValidator(ISqlDataContext dataContext)
    {
        RuleFor(c => c.Id).NotNull();
        RuleFor(c => c.IsActive).NotNull();
        RuleFor(c => c.LastSendDt).NotNull();
        
        RuleFor(command => command).MustAsync(async (command, cts) =>
        {
            return await dataContext.TagReportTasks.Where(c => c.Id == command.Id).AnyAsync();
        }).WithMessage($"Задача генерации отчетов по тегам с указанным Id не существует");
    }
}
