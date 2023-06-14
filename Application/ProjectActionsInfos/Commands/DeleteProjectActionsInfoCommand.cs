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

namespace VG.CDF.Server.Application.ProjectActionsInfos.Commands;

public class DeleteProjectActionsInfoCommand : EntityBaseDto,IRequest<bool>
{
    
    public class DeleteProjectActionsInfoCommandHandler : DeleteCommandBase<DeleteProjectActionsInfoCommand, ProjectActionsInfo>
    {
        public DeleteProjectActionsInfoCommandHandler(ISqlDataContext dataContext, IMapper mapper, IValidator<DeleteProjectActionsInfoCommand>? validator) 
            : base(dataContext, mapper, validator)
        {
        }
    }

    public class DeleteProjectActionsInfoCommandValidator : AbstractValidator<DeleteProjectActionsInfoCommand>
    {
        public DeleteProjectActionsInfoCommandValidator(ISqlDataContext dataContext)
        {
            
        }
    }
}