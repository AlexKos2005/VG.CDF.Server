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

namespace VG.CDF.Server.Application.Projects.Commands;

public class DeleteProjectCommand : EntityBaseDto,IRequest<bool>
{
    
    public class DeleteProjectCommandHandler : DeleteCommandBase<DeleteProjectCommand, Process>
    {
        public DeleteProjectCommandHandler(ISqlDataContext dataContext, IMapper mapper, IValidator<DeleteProjectCommand>? validator) : base(dataContext, mapper, validator)
        {
        }
    }

    public class DeleteProjectCommandValidator : AbstractValidator<DeleteProjectCommand>
    {
        public DeleteProjectCommandValidator(ISqlDataContext dataContext)
        {
            RuleFor(c => c).MustAsync(async(command,cts) =>
            {
                return await dataContext.Set<Project>()
                    .EntityIsExists(command.Id);
            }).WithMessage(command=> $"Проект с Id {command.Id} не существует");
            
        }
    }
}