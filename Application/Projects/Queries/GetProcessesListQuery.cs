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

namespace VG.CDF.Server.Application.Projects.Queries;

public class GetProjectListQuery: IRequest<IEnumerable<ProjectDto>>
{
    public Guid? Id { get; set; } = null;
    public int? ExternalId { get; set; } = null;

    public int? UtcOffset { get; set; }= null;

    public string? Description { get; set; } = null;
        
    public Guid? CompanyId { get; set; } = null;
    
    public class GetProjectsListQueryHandler : IRequestHandler<GetProjectListQuery,IEnumerable<ProjectDto>>
    {
        private readonly ISqlDataContext _dataContext;
        private readonly IMapper _mapper;

        public GetProjectsListQueryHandler(ISqlDataContext dataContext,IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ProjectDto>> Handle(GetProjectListQuery request, CancellationToken cancellationToken)
        {
            IQueryable<Project> projectQuery = _dataContext.Set<Project>();

            if (request.Id != null)
                projectQuery = projectQuery.Where(c => c.Id == request.Id);
            if (request.ExternalId != null)
                projectQuery = projectQuery.Where(c => c.ExternalId == request.ExternalId);
            if (request.CompanyId != null)
                projectQuery = projectQuery.Where(c => c.CompanyId == request.CompanyId);
            if (string.IsNullOrEmpty(request.Description))
                projectQuery = projectQuery.Where(c => c.Description == request.Description);
            if (request.UtcOffset != null)
                projectQuery = projectQuery.Where(c => c.UtcOffset == request.UtcOffset);
            
            var processes = await projectQuery.ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<ProjectDto>>(processes);

        }
    }
}