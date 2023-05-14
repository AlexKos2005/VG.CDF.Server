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

public class CreateParameterReportTaskCommand : EntityBaseDto,IRequest<ParameterReportTaskDto>
{
    public Guid ProjectId { get; set; }
    public bool IsActive { get; set; }
    
    public class CreateParameterReportTaskCommandHandler: CreateCommandBase<CreateParameterReportTaskCommand,ParameterReportTaskDto, ParameterReportTask>
    {
        public CreateParameterReportTaskCommandHandler(ISqlDataContext dataContext, IMapper mapper, IValidator<CreateParameterReportTaskCommand>? validator) 
            : base(dataContext, mapper, validator)
        {
        }
    }
    
}

public class CreateCreateParameterReportTaskCommandValidator : AbstractValidator<CreateParameterReportTaskCommand>
{
    public CreateCreateParameterReportTaskCommandValidator(ISqlDataContext dataContext)
    {
        RuleFor(c => c.ProjectId).NotNull();
        RuleFor(c => c.IsActive).NotNull();

        RuleFor(command => command).MustAsync(async (command, cts) =>
        {
            return !await dataContext.Set<Domain.Entities.ParameterReportTask>().Where(c => c.ProjectId == command.ProjectId).AnyAsync();
        }).WithMessage($"Задача генерации отчетов по тегам для данного производства уже существует");
    }
}
