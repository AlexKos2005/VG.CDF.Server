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

public class UpdateProjectCommand : EntityBaseDto,IRequest<ProjectDto>
{
    public string Name { get; set; } = string.Empty;

    public class UpdateProjectCommandHandler : UpdateCommandBase<UpdateProjectCommand,ProjectDto, Project>
    {
        public UpdateProjectCommandHandler(ISqlDataContext dataContext, IMapper mapper, IValidator<UpdateProjectCommand>? validator) 
            : base(dataContext, mapper, validator)
        {
        }
    }

    public class UpdateProjectCommandValidator : AbstractValidator<UpdateProjectCommand>
    {
        public UpdateProjectCommandValidator(ISqlDataContext dataContext)
        {
            RuleFor(c => c).MustAsync(async(command,cts) =>
            {
                return await dataContext.Set<Process>()
                    .EntityIsExists(command.Id);
            }).WithMessage(command=> $"Проект с Id {command.Id} не существует");
            
        }
    }
}