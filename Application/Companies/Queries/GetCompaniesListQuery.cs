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

namespace VG.CDF.Server.Application.Companies.Queries;

public class GetCompaniesListQuery: IRequest<IEnumerable<CompanyDto>>
{
    public Guid? Id { get; set; } = null;

    public string? Name { get; set; } = null;
    
    public class GetCompaniesListQueryHandler : IRequestHandler<GetCompaniesListQuery,IEnumerable<CompanyDto>>
    {
        private readonly ISqlDataContext _dataContext;
        private readonly IMapper _mapper;

        public GetCompaniesListQueryHandler(ISqlDataContext dataContext,IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CompanyDto>> Handle(GetCompaniesListQuery request, CancellationToken cancellationToken)
        {
            IQueryable<Company> companyQuery = _dataContext.Set<Company>();

            if (request.Id != null)
                companyQuery = companyQuery.Where(c => c.Id == request.Id);
            if (!string.IsNullOrEmpty(request.Name))
                companyQuery = companyQuery.Where(c => c.Name.ToLower() == request.Name.ToLower());
            
            var companies = await companyQuery.ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<CompanyDto>>(companies);

        }
    }
}