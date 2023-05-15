using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VG.CDF.Server.Application.CommandBase;
using VG.CDF.Server.Application.Dto;
using VG.CDF.Server.Application.Interfaces;
using VG.CDF.Server.Domain.Entities;

namespace VG.CDF.Server.Application.WorkEmails.Commands;

public class UpdateWorkEmailCommand : EntityBaseDto,IRequest<WorkEmailDto>
{
    public string Email { get; set; } = string.Empty;

    public class UpdateWorkEmailCommandHandler: UpdateCommandBase<UpdateWorkEmailCommand,WorkEmailDto,WorkEmail>
    {
        public UpdateWorkEmailCommandHandler(ISqlDataContext dataContext, IMapper mapper, IValidator<UpdateWorkEmailCommand>? validator) : base(dataContext, mapper, validator)
        {
        }
    }
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
