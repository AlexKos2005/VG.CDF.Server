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

public class AddParametersToProcessCommand : EntityBaseDto,IRequest<bool>
{
    public Guid[] ParametersId { get; set; } = Array.Empty<Guid>();

    public class AddParameterToProcessCommandHandler : IRequestHandler<AddParametersToProcessCommand,bool>
    {
        private readonly ISqlDataContext _dataContext;
        private readonly IMapper _mapper;
        private readonly IValidator<AddParametersToProcessCommand>? _validator;
        public AddParameterToProcessCommandHandler(ISqlDataContext dataContext, IMapper mapper, IValidator<AddParametersToProcessCommand>? validator)
        {
            _dataContext = dataContext;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<bool> Handle(AddParametersToProcessCommand request, CancellationToken cancellationToken)
        {
            if(_validator != null)
                await _validator.ValidateAndThrowAsync(request, cancellationToken);
            var paramProc = _dataContext.Set<ParameterProcess>();
            
            foreach (var paramId in request.ParametersId)
            {
                if (await paramProc.Where(c => c.ParameterId == paramId && c.ProcessId == request.Id)
                        .AnyAsync(cancellationToken: cancellationToken) == false)
                {
                    await paramProc.AddAsync(new ParameterProcess(){ParameterId = paramId, ProcessId = request.Id},cancellationToken);
                }
            }
            
            await _dataContext.SaveChangesAsync(cancellationToken);

            return true;
        }
    }

    public class AddParameterToProcessCommandValidator : AbstractValidator<AddParametersToProcessCommand>
    {
    }
}