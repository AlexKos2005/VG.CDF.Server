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

namespace VG.CDF.Server.Application.WorkEmails.Commands;

public class GetWorkEmailsListQuery: IRequest<IEnumerable<WorkEmailDto>>
{
    public Guid? Id { get; set; } = null;
    public Guid? ParameterReportTaskId { get; set; } = null;
    public string? Email { get; set; } = null;

    class GetWorkEmailsListQueryHandler: IRequestHandler<GetWorkEmailsListQuery,IEnumerable<WorkEmailDto>>
    {
        private readonly ISqlDataContext _dataContext;
        private readonly IMapper _mapper;
        public GetWorkEmailsListQueryHandler(ISqlDataContext dataContext,IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }
        public async Task<IEnumerable<WorkEmailDto>> Handle(GetWorkEmailsListQuery request, CancellationToken cancellationToken)
        {
            IQueryable<WorkEmail> workEmailQuery = _dataContext.Set<WorkEmail>();

            if (request.Id != null)
                workEmailQuery = workEmailQuery.Where(c => c.Id == request.Id);
            if (request.ParameterReportTaskId != null)
                workEmailQuery = workEmailQuery.Where(c => c.ParametersReportTaskWorkEmails.Any(c => c.Id == request.ParameterReportTaskId));
            if (request.Email != null)
                workEmailQuery = workEmailQuery.Where(c => c.Email == request.Email);

            var workEmails = await workEmailQuery.ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<WorkEmailDto>>(workEmails);
        }
    }
}

public class GetWorkEmailsListQueryValidator : AbstractValidator<GetWorkEmailsListQuery>
{
    public GetWorkEmailsListQueryValidator(ISqlDataContext dataContext)
    {
        
    }
}
