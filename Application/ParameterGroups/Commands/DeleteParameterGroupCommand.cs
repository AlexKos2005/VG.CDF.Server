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

namespace VG.CDF.Server.Application.ParameterGroups.Commands;

public class DeleteParameterGroupCommand : EntityBaseDto,IRequest<bool>
{
    
    public class DeleteParameterGroupCommandHandler : DeleteCommandBase<DeleteParameterGroupCommand, ParameterGroup>
    {
        public DeleteParameterGroupCommandHandler(ISqlDataContext dataContext, IMapper mapper, IValidator<DeleteParameterGroupCommand>? validator) 
            : base(dataContext, mapper, validator)
        {
        }
    }

    public class DeleteParameterGroupCommandValidator : AbstractValidator<DeleteParameterGroupCommand>
    {
        public DeleteParameterGroupCommandValidator(ISqlDataContext dataContext)
        {
            RuleFor(c => c).MustAsync(async(command,cts) =>
            {
                return await dataContext.Set<ParameterGroup>()
                    .EntityIsExists(command.Id);
            }).WithMessage(command=> $"Группы параметров с Id {command.Id} не существует");
            
        }
    }
}