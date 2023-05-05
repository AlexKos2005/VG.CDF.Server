using AutoMapper;
using VG.CDF.Server.Application.Dto.Client;
using VG.CDF.Server.Application.Dto.RequestDto;
using VG.CDF.Server.Application.Dto.RequestDto.Registration;
using VG.CDF.Server.Application.Dto.ResponseDto;
using VG.CDF.Server.Domain.Entities;
using File = VG.CDF.Server.Domain.Entities.File;

namespace VG.CDF.Server.Infrastructure.Mapping
{
   public class SourceMappingProfiler : Profile
    {
        public SourceMappingProfiler()
        {
            //map1.ForMember(dest => dest.Time, opt => opt.MapFrom(src => src.Timestamp));
            //map2.ForSourceMember(x => x.UsersFactories, y => y.DoNotValidate());
            //map2.ForSourceMember(x => x.EnterpriseActionsInfo, y => y.DoNotValidate());
            #region AlarmEvent
            CreateMap<AlarmEvent, AlarmEventRequestDto>().ReverseMap();
            CreateMap<AlarmEvent, AlarmEventResponseDto>().ReverseMap();
            CreateMap<AlarmEventRequestDto, AlarmEventResponseDto>().ReverseMap();

            CreateMap<AlarmEventDescription, AlarmEventDescriptionRequestDto>().ReverseMap();
            CreateMap<AlarmEventDescription, AlarmEventDescriptionResponseDto>().ReverseMap();
            CreateMap<AlarmEventDescriptionRequestDto, AlarmEventDescriptionResponseDto>().ReverseMap();

            CreateMap<AlarmEventLive, AlarmEventLiveRequestDto>().ReverseMap();
            CreateMap<AlarmEventLive, AlarmEventLiveResponseDto>().ReverseMap();
            CreateMap<AlarmEventLiveRequestDto, AlarmEventLiveResponseDto>().ReverseMap();
            #endregion

            #region Process
            CreateMap<Process, DeviceResponseDto>().ReverseMap();
            CreateMap<Process, DeviceRequestDto>().ReverseMap();
            CreateMap<DeviceResponseDto, DeviceRequestDto>().ReverseMap();

            CreateMap<ProcessDescription, DeviceDescriptionResponseDto>().ReverseMap();
            CreateMap<ProcessDescription, DeviceDescriptionRequestDto>().ReverseMap();
            CreateMap<DeviceDescriptionResponseDto, DeviceDescriptionRequestDto>().ReverseMap();
            #endregion

            #region Project
            var map2 = CreateMap<Project, FactoryResponseDto>();
            map2.ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description)).ReverseMap();
            map2.ForMember(dest => dest.ExternalId, opt => opt.MapFrom(src => src.ExternalId)).ReverseMap();
            map2.ForMember(dest => dest.UtcOffset, opt => opt.MapFrom(src => src.UtcOffset)).ReverseMap();
            map2.ForMember(dest => dest.EnterpriseActionsInfo, opt => opt.MapFrom(src => src.ProjectActionsInfo)).ReverseMap();
            CreateMap<Project, FactoryRequestDto>().ReverseMap();
            CreateMap<FactoryResponseDto, FactoryRequestDto>().ReverseMap();

            CreateMap<ProjectActionsInfo, FactoryActionsInfoResponseDto>().ReverseMap();
            CreateMap<ProjectActionsInfo, FactoryActionsInfoRequestDto>().ReverseMap();
            CreateMap<FactoryActionsInfoResponseDto, FactoryActionsInfoRequestDto>().ReverseMap();

            #endregion

            #region ProjectActionsInfo



            #endregion

            #region Language
            CreateMap<DescriptionsLanguage, DescriptionsLanguageRequestDto>().ReverseMap();
            CreateMap<DescriptionsLanguage, LanguageResponseDto>().ReverseMap();
            CreateMap<DescriptionsLanguageRequestDto, LanguageResponseDto>().ReverseMap();
            #endregion

            #region ParameterGroup
            CreateMap<ParameterGroup, ParameterGroupRequestDto>().ReverseMap();
            CreateMap<ParameterGroup, ParameterGroupResponseDto>().ReverseMap();
            CreateMap<ParameterGroupResponseDto, ParameterGroupRequestDto>().ReverseMap();
            #endregion

