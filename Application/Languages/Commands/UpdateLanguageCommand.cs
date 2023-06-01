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

namespace VG.CDF.Server.Application.Languages.Commands;

public class UpdateLanguageCommand : EntityBaseDto,IRequest<LanguageDto>
{
    public string Name { get; set; } = string.Empty;

    public class UpdateLanguageCommandHandler : UpdateCommandBase<UpdateLanguageCommand,LanguageDto, Language>
    {
        public UpdateLanguageCommandHandler(ISqlDataContext dataContext, IMapper mapper, IValidator<UpdateLanguageCommand>? validator) : base(dataContext, mapper, validator)
        {
        }
    }

    public class UpdateLanguageCommandValidator : AbstractValidator<UpdateLanguageCommand>
    {
        public UpdateLanguageCommandValidator(ISqlDataContext dataContext)
        {
            RuleFor(c => c).MustAsync(async(command,cts) =>
            {
                return await dataContext.Set<Language>()
                    .EntityIsExists(command.Id);
            }).WithMessage(command=> $"Языка с Id {command.Id} не существует");
            
        }
    }
}