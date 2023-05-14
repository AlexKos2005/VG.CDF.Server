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

namespace VG.CDF.Server.Application.Parameters.Commands;

public class DeleteParameterCommand : EntityBaseDto,IRequest<bool>
{
    
    public class DeleteParameterCommandHandler : DeleteCommandBase<DeleteParameterCommand, Language>
    {
        public DeleteParameterCommandHandler(ISqlDataContext dataContext, IMapper mapper, IValidator<DeleteParameterCommand>? validator) : base(dataContext, mapper, validator)
        {
        }
    }

    public class DeleteParameterCommandValidator : AbstractValidator<DeleteParameterCommand>
    {
        public DeleteParameterCommandValidator(ISqlDataContext dataContext)
        {
            RuleFor(c => c).MustAsync(async(command,cts) =>
            {
                return await dataContext.Set<Parameter>()
                    .EntityIsExists(command.Id);
            }).WithMessage(command=> $"Параметр с Id {command.Id} не существует");
            
        }
    }
}