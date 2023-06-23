using System;
using System.IO.Pipes;
using System.Linq;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VG.CDF.Server.Application.CommandBase;
using VG.CDF.Server.Application.Dto;
using VG.CDF.Server.Application.Interfaces;
using VG.CDF.Server.Domain.Entities;

namespace VG.CDF.Server.Application.Users.Commands;

public class CreateUserCommand : IRequest<UserDto>
{
    public string Email { get; set; } = string.Empty;

    public string PasswordHash { get; set; }= string.Empty;

    public Guid RoleId { get; set; }

    public class CreateProjectCommandHandler : CreateCommandBase<CreateUserCommand,UserDto, User>
    {
        public CreateProjectCommandHandler(ISqlDataContext dataContext, IMapper mapper, IValidator<CreateUserCommand>? validator) 
            : base(dataContext, mapper, validator)
        {
        }
    }

    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator(ISqlDataContext dataContext)
        {
            
            RuleFor(c => c.PasswordHash).NotEmpty()
                .WithMessage("Пароль не может быть пустым");
            
            RuleFor(c => c.Email).EmailAddress()
                .WithMessage("Некорректный адрес почты");
            
            RuleFor(c => c).MustAsync(async(command,cts) =>
            {
                return !await dataContext.Set<Role>()
                    .Where(c => c.Id == command.RoleId).AnyAsync();
            }).WithMessage(command=> $"Роли с указанным Id {command.RoleId} не существует");

            RuleFor(c => c.Email).MustAsync(async (email, cts) =>
            {
                return !await dataContext.Set<User>().AnyAsync(c=>c.Email.ToLower() == email.ToLower());
            }).WithMessage(command=> $"Пользователь с указанным Email {command.Email} уже существует");;

        }
    }
}