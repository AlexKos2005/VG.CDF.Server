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

public class DeleteAlarmEventCommand : EntityBaseDto,IRequest<bool>
{
    
    public class DeleteAlarmEventCommandHandler : DeleteCommandBase<DeleteAlarmEventCommand, Domain.Entities.AlarmEvent>
    {
        public DeleteAlarmEventCommandHandler(ISqlDataContext dataContext, IMapper mapper, IValidator<DeleteAlarmEventCommand>? validator) : base(dataContext, mapper, validator)
        {
        }
    }

    public class DeleteAlarmEventCommandValidator : AbstractValidator<DeleteAlarmEventCommand>
    {
        public DeleteAlarmEventCommandValidator(ISqlDataContext dataContext)
        {
            RuleFor(c => c).MustAsync(async(command,cts) =>
            {
                return await dataContext.Set<Domain.Entities.AlarmEvent>()
                    .EntityIsExists(command.Id);
            }).WithMessage(command=> $"Компании с Id {command.Id} не существует");
            
        }
    }
}