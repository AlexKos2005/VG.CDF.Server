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

namespace VG.CDF.Server.Application.Users.Commands;

public class DeleteUserCommand : EntityBaseDto,IRequest<bool>
{
    
    public class DeleteUserCommandHandler : DeleteCommandBase<DeleteUserCommand, User>
    {
        public DeleteUserCommandHandler(ISqlDataContext dataContext, IMapper mapper, IValidator<DeleteUserCommand>? validator) 
            : base(dataContext, mapper, validator)
        {
        }
    }

    public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserCommandValidator(ISqlDataContext dataContext)
        {
            RuleFor(c => c).MustAsync(async(command,cts) =>
            {
                return await dataContext.Set<User>()
                    .EntityIsExists(command.Id);
            }).WithMessage(command=> $"Пользователь с Id {command.Id} не существует");
            
        }
    }
}