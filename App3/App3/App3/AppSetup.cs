using App3.Managers.Providers;
using App3.Managers.SettingsManager;
using App3.Managers.UserManager;
using App3.ViewModels;
using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Text;

namespace App3
{
    public class AppSetup
    {
        public static int AppLcid { get; set; } = 1033;
        public static string AppLang { get; set; } = "en";
        public static string AppToken { get; set; }

        public AppSetup()
        {
            // Services
            SimpleIoc.Default.Register<ISettingsManager, SettingsManager>();
            SimpleIoc.Default.Register<IApiProvider, ApiProvider>();
            SimpleIoc.Default.Register<IUserManager, UserManager>();
            //SimpleIoc.Default.Register<IDatabase, Database>();

            // ViewModels 
            SimpleIoc.Default.Register<SignInViewModel>();
        }

        public void ClearAll()
        {
            //Unregister
            SimpleIoc.Default.Unregister<SignInViewModel>();

            //Register

            SimpleIoc.Default.Register<SignInViewModel>();
        }


        public SignInViewModel SignInViewModel
        {
            get => SimpleIoc.Default.GetInstance<SignInViewModel>();
        }

    }
}
