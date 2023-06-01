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

public class CreateProjectActionsInfoCommand : IRequest<ProjectActionsInfoDto>
{
    public DateTime LastDateTimeConnection { get; set; }

    public DateTime LastDateTimeReportSending { get; set; }

    public DateTimeOffset LastDateTimeConnectionOffset { get; set; }

    public DateTimeOffset LastDateTimeReportSendingOffset { get; set; }

    public int AlarmMessageCounter { get; set; }

    public int ProjectId { get; set; }

    public class CreateProjectCommandHandler : CreateCommandBase<CreateProjectActionsInfoCommand,ProjectActionsInfoDto, ProjectActionsInfo>
    {
        public CreateProjectCommandHandler(ISqlDataContext dataContext, IMapper mapper, IValidator<CreateProjectActionsInfoCommand>? validator) 
            : base(dataContext, mapper, validator)
        {
        }
    }

    public class CreateProjectActionsInfoCommandValidator : AbstractValidator<CreateProjectActionsInfoCommand>
    {
        public CreateProjectActionsInfoCommandValidator(ISqlDataContext dataContext)
        {
            
        }
    }
}