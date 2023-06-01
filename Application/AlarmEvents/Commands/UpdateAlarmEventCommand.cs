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

namespace VG.CDF.Server.Application.AlarmEvents.Commands;

public class UpdateAlarmEventCommand : EntityBaseDto,IRequest<AlarmEventDto>
{
    public int ExternalId { get; set; }

    public Guid CompanyId { get; set; }

    public class UpdateAlarmEventCommandHandler : UpdateCommandBase<UpdateAlarmEventCommand,AlarmEventDto, Domain.Entities.AlarmEvent>
    {
        public UpdateAlarmEventCommandHandler(ISqlDataContext dataContext, IMapper mapper, IValidator<UpdateAlarmEventCommand>? validator) : base(dataContext, mapper, validator)
        {
        }
    }

    public class UpdateAlarmEventCommandValidator : AbstractValidator<UpdateAlarmEventCommand>
    {
        public UpdateAlarmEventCommandValidator(ISqlDataContext dataContext)
        {
            RuleFor(c => c).MustAsync(async(command,cts) =>
            {
                return await dataContext.Set<Domain.Entities.AlarmEvent>()
                    .EntityIsExists(command.Id);
            }).WithMessage(command=> $"Аварийного события с Id {command.Id} не существует");
            
            RuleFor(c => c).MustAsync(async(command,cts) =>
            {
                return await dataContext.Set<Domain.Entities.AlarmEvent>()
                    .EntityIsExists(command.Id);
            }).WithMessage(command=> $"Компании с Id {command.CompanyId} не существует");
            
            RuleFor(c => c).MustAsync(async(command,cts) =>
            {
                return !await dataContext.Set<Domain.Entities.AlarmEvent>()
                    .Where(c => c.CompanyId == command.CompanyId && c.ExternalId == command.ExternalId).AnyAsync();
            }).WithMessage(command=> $"У заданной компании с Id {command.CompanyId} уже существует событие с ExternalId {command.ExternalId}");
        }
    }
}