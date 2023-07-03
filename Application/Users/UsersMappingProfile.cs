using AutoMapper;
using VG.CDF.Server.Application.Dto;
using VG.CDF.Server.Application.Projects.Commands;
using VG.CDF.Server.Application.Roles.Commands;
using VG.CDF.Server.Application.Users.Commands;
using VG.CDF.Server.Domain.Entities;

namespace VG.CDF.Server.Application.Users;

public class UsersMappingProfile : Profile
{
    public UsersMappingProfile()
    {
        CreateMap<User, UserDto>().ReverseMap();
        CreateMap<CreateUserCommand, User>().ReverseMap();
        CreateMap<DeleteUserCommand, EntityBase>().ReverseMap();
        CreateMap<UpdateUserCommand, User>().ReverseMap();
    }
}