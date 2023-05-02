using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BreadCommunityWeb.Blz.Application.Dto;
using BreadCommunityWeb.Blz.Application.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BreadCommunityWeb.Blz.Application.TagReportTask.Commands;

public class DeleteTagReportTaskCommand
{
    public int Id { get; set; }

}

public class DeleteTagReportTaskCommandValidator : AbstractValidator<DeleteTagReportTaskCommand>
{
    public DeleteTagReportTaskCommandValidator(ISqlDataContext dataContext)
    {
        RuleFor(c => c.Id).NotNull();
        RuleFor(command => command).MustAsync(async (command, cts) =>
        {
            return await dataContext.TagReportTasks.Where(c => c.Id == command.Id).AnyAsync();
        }).WithMessage($"Задача генерации отчетов по тегам с указанным Id не существует");
    }
}
