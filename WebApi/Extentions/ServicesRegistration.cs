using System;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using VG.CDF.Server.Application.Companies.Commands;
using VG.CDF.Server.Application.Dto;
using VG.CDF.Server.Application.Dto.Client;
using VG.CDF.Server.Application.Dto.ResponseDto;
using VG.CDF.Server.Application.Dto.ResponseDto.Authentication;
using VG.CDF.Server.Application.Interfaces;
using VG.CDF.Server.Application.Interfaces.Services;
using VG.CDF.Server.Infrastructure.Services;
using VG.CDF.Server.WebApi.DataBaseContext;


namespace VG.CDF.Server.WebApi.Controllers
{
    public static class ServicesRegistration
    {
        public static void RegistrateServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ISqlDataContext, SqlDataContext>();
            services.AddTransient<ISaveable<AlarmEventLiveDto>, AlarmEventService>();
            services.AddTransient<ISaveable<ParameterValuesGroupDto>, ParameterValuesGroupService>();
            services.AddTransient<IJwtService<UserAuthenticationResponseDto>, JwtService>();
            services.AddTransient<IReportDataService<ProcessParametersReportDataInfo>, ParameterValueReportDataService>();
            services.AddTransient<IReportDataService<AlarmEventsReportDataInfo>, AlarmEventLiveReportDataService>();
            /*services.AddTransient<IUserService, UserService>();
            services.AddTransient<IFactoryService, FactoryService>();
            services.AddTransient<ITagsLiveService, TagsLiveService>();
            services.AddTransient<ITagParamDescriptionService, TagParamDescriptionService>();
            services.AddTransient<IDeviceDescriptionService, DeviceDescriptionService>();
            services.AddTransient<IAlarmEventDescriptionService, AlarmEventDescriptionService>();
            services.AddTransient<IAlarmEventLiveService, AlarmEventLiveService>();
            services.AddTransient<IAlarmEventService, AlarmEventService>();
            services.AddTransient<IDeviceService, DeviceService>();
            services.AddTransient<IFactoryActionsInfoService, FactoryActionsInfoService>();
            services.AddTransient<IFactoryService, FactoryService>();
            services.AddTransient<ILanguageService, LanguageService>();
            services.AddTransient<IParameterGroupService, ParameterGroupService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<ITagParamService, TagParamService>();
            services.AddTransient<ITagsGroupService, TagsGroupService>();
            services.AddTransient<ITagsLiveService, TagsLiveService>();
            services.AddTransient<IReportDataService<ProcessParametersReportDataInfo>, ParameterValueReportDataService>();
            services.AddTransient<IReportDataService<AlarmEventsReportDataInfo>, AlarmEventLiveReportDataService>();
            services.AddTransient<IUserDataService, UserDataService>();
            services.AddTransient<ITagReportTaskService, TagReportTaskService>();
            services.AddSingleton<IWorkEmailService, WorkEmailService>();*/

        }

        public static void RegistrateValidators(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining(typeof(CreateCompanyCommand),ServiceLifetime.Transient);
            
        }
        
        public static void RegistrateAutomapper(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

    }
}
