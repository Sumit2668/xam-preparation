using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App3.NativeMethods
{
    public static class StaticMethods
    {
        public static void ShowToast(string msg)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                if (Device.OS == TargetPlatform.iOS)
                {
                    DependencyService.Get<IIosMethods>().ShowToast(msg);
                }
                else
                {
                    DependencyService.Get<IAndroidMethods>().ShowToast(msg);
                }
            });
        }

        public static string SerialNo()
        {
            string Identifier = string.Empty;
            if (Device.OS == TargetPlatform.iOS)
            {
                Identifier= DependencyService.Get<IIosMethods>().GetIdentifier();
            }
            else
            {
                Identifier= DependencyService.Get<IAndroidMethods>().GetIdentifier();
            }
            return Identifier;
        } 
    }
}
