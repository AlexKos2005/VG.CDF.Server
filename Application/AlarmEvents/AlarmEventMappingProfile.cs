using AutoMapper;
using VG.CDF.Server.Application.AlarmEvents.Commands;
using VG.CDF.Server.Application.Companies.Commands;
using VG.CDF.Server.Application.Dto;
using VG.CDF.Server.Application.ParameterDescriptions.Commands;
using VG.CDF.Server.Application.ParameterGroups.Commands;
using VG.CDF.Server.Application.ProcessDescriptions.Commands;
using VG.CDF.Server.Application.Processes.Commands;
using VG.CDF.Server.Application.Projects.Commands;
using VG.CDF.Server.Domain.Entities;

namespace VG.CDF.Server.Application.AlarmEvents;

public class AlarmEventMappingProfile : Profile
{
    public AlarmEventMappingProfile()
    {
        CreateMap<AlarmEvent, AlarmEventDto>().ReverseMap();
        CreateMap<CreateAlarmEventCommand, AlarmEvent>().ReverseMap();
        CreateMap<DeleteAlarmEventCommand, EntityBase>().ReverseMap();
        CreateMap<UpdateAlarmEventCommand, AlarmEvent>().ReverseMap();
     
    }
}