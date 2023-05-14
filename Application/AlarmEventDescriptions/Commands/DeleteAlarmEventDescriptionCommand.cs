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

namespace VG.CDF.Server.Application.AlarmEventDescriptions.Commands;

public class DeleteAlarmEventDescriptionCommand : EntityBaseDto,IRequest<bool>
{
    
    public class DeleteAlarmEventDescriptionCommandHandler : DeleteCommandBase<DeleteAlarmEventDescriptionCommand, AlarmEventDescription>
    {
        public DeleteAlarmEventDescriptionCommandHandler(ISqlDataContext dataContext, IMapper mapper, IValidator<DeleteAlarmEventDescriptionCommand>? validator) : base(dataContext, mapper, validator)
        {
        }
    }

    public class DeleteAlarmEventDescriptionCommandValidator : AbstractValidator<DeleteAlarmEventDescriptionCommand>
    {
        public DeleteAlarmEventDescriptionCommandValidator(ISqlDataContext dataContext)
        {
            RuleFor(c => c).MustAsync(async(command,cts) =>
            {
                return await dataContext.Set<AlarmEventDescription>()
                    .EntityIsExists(command.Id);
            }).WithMessage(command=> $"Описания аварийного события с Id {command.Id} не существует");
            
        }
    }
}