using System;
using System.Linq;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VG.CDF.Server.Application.CommandBase;
using VG.CDF.Server.Application.Dto;
using VG.CDF.Server.Application.Interfaces;
using VG.CDF.Server.Domain.Entities;

namespace VG.CDF.Server.Application.AlarmEventDescriptions.Commands;

public class CreateAlarmEventDescriptionCommand : IRequest<AlarmEventDescriptionDto>
{
    public string RusDescription { get; set; } = String.Empty;
        
    public string EngDescription { get; set; }= String.Empty;
        
    public string UkrDescription { get; set; }= String.Empty;

    public Guid AlarmEventId { get; set; }
    

    public class CreateAlarmEventDescriptionCommandHandler : CreateCommandBase<CreateAlarmEventDescriptionCommand,AlarmEventDescriptionDto, AlarmEventDescription>
    {
        public CreateAlarmEventDescriptionCommandHandler(ISqlDataContext dataContext, IMapper mapper, IValidator<CreateAlarmEventDescriptionCommand>? validator) : base(dataContext, mapper, validator)
        {
        }
    }

    public class CreateAlarmEventDescriptionCommandValidator : AbstractValidator<CreateAlarmEventDescriptionCommand>
    {
        public CreateAlarmEventDescriptionCommandValidator(ISqlDataContext dataContext)
        {
            RuleFor(c => c).MustAsync(async(command,cts) =>
            {
                return await dataContext.Set<AlarmEventDescription>()
                    .Where(c => c.AlarmEventId == command.AlarmEventId).AnyAsync();
            }).WithMessage(command=> $"Аварийного события с Id {command.AlarmEventId} не существует");

        }
    }
}