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
using VG.CDF.Server.Domain.Enums;

namespace VG.CDF.Server.Application.Roles.Commands;

public class CreateRoleCommand : IRequest<RoleDto>
{
    public string RoleName { get; set; } = string.Empty;

    public RoleCode RoleCode { get; set; }

    public class CreateProjectCommandHandler : CreateCommandBase<CreateRoleCommand,RoleDto, Role>
    {
        public CreateProjectCommandHandler(ISqlDataContext dataContext, IMapper mapper, IValidator<CreateRoleCommand>? validator) 
            : base(dataContext, mapper, validator)
        {
        }
    }

    public class CreateRoleCommandValidator : AbstractValidator<CreateRoleCommand>
    {
        public CreateRoleCommandValidator(ISqlDataContext dataContext)
        {
            RuleFor(c => c.RoleName).NotEmpty()
                .WithMessage("Название роли не должно быть пустым");
            
            RuleFor(c => c).MustAsync(async(command,cts) =>
            {
                return !await dataContext.Set<Role>()
                    .Where(c => c.RoleName.ToLower() == command.RoleName.ToLower()).AnyAsync();
            }).WithMessage(command=> $"Роль с указанным именем уже существует");
            
        }
    }
}