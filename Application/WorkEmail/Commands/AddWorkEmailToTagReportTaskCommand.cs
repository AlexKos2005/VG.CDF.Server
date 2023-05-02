using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BreadCommunityWeb.Blz.Application.Dto;
using BreadCommunityWeb.Blz.Application.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BreadCommunityWeb.Blz.Application.WorkEmail.Commands;

public class AddWorkEmailToTagReportTaskCommand
{
    public int Id { get; set; }
    public int TagReportTaskId { get; set; }
}

public class AddWorkEmailToTagReportTaskValidator : AbstractValidator<AddWorkEmailToTagReportTaskCommand>
{
    public AddWorkEmailToTagReportTaskValidator(ISqlDataContext dataContext)
    {
        RuleFor(command => command).MustAsync(async (command, cts) =>
        {
            return await dataContext.WorkEmails
                .Where(c => c.Id == command.Id)
                .AnyAsync();
        }).WithMessage($"Указанный адрес электронной почты с таким Id не существует");
        
        RuleFor(command => command).MustAsync(async (command, cts) =>
        {
            return await dataContext.TagReportTasks
                .Where(c => c.Id == command.TagReportTaskId)
                .AnyAsync();
        }).WithMessage($"Указанная задача отчетов по тегам с таким Id не существует");
    }
}
