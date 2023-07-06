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
using VG.CDF.Server.Domain.Enums;

namespace VG.CDF.Server.Application.ParameterReportTasks.Queries;

public class GetParameterReportTasksListQuery: IRequest<IEnumerable<ParameterReportTaskDto>>
{
    public Guid? Id { get; set; } = null;
    public Guid? ProjectId { get; set; }= null;
    public bool? IsActive { get; set; }= null;
    public  DateTimeOffset? LastSendDt { get; set; }= null;

    public ReportTaskStatus? Status { get; set; } = null;

    public class GetParameterReportTasksListQueryHandler : IRequestHandler<GetParameterReportTasksListQuery,IEnumerable<ParameterReportTaskDto>>
    {
        private readonly ISqlDataContext _dataContext;
        private readonly IMapper _mapper;

        public GetParameterReportTasksListQueryHandler(ISqlDataContext dataContext,IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ParameterReportTaskDto>> Handle(GetParameterReportTasksListQuery request, CancellationToken cancellationToken)
        {
            IQueryable<ParameterReportTask> paramReportTaskQuery = _dataContext.Set<ParameterReportTask>();

            if (request.Id != null)
                paramReportTaskQuery = paramReportTaskQuery.Where(c => c.Id == request.Id);
            if (request.ProjectId != null)
                paramReportTaskQuery = paramReportTaskQuery.Where(c => c.ProjectId == request.ProjectId);
            if (request.IsActive != null)
                paramReportTaskQuery = paramReportTaskQuery.Where(c => c.IsActive == request.IsActive);
            if (request.LastSendDt != null)
                paramReportTaskQuery = paramReportTaskQuery.Where(c => c.LastSendDt == request.LastSendDt);
            if (request.Status != null)
                paramReportTaskQuery = paramReportTaskQuery.Where(c => c.Status == request.Status);

            var paramReportTasks = await paramReportTaskQuery.ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<ParameterReportTaskDto>>(paramReportTasks);
        }
    }

}

public class GetTagReportTasksListQueryValidator : AbstractValidator<GetParameterReportTasksListQuery>
{
    public GetTagReportTasksListQueryValidator(ISqlDataContext dataContext)
    {
    }
}
