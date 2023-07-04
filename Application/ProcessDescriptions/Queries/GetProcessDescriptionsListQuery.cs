using System;
using System.Collections.Generic;
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

namespace VG.CDF.Server.Application.ProcessDescriptions.Queries;

public class GetProcessDescriptionsListQuery: IRequest<IEnumerable<ProcessDescriptionDto>>
{
    
    public Guid? Id { get; set; } = null;
    public string? RusDescription { get; set; } = null;
        
    public string? EngDescription { get; set; } = null;
        
    public string? UkrDescription { get; set; } = null;
    
    public Guid? ProjectId { get; set; } = null;
    public Guid? ProcessId { get; set; } = null;
    
    public class GetProcessDescriptionsListQueryHandler : IRequestHandler<GetProcessDescriptionsListQuery,IEnumerable<ProcessDescriptionDto>>
    {
        private readonly ISqlDataContext _dataContext;
        private readonly IMapper _mapper;

        public GetProcessDescriptionsListQueryHandler(ISqlDataContext dataContext,IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ProcessDescriptionDto>> Handle(GetProcessDescriptionsListQuery request, CancellationToken cancellationToken)
        {
            IQueryable<ProcessDescription> processDescriptionQuery = _dataContext.Set<ProcessDescription>();

            if (request.Id != null)
                processDescriptionQuery = processDescriptionQuery.Where(c => c.Id == request.Id);
            if (request.RusDescription != null)
                processDescriptionQuery = processDescriptionQuery.Where(c => c.RusDescription.ToLower() == request.RusDescription.ToLower());
            if (request.EngDescription != null)
                processDescriptionQuery = processDescriptionQuery.Where(c => c.EngDescription.ToLower() == request.EngDescription.ToLower());
            if (request.UkrDescription != null)
                processDescriptionQuery = processDescriptionQuery.Where(c => c.UkrDescription.ToLower() == request.UkrDescription.ToLower());
            if (request.ProcessId != null)
                processDescriptionQuery = processDescriptionQuery.Where(c => c.ProcessId == request.ProcessId);
            if (request.ProjectId != null)
                processDescriptionQuery = processDescriptionQuery.Where(c => c.Process.ProjectId == request.ProjectId);

            var alarmEventsDescriptions = await processDescriptionQuery.ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<ProcessDescriptionDto>>(alarmEventsDescriptions);

        }
    }
}