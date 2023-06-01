﻿using System;
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
    public string? Description { get; set; } = null;

    public Guid? LanguageId { get; set; } = null;
        
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
            IQueryable<AlarmEventDescription> processDescriptionQuery = _dataContext.Set<AlarmEventDescription>();

            if (request.Id != null)
                processDescriptionQuery = processDescriptionQuery.Where(c => c.Id == request.Id);
            if (request.Description != null)
                processDescriptionQuery = processDescriptionQuery.Where(c => c.Description == request.Description);
            if (request.ProcessId != null)
                processDescriptionQuery = processDescriptionQuery.Where(c => c.AlarmEventId == request.ProcessId);
            if (request.LanguageId != null)
                processDescriptionQuery = processDescriptionQuery.Where(c => c.LanguageId == request.LanguageId);

            var alarmEventsDescriptions = await processDescriptionQuery.ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<ProcessDescriptionDto>>(alarmEventsDescriptions);

        }
    }
}