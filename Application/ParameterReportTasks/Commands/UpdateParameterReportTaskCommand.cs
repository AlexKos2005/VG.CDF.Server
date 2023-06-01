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

public class UpdateParameterReportTaskCommand : EntityBaseDto, IRequest<ParameterReportTaskDto>
{
    public bool IsActive { get; set; }
    public  DateTime LastSendDt { get; set; }
    public  ReportTaskStatus Status { get; set; }

    public class UpdateParameterReportTaskCommandHandler: UpdateCommandBase<UpdateParameterReportTaskCommand,ParameterReportTaskDto, ParameterReportTask>
    {
        public UpdateParameterReportTaskCommandHandler(ISqlDataContext dataContext, IMapper mapper, IValidator<UpdateParameterReportTaskCommand>? validator) 
            : base(dataContext, mapper, validator)
        {
        }
    }
}

public class UpdateTagReportTaskCommandValidator : AbstractValidator<UpdateParameterReportTaskCommand>
{
    public UpdateTagReportTaskCommandValidator(ISqlDataContext dataContext)
    {
        RuleFor(c => c.Id).NotNull();
        RuleFor(c => c.IsActive).NotNull();
        RuleFor(c => c.LastSendDt).NotNull();
        
        RuleFor(command => command).MustAsync(async (command, cts) =>
        {
            return await dataContext.ParameterReportTasks.Where(c => c.Id == command.Id).AnyAsync();
        }).WithMessage($"Задача генерации отчетов по тегам с указанным Id не существует");
    }
}
