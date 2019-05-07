using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Net;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using App3.Droid.DependencyService;
using App3.NativeMethods;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(AndroidMethods))]
namespace App3.Droid.DependencyService
{
    public class AndroidMethods: IAndroidMethods
    {
        public string GetIdentifier()
        {
            var id = Android.OS.Build.Serial;
            return id;
        }

        public void ShowToast(string msg)
        {
            Toast.MakeText(Forms.Context, msg, ToastLength.Short).Show();
        }

        public async Task<bool> CheckNewworkConnectivity()
        {
            var connectivityManager = (ConnectivityManager)Android.App.Application.Context.GetSystemService(Context.ConnectivityService);
            var activeNetworkInfo = connectivityManager.ActiveNetworkInfo;
            if (activeNetworkInfo != null && activeNetworkInfo.IsConnectedOrConnecting)
            {
                return true;
            }
            return false;
        }

    }
}