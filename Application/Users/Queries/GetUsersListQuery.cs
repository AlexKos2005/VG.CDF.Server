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

namespace VG.CDF.Server.Application.Users.Queries;

public class GetUsersListQuery: IRequest<IEnumerable<UserDto>>
{
    public Guid? Id { get; set; } = null;

    public string? Email { get; set; } = null;

    public Guid? RoleId { get; set; } = null;
    
    public class GetProjectsListQueryHandler : IRequestHandler<GetUsersListQuery,IEnumerable<UserDto>>
    {
        private readonly ISqlDataContext _dataContext;
        private readonly IMapper _mapper;

        public GetProjectsListQueryHandler(ISqlDataContext dataContext,IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }
        public async Task<IEnumerable<UserDto>> Handle(GetUsersListQuery request, CancellationToken cancellationToken)
        {
            IQueryable<User> userQuery = _dataContext.Set<User>();

            if (request.Id != null)
                userQuery = userQuery.Where(c => c.Id == request.Id);
            if (string.IsNullOrEmpty(request.Email) == false)
                userQuery = userQuery.Where(c => c.Email == request.Email);
            if (request.RoleId != null)
                userQuery = userQuery.Where(c => c.RoleId == request.RoleId);

            var users = await userQuery.ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<UserDto>>(users);

        }
    }
}