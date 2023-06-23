using System;
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

namespace VG.CDF.Server.Application.ParameterDescriptions.Commands;

public class CreateParameterDescriptionCommand : IRequest<ParameterDescriptionDto>
{
    public string Description { get; set; } = string.Empty;

    public Guid LanguageId { get; set; }

    public Guid ParameterId { get; set; }

    public class CreateParameterDescriptionCommandHandler : CreateCommandBase<CreateParameterDescriptionCommand,ParameterDescriptionDto, ParameterDescription>
    {
        public CreateParameterDescriptionCommandHandler(ISqlDataContext dataContext, IMapper mapper, IValidator<CreateParameterDescriptionCommand>? validator) 
            : base(dataContext, mapper, validator)
        {
        }
    }

    public class CreateParameterDescriptionCommandValidator : AbstractValidator<CreateParameterDescriptionCommand>
    {
        public CreateParameterDescriptionCommandValidator(ISqlDataContext dataContext)
        {
            RuleFor(c => c.Description).NotEmpty()
                .WithMessage("Описание параметра не должно быть пустым");
            RuleFor(c => c).MustAsync(async(command,cts) =>
            {
                return await dataContext.Set<Parameter>()
                    .EntityIsExists(command.ParameterId);
            }).WithMessage(command=> $"Параметра с Id {command.ParameterId} не существует");
            
            RuleFor(c => c).MustAsync(async(command,cts) =>
            {
                return await dataContext.Set<Language>()
                    .EntityIsExists(command.LanguageId);
            }).WithMessage(command=> $"Языка с Id {command.ParameterId} не существует");
            
        }
    }
}