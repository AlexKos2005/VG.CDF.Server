using BreadCommunityWeb.Blz.Application.Dto.Client;
using BreadCommunityWeb.Blz.Application.Dto.ResponseDto.Authentication;
using BreadCommunityWeb.Blz.Application.Interfaces.Services;
using BreadCommunityWeb.Blz.Domain.Entities;
using BreadCommunityWeb.Blz.Infrastructure.Server.Configurations;
using BreadCommunityWeb.Blz.Infrastructure.Server.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BreadCommunityWeb.Blz.Application.Interfaces;
using BreadCommunityWeb.Blz.Application.TagReportTask.Commands;
using BreadCommunityWeb.Blz.Infrastructure.Server.DataContext;
using FluentValidation;

namespace BreadCommunityWeb.Blz.Server.Extentions
{
    public static class ServicesRegistration
    {
        public static void RegistrateServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ISqlDataContext, SqlDataContext>();
            services.AddTransient<IJwtService<UserAuthenticationResponseDto>, JwtService>();
            services.AddTransient<IUserService, UserService>();
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
            services.AddTransient<IReportDataService<TagParamsReportDataInfo>, TagsLiveReportDataService>();
            services.AddTransient<IReportDataService<AlarmEventsReportDataInfo>, AlarmEventLiveReportDataService>();
            services.AddTransient<IUserDataService, UserDataService>();
            services.AddTransient<ITagReportTaskService, TagReportTaskService>();
            services.AddSingleton<IWorkEmailService, WorkEmailService>();
            
        }

        public static void RegistrateValidators(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining(typeof(CreateTagReportTaskCommand),ServiceLifetime.Transient);
        }

    }
}
