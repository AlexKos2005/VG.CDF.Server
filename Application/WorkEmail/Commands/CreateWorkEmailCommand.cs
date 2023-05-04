using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VG.CDF.Server.Application.Interfaces;

namespace VG.CDF.Server.Application.WorkEmail.Commands;

public class CreateWorkEmailCommand
{
    public string Email { get; set; }
}

public class CreateWorkEmailCommandValidator : AbstractValidator<CreateWorkEmailCommand>
{
    public CreateWorkEmailCommandValidator(ISqlDataContext dataContext)
    {
        RuleFor(c => c.Email).NotNull().NotEmpty();
        RuleFor(c => c.Email).EmailAddress();

        RuleFor(command => command).MustAsync(async (command, cts) =>
        {
            return !await dataContext.WorkEmails
                .Where(c => c.Email.ToLower() == command.Email.ToLower())
                .AnyAsync();
        }).WithMessage($"Указанный адрес электронной почты уже существует");
    }
}
