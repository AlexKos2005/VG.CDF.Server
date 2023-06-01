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

public class UpdateRoleCommand : EntityBaseDto,IRequest<RoleDto>
{
    public string Name { get; set; } = string.Empty;

    public class UpdateRoleCommandHandler : UpdateCommandBase<UpdateRoleCommand,RoleDto, Role>
    {
        public UpdateRoleCommandHandler(ISqlDataContext dataContext, IMapper mapper, IValidator<UpdateRoleCommand>? validator) 
            : base(dataContext, mapper, validator)
        {
        }
    }

    public class UpdateRoleCommandValidator : AbstractValidator<UpdateRoleCommand>
    {
        public UpdateRoleCommandValidator(ISqlDataContext dataContext)
        {
            RuleFor(c => c).MustAsync(async(command,cts) =>
            {
                return await dataContext.Set<Role>()
                    .EntityIsExists(command.Id);
            }).WithMessage(command=> $"Роль с Id {command.Id} не существует");
            
        }
    }
}