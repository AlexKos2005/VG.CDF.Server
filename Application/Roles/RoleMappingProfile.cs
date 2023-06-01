using AutoMapper;
using VG.CDF.Server.Application.Dto;
using VG.CDF.Server.Application.Projects.Commands;
using VG.CDF.Server.Application.Roles.Commands;
using VG.CDF.Server.Domain.Entities;

namespace VG.CDF.Server.Application.Roles;

public class RolesMappingProfile : Profile
{
    public RolesMappingProfile()
    {
        CreateMap<Role, RoleDto>().ReverseMap();
        CreateMap<CreateRoleCommand, EntityBase>().ReverseMap();
        CreateMap<DeleteRoleCommand, EntityBase>().ReverseMap();
        CreateMap<UpdateRoleCommand, EntityBase>().ReverseMap();
    }
}