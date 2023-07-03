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

namespace VG.CDF.Server.Application.AlarmEventDescriptions.Queries;

public class GetAlarmEventDescriptionsListQuery: IRequest<IEnumerable<AlarmEventDescriptionDto>>
{
    
    public Guid? Id { get; set; } = null;
    
    public Guid? CompanyId { get; set; } = null;
    public string? RusDescription { get; set; } = null;
        
    public string? EngDescription { get; set; } = null;
        
    public string? UkrDescription { get; set; } = null;
    public Guid? AlarmEventId { get; set; }= null;
    
    
    public class GetAlarmEventsListQueryHandler : IRequestHandler<GetAlarmEventDescriptionsListQuery,IEnumerable<AlarmEventDescriptionDto>>
    {
        private readonly ISqlDataContext _dataContext;
        private readonly IMapper _mapper;

        public GetAlarmEventsListQueryHandler(ISqlDataContext dataContext,IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }
        public async Task<IEnumerable<AlarmEventDescriptionDto>> Handle(GetAlarmEventDescriptionsListQuery request, CancellationToken cancellationToken)
        {
            IQueryable<AlarmEventDescription> alarmDescriptionQuery = _dataContext.Set<AlarmEventDescription>();

            if (request.Id != null)
                alarmDescriptionQuery = alarmDescriptionQuery.Where(c => c.Id == request.Id);
            if (request.CompanyId != null)
                alarmDescriptionQuery = alarmDescriptionQuery.Where(c => c.AlarmEvent.CompanyId == request.CompanyId);
            if (request.RusDescription != null)
                alarmDescriptionQuery = alarmDescriptionQuery.Where(c => c.RusDescription.ToLower() == request.RusDescription.ToLower());
            if (request.EngDescription != null)
                alarmDescriptionQuery = alarmDescriptionQuery.Where(c => c.EngDescription.ToLower() == request.EngDescription.ToLower());
            if (request.UkrDescription != null)
                alarmDescriptionQuery = alarmDescriptionQuery.Where(c => c.UkrDescription.ToLower() == request.UkrDescription.ToLower());
            if (request.AlarmEventId != null)
                alarmDescriptionQuery = alarmDescriptionQuery.Where(c => c.AlarmEventId == request.AlarmEventId);

            var alarmEventsDescriptions = await alarmDescriptionQuery.ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<AlarmEventDescriptionDto>>(alarmEventsDescriptions);

        }
    }
}