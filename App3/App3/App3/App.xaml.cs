using App3.DataAccessLayer;
using App3.Interfaces;
using App3.Models;
using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace App3
{
	public partial class App : Application
	{
        public static AppSetup AppSetup { get; set; }
        public static double ScreenHeight;
        public static double ScreenWidth;

        static XamCRUD xamdatabase;
        public static XamCRUD xamDatabase
        {
            get
            {
                if (xamdatabase == null)
                {
                    xamdatabase = new XamCRUD(DependencyService.Get<ISQLiteHelper>().GetLocalFilePath("xamdatabase.db3"));
                }
                return xamdatabase;
            }
        }

        public App ()
		{
			InitializeComponent();
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<AppSetup>();
            AppSetup = ServiceLocator.Current.GetInstance<AppSetup>();


            MainPage = new NavigationPage( new HomePage());
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
