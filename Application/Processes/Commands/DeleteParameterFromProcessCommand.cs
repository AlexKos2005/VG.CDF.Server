using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VG.CDF.Server.Application.CommandBase;
using VG.CDF.Server.Application.Dto;
using VG.CDF.Server.Application.Interfaces;
using VG.CDF.Server.Domain.Entities;

namespace VG.CDF.Server.Application.Processes.Commands;

public class DeleteParameterFromProcessCommand : EntityBaseDto,IRequest<bool>
{
    public Guid ParameterId { get; set; }

    public class DeleteParameterFromProcessCommandHandler : IRequestHandler<DeleteParameterFromProcessCommand,bool>
    {
        private readonly ISqlDataContext _dataContext;
        private readonly IMapper _mapper;
        private readonly IValidator<DeleteParameterFromProcessCommand>? _validator;
        public DeleteParameterFromProcessCommandHandler(ISqlDataContext dataContext, IMapper mapper, IValidator<DeleteParameterFromProcessCommand>? validator)
        {
            _dataContext = dataContext;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<bool> Handle(DeleteParameterFromProcessCommand request, CancellationToken cancellationToken)
        {
            if(_validator != null)
                await _validator.ValidateAndThrowAsync(request, cancellationToken);
            var paramProc = _dataContext.Set<ParameterProcess>();

            var targetParamProc = await paramProc.FirstOrDefaultAsync(c => c.ParameterId == request.ParameterId && c.ProcessId == request.Id,cancellationToken: cancellationToken);
            
            if (targetParamProc != null)
            {
                paramProc.Remove(targetParamProc);
            }
            
            
            await _dataContext.SaveChangesAsync(cancellationToken);

            return true;
        }
    }

    public class DeleteParameterFromProcessCommandValidator : AbstractValidator<DeleteParameterFromProcessCommand>
    {
    }
}