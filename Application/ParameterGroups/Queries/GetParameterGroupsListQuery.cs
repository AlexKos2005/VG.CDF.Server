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

namespace VG.CDF.Server.Application.ParameterGroups.Queries;

public class GetParameterGroupsListQuery: IRequest<IEnumerable<ParameterGroupDto>>
{
    public Guid? Id { get; set; } = null;
    public int? ExternalId { get; set; } = null;

    public string? Name { get; set; } = null;
    
    public class GetParameterGroupListQueryHandler : IRequestHandler<GetParameterGroupsListQuery,IEnumerable<ParameterGroupDto>>
    {
        private readonly ISqlDataContext _dataContext;
        private readonly IMapper _mapper;

        public GetParameterGroupListQueryHandler(ISqlDataContext dataContext,IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ParameterGroupDto>> Handle(GetParameterGroupsListQuery request, CancellationToken cancellationToken)
        {
            IQueryable<ParameterGroup> parameterGroupQuery = _dataContext.Set<ParameterGroup>();

            if (request.Id != null)
                parameterGroupQuery = parameterGroupQuery.Where(c => c.Id == request.Id);
            if (request.ExternalId != null)
                parameterGroupQuery = parameterGroupQuery.Where(c => c.ExternalId == request.ExternalId);
            if (!string.IsNullOrEmpty(request.Name))
                parameterGroupQuery = parameterGroupQuery.Where(c => c.Name.ToLower() == request.Name.ToLower());
            
            var parameterGroups = await parameterGroupQuery.ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<ParameterGroupDto>>(parameterGroups);

        }
    }
}