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

namespace VG.CDF.Server.Application.Roles.Queries;

public class GetRolesListQuery: IRequest<IEnumerable<RoleDto>>
{
    public Guid? Id { get; set; } = null;
    public string? RoleName { get; set; } = null;

    public RoleCode? RoleCode { get; set; } = null;
    
    public class GetProjectsListQueryHandler : IRequestHandler<GetRolesListQuery,IEnumerable<RoleDto>>
    {
        private readonly ISqlDataContext _dataContext;
        private readonly IMapper _mapper;

        public GetProjectsListQueryHandler(ISqlDataContext dataContext,IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }
        public async Task<IEnumerable<RoleDto>> Handle(GetRolesListQuery request, CancellationToken cancellationToken)
        {
            IQueryable<Role> roleQuery = _dataContext.Set<Role>();

            if (request.Id != null)
                roleQuery = roleQuery.Where(c => c.Id == request.Id);
            if (string.IsNullOrEmpty(request.RoleName))
                roleQuery = roleQuery.Where(c => c.RoleName == request.RoleName);
            if (request.RoleCode != null)
                roleQuery = roleQuery.Where(c => c.RoleCode == request.RoleCode);

            var roles = await roleQuery.ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<RoleDto>>(roles);

        }
    }
}