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

namespace VG.CDF.Server.Application.ProjectActionsInfos.Queries;

public class GetProjectActionsInfoListQuery: IRequest<IEnumerable<ProjectActionsInfoDto>>
{
    public Guid? Id { get; set; } = null;
    
    public DateTime? LastDateTimeConnection { get; set; } = null;

    public DateTime? LastDateTimeReportSending { get; set; } = null;

    public DateTimeOffset? LastDateTimeConnectionOffset { get; set; } = null;

    public DateTimeOffset? LastDateTimeReportSendingOffset { get; set; } = null;

    public int? AlarmMessageCounter { get; set; } = null;

    public Guid? ProjectId { get; set; } = null;

    
    public class GetProjectActionsInfosListQueryHandler : IRequestHandler<GetProjectActionsInfoListQuery,IEnumerable<ProjectActionsInfoDto>>
    {
        private readonly ISqlDataContext _dataContext;
        private readonly IMapper _mapper;

        public GetProjectActionsInfosListQueryHandler(ISqlDataContext dataContext,IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ProjectActionsInfoDto>> Handle(GetProjectActionsInfoListQuery request, CancellationToken cancellationToken)
        {
            IQueryable<ProjectActionsInfo> projectActionQuery = _dataContext.Set<ProjectActionsInfo>();

            if (request.Id != null)
                projectActionQuery = projectActionQuery.Where(c => c.Id == request.Id);
            if (request.ProjectId != null)
                projectActionQuery = projectActionQuery.Where(c => c.ProjectId == request.ProjectId);
            if (request.AlarmMessageCounter != null)
                projectActionQuery = projectActionQuery.Where(c => c.AlarmMessageCounter == request.AlarmMessageCounter);
            if (request.LastDateTimeConnection != null)
                projectActionQuery = projectActionQuery.Where(c => c.LastDateTimeConnection == request.LastDateTimeConnection);
            if (request.LastDateTimeReportSending != null)
                projectActionQuery = projectActionQuery.Where(c => c.LastDateTimeReportSending == request.LastDateTimeReportSending);
            if (request.LastDateTimeConnectionOffset != null)
                projectActionQuery = projectActionQuery.Where(c => c.LastDateTimeConnectionOffset == request.LastDateTimeConnectionOffset);
            if (request.LastDateTimeReportSendingOffset != null)
                projectActionQuery = projectActionQuery.Where(c => c.LastDateTimeReportSendingOffset == request.LastDateTimeReportSendingOffset);
           
            
            var processes = await projectActionQuery.ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<ProjectActionsInfoDto>>(processes);

        }
    }
}