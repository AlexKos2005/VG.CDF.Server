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

namespace VG.CDF.Server.Application.ProcessDescriptions.Commands;

public class DeleteProcessDescriptionCommand : EntityBaseDto,IRequest<bool>
{
    
    public class DeleteAlarmEventDescriptionCommandHandler : DeleteCommandBase<DeleteProcessDescriptionCommand, ProcessDescription>
    {
        public DeleteAlarmEventDescriptionCommandHandler(ISqlDataContext dataContext, IMapper mapper, IValidator<DeleteProcessDescriptionCommand>? validator) : base(dataContext, mapper, validator)
        {
        }
    }

    public class DeleteProcessDescriptionCommandValidator : AbstractValidator<DeleteProcessDescriptionCommand>
    {
        public DeleteProcessDescriptionCommandValidator(ISqlDataContext dataContext)
        {
            RuleFor(c => c).MustAsync(async(command,cts) =>
            {
                return await dataContext.Set<ProcessDescription>()
                    .EntityIsExists(command.Id);
            }).WithMessage(command=> $"Описания процесса с Id {command.Id} не существует");
            
        }
    }
}