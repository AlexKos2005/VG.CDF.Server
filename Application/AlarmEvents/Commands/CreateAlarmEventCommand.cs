using System.Linq;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VG.CDF.Server.Application.CommandBase;
using VG.CDF.Server.Application.Dto;
using VG.CDF.Server.Application.Interfaces;

namespace VG.CDF.Server.Application.AlarmEvents.Commands;

public class CreateAlarmEventCommand : IRequest<AlarmEventDto>
{
    public int ExternalId { get; set; }

    public int CompanyId { get; set; }

    public class CreateAlarmEventCommandHandler : CreateCommandBase<CreateAlarmEventCommand,AlarmEventDto, Domain.Entities.AlarmEvent>
    {
        public CreateAlarmEventCommandHandler(ISqlDataContext dataContext, IMapper mapper, IValidator<CreateAlarmEventCommand>? validator) : base(dataContext, mapper, validator)
        {
        }
    }

    public class CreateAlarmEventCommandValidator : AbstractValidator<CreateAlarmEventCommand>
    {
        public CreateAlarmEventCommandValidator(ISqlDataContext dataContext)
        {
            RuleFor(c => c).MustAsync(async(command,cts) =>
            {
                return await dataContext.Set<Domain.Entities.AlarmEvent>()
                    .Where(c => c.CompanyId == command.CompanyId).AnyAsync();
            }).WithMessage(command=> $"Компании с Id {command.CompanyId} не существует");
            
            RuleFor(c => c).MustAsync(async(command,cts) =>
            {
                return !await dataContext.Set<Domain.Entities.AlarmEvent>()
                    .Where(c => c.CompanyId == command.CompanyId && c.ExternalId == command.ExternalId).AnyAsync();
            }).WithMessage(command=> $"У заданной компании с Id {command.CompanyId} уже существует событие с ExternalId {command.ExternalId}");
        }
    }
}