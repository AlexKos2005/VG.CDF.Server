using System;
using System.Linq;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VG.CDF.Server.Application.AlarmEvents.Commands;
using VG.CDF.Server.Application.CommandBase;
using VG.CDF.Server.Application.Dto;
using VG.CDF.Server.Application.Extentions;
using VG.CDF.Server.Application.Interfaces;
using VG.CDF.Server.Domain.Entities;

namespace VG.CDF.Server.Application.AlarmEventDescriptions.Commands;

public class UpdateAlarmEventDescriptionCommand : EntityBaseDto,IRequest<AlarmEventDescriptionDto>
{
    public string Description { get; set; } = string.Empty;

    public Guid AlarmEventId { get; set; }
    
    public Guid LanguageId { get; set; }

    public class UpdateAlarmEventDescriptionCommandHandler : UpdateCommandBase<UpdateAlarmEventDescriptionCommand,AlarmEventDescriptionDto, AlarmEventDescription>
    {
        public UpdateAlarmEventDescriptionCommandHandler(ISqlDataContext dataContext, IMapper mapper, IValidator<UpdateAlarmEventDescriptionCommand>? validator) 
            : base(dataContext, mapper, validator)
        {
        }
    }

    public class UpdateAlarmEventDescriptionCommandValidator : AbstractValidator<UpdateAlarmEventDescriptionCommand>
    {
        public UpdateAlarmEventDescriptionCommandValidator(ISqlDataContext dataContext)
        {
            RuleFor(c => c.Description).NotEmpty()
                .WithMessage("Описание параметра не должно быть пустым");
            RuleFor(c => c).MustAsync(async(command,cts) =>
            {
                return await dataContext.Set<AlarmEvent>()
                    .EntityIsExists(command.AlarmEventId);
            }).WithMessage(command=> $"Аварийное событие с Id {command.AlarmEventId} не существует");
            
           
        }
    }
}