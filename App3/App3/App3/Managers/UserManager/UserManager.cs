using App3.Managers.Providers;
using App3.Managers.SettingsManager;
using App3.Models;
using App3.NativeMethods;
using App3.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

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

        #region Header
        public async Task<Dictionary<string, string>> GetHeaders()
        {
            Dictionary<string, string> header = new Dictionary<string, string>();
            //if (App.IsUnitTest)
            //{
            //    header.Add("DeviceType", "sasdf");
            //    header.Add("OSName", "asdfa");
            //    header.Add("OSVersion", "adfa");
            //    header.Add("ModelName", string.Format("{0} {1}", "", " "));
            //    //header.Add("accessToken", "5WWL9fo7E6Rtx+0il4rWA5T5agFk3ou8PH5WD3y4h40CD2MgCRoLuBHJO+Yz5TJ2");
            //    header.Add("accessToken", AppSetup.AppToken);
            //    AppSetup.AppLcid = 1033;
            //    header.Add("LCID", AppSetup.AppLcid.ToString());
            //    header.Add("Latitude", Convert.ToString(20020.00m));
            //    header.Add("Longitude", Convert.ToString(1202121m));
            //}
            //else
            //{
            //header.Add("DeviceType", DeviceInfo.Idiom);
            //header.Add("OSName", DeviceInfo.Platform);
            //header.Add("OSVersion", DeviceInfo.VersionString);
            //header.Add("ModelName", string.Format("{0} {1}", DeviceInfo.Manufacturer, DeviceInfo.Model));
            //header.Add("IMEI", Convert.ToString(deviceinfo.IMEI));
            //header.Add("accessToken", "5WWL9fo7E6Rtx+0il4rWA5T5agFk3ou8PH5WD3y4h40CD2MgCRoLuBHJO+Yz5TJ2");
            //header.Add("accessToken", AppSetup.AppToken);
            //AppSetup.AppLcid = AppSetup.AppLcid == 0 ? 1033 : AppSetup.AppLcid;
            //header.Add("LCID", AppSetup.AppLcid.ToString());
            //Device.BeginInvokeOnMainThread(async () =>
            //{
            //    var location = await Geolocation.GetLastKnownLocationAsync();
            //    if (location != null)
            //    {
            //        header.Add("Latitude", Convert.ToString(location.Latitude));
            //        header.Add("Longitude", Convert.ToString(location.Longitude));
            //    }
            //});

            return header;
        }
        #endregion

        GetAllEmployeeListResponse getAllEmployeeListResponse { get; set; }
        public GetAllEmployeeListResponse GetAllEmployeeListResponse => getAllEmployeeListResponse;

        public async Task GetAllEmployeeList(GetEmployeeRequest request, Action success, Action<GetAllEmployeeListResponse> failed)
        {
            bool IsNetwork = await DependencyService.Get<IMediaService>().CheckNewworkConnectivity();
            
            if (IsNetwork)
            {
                var url = string.Format("{0}GetAllEmployeeList", _settingsManager.ApiHost);

                await Task.Factory.StartNew(() =>
                {
                    var result = _apiProvider.Post<GetAllEmployeeListResponse, GetEmployeeRequest>(url, request, GetHeaders().Result);
                    if (result.IsSuccessful)
                    {
                        if (success != null)
                        {
                            getAllEmployeeListResponse = result.Result;
                            success.Invoke();
                        }
                    }
                    else
                    {
                        failed.Invoke(result.Result);
                    }
                });
            }
            else
            {
                GetAllEmployeeListResponse error = new GetAllEmployeeListResponse { ErrorMessage = "Internet not connected" };
                failed.Invoke(error);
            }
        }

    }
}
