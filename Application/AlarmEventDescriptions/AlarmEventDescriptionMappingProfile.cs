using AutoMapper;
using VG.CDF.Server.Application.AlarmEventDescriptions.Commands;
using VG.CDF.Server.Application.AlarmEvents.Commands;
using VG.CDF.Server.Application.Companies.Commands;
using VG.CDF.Server.Application.Dto;
using VG.CDF.Server.Application.ParameterDescriptions.Commands;
using VG.CDF.Server.Application.ParameterGroups.Commands;
using VG.CDF.Server.Application.ProcessDescriptions.Commands;
using VG.CDF.Server.Application.Processes.Commands;
using VG.CDF.Server.Application.Projects.Commands;
using VG.CDF.Server.Domain.Entities;

namespace VG.CDF.Server.Application.AlarmEventDescriptions;

public class AlarmEventDescriptionMappingProfile : Profile
{
    public AlarmEventDescriptionMappingProfile()
    {
        CreateMap<AlarmEventDescription, AlarmEventDescriptionDto>().ReverseMap();
        CreateMap<CreateAlarmEventDescriptionCommand, AlarmEventDescription>().ReverseMap();
        CreateMap<DeleteAlarmEventDescriptionCommand, EntityBase>().ReverseMap();
        CreateMap<UpdateAlarmEventDescriptionCommand, AlarmEventDescription>().ReverseMap();
    }
}