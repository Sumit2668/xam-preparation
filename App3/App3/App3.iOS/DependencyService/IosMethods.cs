using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App3.iOS.DependencyService;
using App3.NativeMethods;
using BigTed;
using Foundation;
using UIKit;


[assembly: Xamarin.Forms.Dependency(typeof(IosMethods))]
namespace App3.iOS.DependencyService
{
    public class IosMethods: IAndroidMethods
    {
       public string GetIdentifier()
        {
            var id = UIKit.UIDevice.CurrentDevice.IdentifierForVendor.AsString();
            return id;
        }

        public void ShowToast(string msg)
        {
            BTProgressHUD.ShowToast(msg, false, 50);
        }
      
    }
}