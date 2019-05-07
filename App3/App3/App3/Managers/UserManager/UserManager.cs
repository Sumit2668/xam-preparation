using App3.Managers.Providers;
using App3.Managers.SettingsManager;
using System;
using System.Collections.Generic;
using System.Text;

namespace App3.Managers.UserManager
{
    public class UserManager : IUserManager
    {
        private readonly IApiProvider _apiProvider;
        private readonly ISettingsManager _settingsManager;
        //private readonly ILocationProvider _locationProvider;

        public UserManager(IApiProvider apiProvider, ISettingsManager settingsManager)/*, ILocationProvider LocationProvider)*/
        {
            _apiProvider = apiProvider;
            _settingsManager = settingsManager;
        }
    }
}
