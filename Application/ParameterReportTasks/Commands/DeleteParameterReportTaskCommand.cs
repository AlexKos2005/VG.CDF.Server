using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VG.CDF.Server.Application.AlarmEventDescriptions.Commands;
using VG.CDF.Server.Application.CommandBase;
using VG.CDF.Server.Application.Dto;
using VG.CDF.Server.Application.Interfaces;
using VG.CDF.Server.Domain.Entities;

namespace VG.CDF.Server.Application.ParameterReportTasks.Commands;

public class DeleteParameterReportTaskCommand : EntityBaseDto, IRequest<bool>
{
    public class DeleteParameterReportTaskCommandHandler : DeleteCommandBase<DeleteParameterReportTaskCommand, ParameterReportTask>
    {
        public DeleteParameterReportTaskCommandHandler(ISqlDataContext dataContext, IMapper mapper, IValidator<DeleteParameterReportTaskCommand>? validator) 
            : base(dataContext, mapper, validator)
        {
        }
    }

}

public class DeleteTagReportTaskCommandValidator : AbstractValidator<DeleteParameterReportTaskCommand>
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