            #region User
            CreateMap<User, UserResponseDto>().ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role)).ReverseMap();
            CreateMap<User, UserRequestDto>().ReverseMap();
            CreateMap<UserResponseDto, UserRequestDto>().ReverseMap();
            #endregion

            #region Role
            CreateMap<Role, RoleResponseDto>().ReverseMap();
            CreateMap<Role,RoleRequestDto>().ReverseMap();
            CreateMap<RoleResponseDto, RoleRequestDto>().ReverseMap();
            #endregion

            #region Tag
            CreateMap<Parameter, TagParamResponseDto>().ReverseMap();
            CreateMap<Parameter, TagParamRequestDto>().ReverseMap();
            CreateMap<TagParamResponseDto, TagParamRequestDto>().ReverseMap();

            CreateMap<ParameterValue, TagLiveResponseDto>().ReverseMap();
            CreateMap<ParameterValue, TagLiveRequestDto>().ReverseMap();
            CreateMap<TagLiveResponseDto, TagLiveRequestDto>().ReverseMap();

            CreateMap<ParameterValuesGroup, TagsGroupResponseDto>().ReverseMap();
            CreateMap<ParameterValuesGroup, TagsGroupRequestDto>().ReverseMap();
            CreateMap<TagsGroupResponseDto, TagsGroupRequestDto>().ReverseMap();

            var map8 = CreateMap<ParameterValuesGroup, TagsGroupRequestDto>();
            map8.ForMember(dest => dest.TagLiveRequestDtos, opt => opt.MapFrom(src => src.ParameterValues));

            var map9 = CreateMap<TagsGroupRequestDto, ParameterValuesGroup>();
            map9.ForMember(dest => dest.ParameterValues, opt => opt.MapFrom(src => src.TagLiveRequestDtos));

            CreateMap<ParameterDescription, TagParamDescriptionRequestDto>().ReverseMap();
            CreateMap<ParameterDescription, TagParamDescriptionResponseDto>().ReverseMap();
            CreateMap<TagParamDescriptionResponseDto, TagParamDescriptionRequestDto>().ReverseMap();

            #endregion

            #region Reports
            CreateMap<ParameterReport, TagParamReportRequestDto>().ReverseMap();
            CreateMap<ParameterReport, TagParamReportResponseDto>().ReverseMap();
            CreateMap<TagParamReportResponseDto, TagParamRequestDto>().ReverseMap();

            CreateMap<ReportSchema, ReportSchemaRequestDto>().ReverseMap();
            CreateMap<ReportSchema, ReportSchemaResponseDto>().ReverseMap();
            CreateMap<ReportSchemaResponseDto, TagParamRequestDto>().ReverseMap();


            #endregion

            #region User

            var map13 = CreateMap<DescriptionDto, ProcessDescription>().ReverseMap();
            map13.ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));
            map13.ForMember(dest => dest.LanguageLabel, opt => opt.MapFrom(src => src.DescriptionsLanguage.Label));
            map13.ForMember(dest => dest.LanguageExternalId, opt => opt.MapFrom(src => src.DescriptionsLanguage.ExternalId));

            var map11 = CreateMap<DeviceWithDescriptionsDto,Process>().ReverseMap();
            map11.ForMember(dest => dest.DeviceDescriptions, opt => opt.MapFrom(src => src.DeviceDescriptions));

            var map12 = CreateMap<DescriptionDto, TagParamDescriptionResponseDto>().ReverseMap();
            map12.ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));
            map12.ForMember(dest => dest.LanguageLabel, opt => opt.MapFrom(src => src.DescriptionsLanguage.LanguageLabel));
            map12.ForMember(dest => dest.LanguageExternalId, opt => opt.MapFrom(src => src.DescriptionsLanguage.LanguageExternalId));



            #endregion

            CreateMap<Folder, FolderResponseDto>().ReverseMap();
            CreateMap<Folder, FolderRequestDto>().ReverseMap();

            CreateMap<File, FileResponseDto>().ReverseMap();
            CreateMap<File, FileRequestDto>().ReverseMap();

            #region DTO
            var map1 = CreateMap<UserRegistrationRequestDto, UserRequestDto>();
            map1.ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));

            CreateMap<Role, RoleRequestDto>().ReverseMap();

            #endregion
        }

    }
}
