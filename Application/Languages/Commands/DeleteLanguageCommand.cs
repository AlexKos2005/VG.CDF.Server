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

public class DeleteLanguageCommand : EntityBaseDto,IRequest<bool>
{
    
    public class DeleteLanguageCommandHandler : DeleteCommandBase<DeleteLanguageCommand, Language>
    {
        public DeleteLanguageCommandHandler(ISqlDataContext dataContext, IMapper mapper, IValidator<DeleteLanguageCommand>? validator) : base(dataContext, mapper, validator)
        {
        }
    }

    public class DeleteLanguageCommandValidator : AbstractValidator<DeleteLanguageCommand>
    {
        public DeleteLanguageCommandValidator(ISqlDataContext dataContext)
        {
            RuleFor(c => c).MustAsync(async(command,cts) =>
            {
                return await dataContext.Set<Language>()
                    .EntityIsExists(command.Id);
            }).WithMessage(command=> $"Язык с Id {command.Id} не существует");
            
        }
    }
}