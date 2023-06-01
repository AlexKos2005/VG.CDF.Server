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

namespace VG.CDF.Server.Application.ParameterDescriptions.Queries;

public class GetParameterDescriptionsListQuery: IRequest<IEnumerable<ParameterDescriptionDto>>
{
    
    public Guid? Id { get; set; } = null;
    public string? Description { get; set; } = null;
    public Guid? ParameterId { get; set; }= null;
    
    public Guid? DescriptionsLanguageId { get; set; }= null;
    
    public class GetParameterDescriptionsListQueryHandler : IRequestHandler<GetParameterDescriptionsListQuery,IEnumerable<ParameterDescriptionDto>>
    {
        private readonly ISqlDataContext _dataContext;
        private readonly IMapper _mapper;

        public GetParameterDescriptionsListQueryHandler(ISqlDataContext dataContext,IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ParameterDescriptionDto>> Handle(GetParameterDescriptionsListQuery request, CancellationToken cancellationToken)
        {
            IQueryable<ParameterDescription> paramDescriptionQuery = _dataContext.Set<ParameterDescription>();

            if (request.Id != null)
                paramDescriptionQuery = paramDescriptionQuery.Where(c => c.Id == request.Id);
            if (request.Description != null)
                paramDescriptionQuery = paramDescriptionQuery.Where(c => c.Description == request.Description);
            if (request.ParameterId != null)
                paramDescriptionQuery = paramDescriptionQuery.Where(c => c.ParameterId == request.ParameterId);
            if (request.DescriptionsLanguageId != null)
                paramDescriptionQuery = paramDescriptionQuery.Where(c => c.LanguageId == request.DescriptionsLanguageId);

            var paramDescriptions = await paramDescriptionQuery.ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<ParameterDescriptionDto>>(paramDescriptions);

        }
    }
}