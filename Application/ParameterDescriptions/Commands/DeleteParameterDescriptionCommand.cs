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

public class DeleteParameterDescriptionCommand : EntityBaseDto,IRequest<bool>
{
    
    public class DeleteParameterDescriptionCommandHandler : DeleteCommandBase<DeleteParameterDescriptionCommand, ParameterDescription>
    {
        public DeleteParameterDescriptionCommandHandler(ISqlDataContext dataContext, IMapper mapper, IValidator<DeleteParameterDescriptionCommand>? validator) 
            : base(dataContext, mapper, validator)
        {
        }
    }

    public class DeleteParameterDescriptionCommandValidator : AbstractValidator<DeleteParameterDescriptionCommand>
    {
        public DeleteParameterDescriptionCommandValidator(ISqlDataContext dataContext)
        {
            RuleFor(c => c).MustAsync(async(command,cts) =>
            {
                return await dataContext.Set<ParameterDescription>()
                    .EntityIsExists(command.Id);
            }).WithMessage(command=> $"Описания параметра с Id {command.Id} не существует");
            
        }
    }
}