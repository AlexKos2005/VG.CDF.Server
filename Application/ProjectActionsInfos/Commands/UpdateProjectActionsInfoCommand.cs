using System;
using System.Linq;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VG.CDF.Server.Application.CommandBase;
using VG.CDF.Server.Application.Dto;
using VG.CDF.Server.Application.Extentions;
using VG.CDF.Server.Application.Interfaces;
using VG.CDF.Server.Domain.Entities;

namespace VG.CDF.Server.Application.ProjectActionsInfos.Commands;

public class UpdateProjectActionsInfoCommand : EntityBaseDto,IRequest<ProjectActionsInfoDto>
{
    public DateTime LastDateTimeConnection { get; set; }

    public DateTime LastDateTimeReportSending { get; set; }

    public DateTimeOffset LastDateTimeConnectionOffset { get; set; }

    public DateTimeOffset LastDateTimeReportSendingOffset { get; set; }

    public int AlarmMessageCounter { get; set; }

    public Guid ProjectId { get; set; }

    public class UpdateProjectActionsInfoCommandHandler : UpdateCommandBase<UpdateProjectActionsInfoCommand,ProjectActionsInfoDto, ProjectActionsInfo>
    {
        public UpdateProjectActionsInfoCommandHandler(ISqlDataContext dataContext, IMapper mapper, IValidator<UpdateProjectActionsInfoCommand>? validator) 
            : base(dataContext, mapper, validator)
        {
        }
    }

    public class UpdateProjectActionsInfoCommandValidator : AbstractValidator<UpdateProjectActionsInfoCommand>
    {
        public UpdateProjectActionsInfoCommandValidator(ISqlDataContext dataContext)
        {
            RuleFor(c => c).MustAsync(async(command,cts) =>
            {
                return await dataContext.Set<ProjectActionsInfo>()
                    .EntityIsExists(command.Id);
            }).WithMessage(command=> $"Информации о событиях проекта с Id {command.Id} не существует");
            
            RuleFor(c => c).MustAsync(async(command,cts) =>
            {
                return await dataContext.Set<Project>()
                    .EntityIsExists(command.ProjectId);
            }).WithMessage(command=> $"Проект с Id {command.Id} не существует");
            
            
        }
    }
}