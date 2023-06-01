using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VG.CDF.Server.Application.Dto;
using VG.CDF.Server.Application.Interfaces;
using VG.CDF.Server.Domain.Entities;

namespace VG.CDF.Server.Application.WorkEmails.Commands;

public class AddWorkEmailToParameterReportTaskCommand : EntityBaseDto,IRequest<WorkEmailDto>
{
    public Guid Id { get; set; }
    public Guid ParameterReportTaskId { get; set; }

    class AddWorkEmailToTagReportTaskCommandHandler : IRequestHandler<AddWorkEmailToParameterReportTaskCommand,WorkEmailDto>
    {
        private readonly ISqlDataContext _dataContext;
        private readonly IMapper _mapper;
        private readonly IValidator<AddWorkEmailToParameterReportTaskCommand>? _validator;

        public AddWorkEmailToTagReportTaskCommandHandler(ISqlDataContext dataContext,IMapper mapper,IValidator<AddWorkEmailToParameterReportTaskCommand>? validator)
        {
            _dataContext = dataContext;
            _mapper = mapper;
            _validator = validator;
        }
        public async Task<WorkEmailDto> Handle(AddWorkEmailToParameterReportTaskCommand request, CancellationToken cancellationToken)
        {
            if (_validator != null)
            {
                await _validator.ValidateAndThrowAsync(request, cancellationToken);
            }

            var workEmail = await _dataContext.Set<WorkEmail>()
                .AsTracking().Where(c => c.Id == request.Id).FirstAsync(cancellationToken);

            var parameterReportTask = await _dataContext.Set<ParameterReportTask>()
                .Where(c => c.Id == request.ParameterReportTaskId).FirstAsync();
            
            await _dataContext.Set<ParametersReportTaskWorkEmail>().AddAsync(
            
                new ParametersReportTaskWorkEmail
                {
                    ParameterReportTask = parameterReportTask,
                    WorkEmail = workEmail
                }
            );

            await _dataContext.SaveChangesAsync(cancellationToken);

            return _mapper.Map<WorkEmailDto>(workEmail);
        }
    }
    
}

public class AddWorkEmailToTagReportTaskValidator : AbstractValidator<AddWorkEmailToParameterReportTaskCommand>
{
    public AddWorkEmailToTagReportTaskValidator(ISqlDataContext dataContext)
    {
        RuleFor(command => command).MustAsync(async (command, cts) =>
        {
            return await dataContext.Set<WorkEmail>()
                .Where(c => c.Id == command.Id)
                .AnyAsync();
        }).WithMessage($"Указанный адрес электронной почты с таким Id не существует");
        
        RuleFor(command => command).MustAsync(async (command, cts) =>
        {
            return await dataContext.Set<ParameterReportTask>()
                .Where(c => c.Id == command.ParameterReportTaskId)
                .AnyAsync();
        }).WithMessage($"Указанная задача отчетов по тегам с таким Id не существует");
    }
}
