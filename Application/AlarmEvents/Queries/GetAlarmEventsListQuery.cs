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

namespace VG.CDF.Server.Application.AlarmEvents.Queries;

public class GetAlarmEventsListQuery: IRequest<IEnumerable<AlarmEventDto>>
{
    public Guid? Id { get; set; } = null;

    public int? ExternalId { get; set; } = null;

    public Guid? CompanyId { get; set; } = null;
    
    public class GetAlarmEventsListQueryHandler : IRequestHandler<GetAlarmEventsListQuery,IEnumerable<AlarmEventDto>>
    {
        private readonly ISqlDataContext _dataContext;
        private readonly IMapper _mapper;

        public GetAlarmEventsListQueryHandler(ISqlDataContext dataContext,IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }
        public async Task<IEnumerable<AlarmEventDto>> Handle(GetAlarmEventsListQuery request, CancellationToken cancellationToken)
        {
            IQueryable<AlarmEvent> alarmQuery = _dataContext.Set<AlarmEvent>();

            if (request.Id != null)
                alarmQuery = alarmQuery.Where(c => c.Id == request.Id);
            if (request.ExternalId != null)
                alarmQuery = alarmQuery.Where(c => c.ExternalId == request.ExternalId);
            if (request.CompanyId != null)
                alarmQuery = alarmQuery.Where(c => c.CompanyId == request.CompanyId);

            var alarmEvents = await alarmQuery.ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<AlarmEventDto>>(alarmEvents);

        }
    }
}