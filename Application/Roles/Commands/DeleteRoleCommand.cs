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

namespace VG.CDF.Server.Application.Roles.Commands;

public class DeleteRoleCommand : EntityBaseDto,IRequest<bool>
{
    
    public class DeleteRoleCommandHandler : DeleteCommandBase<DeleteRoleCommand, Role>
    {
        public DeleteRoleCommandHandler(ISqlDataContext dataContext, IMapper mapper, IValidator<DeleteRoleCommand>? validator) 
            : base(dataContext, mapper, validator)
        {
        }
    }

    public class DeleteRoleCommandValidator : AbstractValidator<DeleteRoleCommand>
    {
        public DeleteRoleCommandValidator(ISqlDataContext dataContext)
        {
            RuleFor(c => c).MustAsync(async(command,cts) =>
            {
                return await dataContext.Set<Role>()
                    .EntityIsExists(command.Id);
            }).WithMessage(command=> $"Роль с Id {command.Id} не существует");
            
        }
    }
}