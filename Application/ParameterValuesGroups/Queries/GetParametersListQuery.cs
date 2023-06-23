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

namespace VG.CDF.Server.Application.ParameterValuesGroups.Queries;

public class GetParameterValuesGroupsListQuery: IRequest<IEnumerable<ParameterValuesGroupDto>>
{
    public int? Id { get; set; } = null;
    //Время фиксации
    public DateTime DateTime { get; set; } = DateTime.Now;

    //Время фиксации по UTC
    public DateTimeOffset DateTimeOffset { get; set; }= DateTime.Now;

    public Guid? ProcessId { get; set; }= null;
    
    public class GetParameterValuesGroupsListQueryHandler : IRequestHandler<GetParameterValuesGroupsListQuery,IEnumerable<ParameterValuesGroupDto>>
    {
        private readonly ISqlDataContext _dataContext;
        private readonly IMapper _mapper;

        public GetParameterValuesGroupsListQueryHandler(ISqlDataContext dataContext,IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ParameterValuesGroupDto>> Handle(GetParameterValuesGroupsListQuery request, CancellationToken cancellationToken)
        {
            IQueryable<ParameterValuesGroup> parameterQuery = _dataContext.Set<ParameterValuesGroup>();

            if (request.Id != null)
                parameterQuery = parameterQuery.Where(c => c.Id == request.Id);
            
            if (request.ProcessId != null)
                parameterQuery = parameterQuery.Where(c => c.Process.Id == request.ProcessId);
            
                parameterQuery = parameterQuery.Where(c => c.DateTime == request.DateTime);
                
                parameterQuery = parameterQuery.Where(c => c.DateTimeOffset == request.DateTimeOffset);
            
            var parameters = await parameterQuery.ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<ParameterValuesGroupDto>>(parameters);

        }
    }
}