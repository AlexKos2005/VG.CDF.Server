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

namespace VG.CDF.Server.Application.Parameters.Queries;

public class GetParametersListQuery: IRequest<IEnumerable<ParameterDto>>
{
    public Guid? Id { get; set; } = null;
    public int? ExternalId { get; set; } = null;

    public ParameterValueType? ValueType { get; set; } = null;

    public Guid? CompanyId { get; set; } = null;

    public Guid? ParameterGroupId { get; set; } = null;
    
    public class GetLanguagesListQueryHandler : IRequestHandler<GetParametersListQuery,IEnumerable<ParameterDto>>
    {
        private readonly ISqlDataContext _dataContext;
        private readonly IMapper _mapper;

        public GetLanguagesListQueryHandler(ISqlDataContext dataContext,IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ParameterDto>> Handle(GetParametersListQuery request, CancellationToken cancellationToken)
        {
            IQueryable<Parameter> parameterQuery = _dataContext.Set<Parameter>();

            if (request.Id != null)
                parameterQuery = parameterQuery.Where(c => c.Id == request.Id);
            if (request.ExternalId != null)
                parameterQuery = parameterQuery.Where(c => c.ExternalId == request.ExternalId);
            if (request.ValueType != null)
                parameterQuery = parameterQuery.Where(c => c.ValueType == request.ValueType);
            if (request.CompanyId != null)
                parameterQuery = parameterQuery.Where(c => c.CompanyId == request.CompanyId);
            if (request.ParameterGroupId != null)
                parameterQuery = parameterQuery.Where(c => c.ParameterGroupId == request.ParameterGroupId);
            
            var parameters = await parameterQuery.ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<ParameterDto>>(parameters);

        }
    }
}