using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VG.CDF.Server.Application.Interfaces;

namespace VG.CDF.Server.Application.TagReportTask.Commands;

public class CreateTagReportTaskCommand
{
    public int FactoryId { get; set; }
    public bool IsActive { get; set; }
    
}

public class CreateTagReportTaskCommandValidator : AbstractValidator<CreateTagReportTaskCommand>
{
    public CreateTagReportTaskCommandValidator(ISqlDataContext dataContext)
    {
        RuleFor(c => c.FactoryId).NotNull();
        RuleFor(c => c.IsActive).NotNull();

        RuleFor(command => command).MustAsync(async (command, cts) =>
        {
            return !await dataContext.Set<Domain.Entities.TagReportTask>().Where(c => c.FactoryId == command.FactoryId).AnyAsync();
        }).WithMessage($"Задача генерации отчетов по тегам для данного производства уже существует");
    }
}
