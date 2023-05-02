using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadCommunityWeb.Blz.Application.EndPoints
{
   public class UserDataEndPoints
    {
        public static string GetUserFactories => "/api/UserData/GetUserFactories";

        public static string GetDevicesByFactoryId => "/api/UserData/GetDevicesByFactoryId";

        public static string GetTagParamsForDevice => "/api/UserData/GetTagParamsByDeviceId";

        public static string GetAllLanguages => "/api/Language/GetAllLanguages";

        public static string GetTagsLiveReport => "/api/Report/GetTagsLiveReport";

        public static string GetTagsLiveExcelData => "/api/Report/GetTagsLiveExcelData";

        public static string GetAlarmEventsLiveReport => "/api/Report/GetAlarmEventsLiveReport";

    }
}
