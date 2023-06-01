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
using VG.CDF.Server.Application.Extentions;
using VG.CDF.Server.Application.Interfaces;
using VG.CDF.Server.Domain.Entities;

namespace VG.CDF.Server.Application.WorkEmails.Commands;

public class DeleteWorkEmailCommand : EntityBaseDto,IRequest<bool>
{
    public Guid Id { get; set; }

    public class DeleteWorkEmailCommandHandler: DeleteCommandBase<DeleteWorkEmailCommand,WorkEmail>
    {
        public DeleteWorkEmailCommandHandler(ISqlDataContext dataContext, IMapper mapper, IValidator<DeleteWorkEmailCommand>? validator) 
            : base(dataContext, mapper, validator)
        {
        }
    }
}

public class DeleteWorkEmailCommandValidator : AbstractValidator<DeleteWorkEmailCommand>
{
    public DeleteWorkEmailCommandValidator(ISqlDataContext dataContext)
    {
        RuleFor(c => c.Id).NotNull().NotEmpty();

        RuleFor(command => command).MustAsync(async (command, cts) =>
        {
            return await dataContext.Set<WorkEmail>()
                .EntityIsExists(command.Id);
        }).WithMessage($"Указанный адрес электронной почты не существует");
    }
}
