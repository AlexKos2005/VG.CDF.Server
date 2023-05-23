using System;
using System.Linq;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VG.CDF.Server.Application.CommandBase;
using VG.CDF.Server.Application.Dto;
using VG.CDF.Server.Application.Interfaces;
using VG.CDF.Server.Domain.Entities;

namespace VG.CDF.Server.Application.Projects.Commands;

public class CreateProjectCommand : IRequest<ProjectDto>
{
    public int ExternalId { get; set; }

    public int UtcOffset { get; set; }

    public string Description { get; set; } = string.Empty;
        
    public int CompanyId { get; set; }

    public class CreateProjectCommandHandler : CreateCommandBase<CreateProjectCommand,ProjectDto, Project>
    {
        public CreateProjectCommandHandler(ISqlDataContext dataContext, IMapper mapper, IValidator<CreateProjectCommand>? validator) : base(dataContext, mapper, validator)
        {
        }
    }

    public class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
    {
        public CreateProjectCommandValidator(ISqlDataContext dataContext)
        {
            RuleFor(c => c.ExternalId).GreaterThan(0)
                .WithMessage("Внешний идентификатор проекта должен быть больше нуля");
            
            RuleFor(c => c).MustAsync(async(command,cts) =>
            {
                return !await dataContext.Set<Project>()
                    .Where(c => c.ExternalId == command.ExternalId && c.CompanyId == command.CompanyId).AnyAsync();
            }).WithMessage(command=> $"Проект с указанным внеш. идентификатором уже существует");
            
        }
    }
}