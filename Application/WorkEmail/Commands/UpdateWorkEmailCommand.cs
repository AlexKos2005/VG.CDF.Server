using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VG.CDF.Server.Application.Interfaces;

namespace VG.CDF.Server.Application.WorkEmail.Commands;

public class UpdateWorkEmailCommand
{
    public int Id { get; set; }
    public string? Email { get; set; }
}

public class UpdateWorkEmailCommandValidator : AbstractValidator<UpdateWorkEmailCommand>
{
    public UpdateWorkEmailCommandValidator(ISqlDataContext dataContext)
    {
        RuleFor(c => c.Id).NotNull().NotEmpty();
        RuleFor(c => c.Email).NotNull().NotEmpty();
        
        RuleFor(command => command).MustAsync(async (command, cts) =>
        {
            return await dataContext.WorkEmails
                .Where(c => c.Id == command.Id)
                .AnyAsync();
        }).WithMessage($"Указанный адрес электронной почты с таким Id не существует");
        
        RuleFor(command => command).MustAsync(async (command, cts) =>
        {
            return !await dataContext.WorkEmails
                .Where(c => c.Email.ToLowerInvariant() == command.Email.ToLowerInvariant())
                .AnyAsync();
        }).WithMessage($"Указанный адрес электронной почты уже существует");
    }
}
