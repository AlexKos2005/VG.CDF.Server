using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VG.CDF.Server.Application.Dto;
using VG.CDF.Server.Application.HandlerBase;
using VG.CDF.Server.Application.Interfaces;
using VG.CDF.Server.Domain.Entities;

namespace VG.CDF.Server.Application.WorkEmails.Commands;

public class CreateWorkEmailCommand : IRequest<WorkEmailDto>
{
    public string Email { get; set; } = string.Empty;

    public class CreateWorkEmailCommandHandler: CreateHandlerBase<CreateWorkEmailCommand,WorkEmailDto,WorkEmail>
    {
        public CreateWorkEmailCommandHandler(IValidator<CreateWorkEmailCommand> validator, ISqlDataContext dataContext, IMapper mapper) 
            : base(validator, dataContext, mapper)
        {
        }
    }
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
