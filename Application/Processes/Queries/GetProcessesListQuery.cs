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

namespace VG.CDF.Server.Application.Processes.Queries;

public class GetProcessesListQuery: IRequest<IEnumerable<ProcessDto>>
{
    public Guid? Id { get; set; } = null;
    public int? ExternalId { get; set; } = null;
    public int? DeviceCode { get; set; } = null;
    public string? DeviceIp { get; set; } = null;
    public Guid? ProjectId { get; set; } = null;
    
    public class GetLanguagesListQueryHandler : IRequestHandler<GetProcessesListQuery,IEnumerable<ProcessDto>>
    {
        private readonly ISqlDataContext _dataContext;
        private readonly IMapper _mapper;

        public GetLanguagesListQueryHandler(ISqlDataContext dataContext,IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ProcessDto>> Handle(GetProcessesListQuery request, CancellationToken cancellationToken)
        {
            IQueryable<Process> processQuery = _dataContext.Set<Process>();

            if (request.Id != null)
                processQuery = processQuery.Where(c => c.Id == request.Id);
            if (request.ExternalId != null)
                processQuery = processQuery.Where(c => c.ExternalId == request.ExternalId);
            if (!string.IsNullOrEmpty(request.DeviceIp))
                processQuery = processQuery.Where(c => c.DeviceIp.ToLower() == request.DeviceIp.ToLower());
            if (request.DeviceCode != null)
                processQuery = processQuery.Where(c => c.DeviceCode == request.DeviceCode);
            if (request.ProjectId != null)
                processQuery = processQuery.Where(c => c.ProjectId == request.ProjectId);
            
            var processes = await processQuery.ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<ProcessDto>>(processes);

        }
    }
}