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

namespace VG.CDF.Server.Application.Processes.Commands;

public class DeleteProcessCommand : EntityBaseDto,IRequest<bool>
{
    
    public class DeleteProcessCommandHandler : DeleteCommandBase<DeleteProcessCommand, Process>
    {
        public DeleteProcessCommandHandler(ISqlDataContext dataContext, IMapper mapper, IValidator<DeleteProcessCommand>? validator) : base(dataContext, mapper, validator)
        {
        }
    }

    public class DeleteProcessCommandValidator : AbstractValidator<DeleteProcessCommand>
    {
        public DeleteProcessCommandValidator(ISqlDataContext dataContext)
        {
            RuleFor(c => c).MustAsync(async(command,cts) =>
            {
                return await dataContext.Set<Process>()
                    .EntityIsExists(command.Id);
            }).WithMessage(command=> $"Процесс с Id {command.Id} не существует");
            
        }
    }
}