using System.Linq;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VG.CDF.Server.Application.CommandBase;
using VG.CDF.Server.Application.Dto;
using VG.CDF.Server.Application.Interfaces;
using VG.CDF.Server.Domain.Entities;

namespace VG.CDF.Server.Application.Languages.Commands;

public class CreateLanguageCommand : IRequest<LanguageDto>
{
    public int ExternalId { get; set; }
    public string Acronym { get; set; } = string.Empty;

    public class CreateLanguageCommandHandler : CreateCommandBase<CreateLanguageCommand,LanguageDto, Language>
    {
        public CreateLanguageCommandHandler(ISqlDataContext dataContext, IMapper mapper, IValidator<CreateLanguageCommand>? validator) : base(dataContext, mapper, validator)
        {
        }
    }

    public class CreateLanguageCommandValidator : AbstractValidator<CreateLanguageCommand>
    {
        public CreateLanguageCommandValidator(ISqlDataContext dataContext)
        {
            RuleFor(c => c.ExternalId).GreaterThan(0)
                .WithMessage("Внешний идентификатор языка должен быть больше нуля");
            
            RuleFor(c => c.Acronym).NotEmpty().WithMessage("Акроним языка не может быть пустым");
            
            RuleFor(c => c).MustAsync(async(command,cts) =>
            {
                return !await dataContext.Set<Language>()
                    .Where(c => c.ExternalId == command.ExternalId).AnyAsync();
            }).WithMessage(command=> $"Язык с указанным внеш. идентификатором уже существует");
            
            RuleFor(c => c).MustAsync(async(command,cts) =>
            {
                return !await dataContext.Set<Language>()
                    .Where(c => c.Acronym.ToLower() == command.Acronym.ToLower()).AnyAsync();
            }).WithMessage(command=> $"Язык с указанным акронимом уже существует");
            
        }
    }
}