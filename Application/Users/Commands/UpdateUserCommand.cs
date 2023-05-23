using System;
using System.Linq;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VG.CDF.Server.Application.CommandBase;
using VG.CDF.Server.Application.Dto;
using VG.CDF.Server.Application.Extentions;
using VG.CDF.Server.Application.Interfaces;
using VG.CDF.Server.Application.Roles.Commands;
using VG.CDF.Server.Domain.Entities;

namespace VG.CDF.Server.Application.Users.Commands;

public class UpdateUserCommand : EntityBaseDto,IRequest<UserDto>
{
    public string Email { get; set; } = string.Empty;
    
    public Guid RoleId { get; set; }

    public class UpdateUserCommandHandler : UpdateCommandBase<UpdateUserCommand,UserDto, User>
    {
        public UpdateUserCommandHandler(ISqlDataContext dataContext, IMapper mapper, IValidator<UpdateUserCommand>? validator) 
            : base(dataContext, mapper, validator)
        {
        }
    }

    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator(ISqlDataContext dataContext)
        {
            RuleFor(c => c).MustAsync(async(command,cts) =>
            {
                return await dataContext.Set<User>()
                    .EntityIsExists(command.Id);
            }).WithMessage(command=> $"Пользователь с Id {command.Id} не существует");
            
            RuleFor(c => c).MustAsync(async(command,cts) =>
            {
                return !await dataContext.Set<User>()
                    .Where(c => c.Email.ToLower() == command.Email.ToLower()).AnyAsync();
            }).WithMessage(command=> $"Пользователь с почтой {command.Email} уже существует");
            
        }
    }
}