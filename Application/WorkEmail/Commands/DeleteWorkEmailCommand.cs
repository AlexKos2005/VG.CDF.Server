using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VG.CDF.Server.Application.Interfaces;

namespace VG.CDF.Server.Application.WorkEmail.Commands;

public class DeleteWorkEmailCommand
{
    public int Id { get; set; }
}

public class DeleteWorkEmailCommandValidator : AbstractValidator<DeleteWorkEmailCommand>
{
    public DeleteWorkEmailCommandValidator(ISqlDataContext dataContext)
    {
        RuleFor(c => c.Id).NotNull().NotEmpty();

        RuleFor(command => command).MustAsync(async (command, cts) =>
        {
            return await dataContext.WorkEmails
                .Where(c => c.Id == command.Id)
                .AnyAsync();
        }).WithMessage($"Указанный адрес электронной почты не существует");
    }
}
