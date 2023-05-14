using System;
using System.Linq;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VG.CDF.Server.Application.AlarmEvents.Commands;
using VG.CDF.Server.Application.CommandBase;
using VG.CDF.Server.Application.Dto;
using VG.CDF.Server.Application.Interfaces;
using VG.CDF.Server.Domain.Entities;

namespace VG.CDF.Server.Application.AlarmEventDescriptions.Commands;

public class UpdateAlarmEventDescriptionCommand : EntityBaseDto,IRequest<AlarmEventDescriptionDto>
{
    public string Description { get; set; }

    public Guid AlarmEventId { get; set; }
    
    public Guid DescriptionsLanguageId { get; set; }

    public class UpdateAlarmEventDescriptionCommandHandler : UpdateCommandBase<UpdateAlarmEventDescriptionCommand,AlarmEventDescriptionDto, AlarmEventDescription>
    {
        public UpdateAlarmEventDescriptionCommandHandler(ISqlDataContext dataContext, IMapper mapper, IValidator<UpdateAlarmEventDescriptionCommand>? validator) 
            : base(dataContext, mapper, validator)
        {
        }
    }

    public class UpdateAlarmEventDescriptionCommandValidator : AbstractValidator<UpdateAlarmEventCommand>
    {
        public UpdateAlarmEventDescriptionCommandValidator(ISqlDataContext dataContext)
        {
            RuleFor(c => c).MustAsync(async(command,cts) =>
            {
                return await dataContext.Set<AlarmEventDescription>()
                    .Where(c => c.Id == command.Id).AnyAsync();
            }).WithMessage(command=> $"Описания аварийного события с Id {command.Id} не существует");
            
            RuleFor(c => c).MustAsync(async(command,cts) =>
            {
                return await dataContext.Set<AlarmEvent>()
                    .Where(c => c.CompanyId == command.CompanyId).AnyAsync();
            }).WithMessage(command=> $"Компании с Id {command.CompanyId} не существует");
            
            RuleFor(c => c).MustAsync(async(command,cts) =>
            {
                return !await dataContext.Set<AlarmEvent>()
                    .Where(c => c.CompanyId == command.CompanyId && c.ExternalId == command.ExternalId).AnyAsync();
            }).WithMessage(command=> $"У заданной компании с Id {command.CompanyId} уже существует событие с ExternalId {command.ExternalId}");
        }
    }
}