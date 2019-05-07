using App3.NativeMethods;
using App3.Views;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomePage : ContentPage
	{
		public HomePage ()
		{
			InitializeComponent ();
            //BindingContext = new HomePageViewModel();
            AdId.AdUnitId = "ca-app-pub-5134727995066217/2997781125";
		}

        protected override void OnAppearing()
        {
           string ss = StaticMethods.SerialNo();
           StaticMethods.ShowToast(ss);
        }
        private async void tstSQL_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        private async void tstMap_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MapLocation());
        }

        private async void btnCamera_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CameraPage());
        }

        private async void btnWService_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PickerList());
        }

        private  async void btnVPlayer_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VideoPlayer());
        }

        private async  void btnInHead_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VideoLibrary());
        }

        private async void btnbvr_Clicked(object sender, EventArgs e)
        {
           await Navigation.PushAsync(new LoginPage());
        }

        private async void Apicalling_Clicked(object sender, EventArgs e)
        {
           await Navigation.PushAsync(new TeamMemberSignInView());
           // App.AppSetup.SignInViewModel.GetAllEmployeeListCommand.Execute(null);
        }

        private async void Apipicker_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PickerList());
        }
    }

    public class HomePageViewModel:BindableObject
    {
        public string AdUnitId { get; set; } = "ca-app-pub-5134727995066217/2997781125";

        public void Test()
        {
            if (Device.RuntimePlatform == Device.iOS)
                AdUnitId = "iOS Key";
            else if (Device.RuntimePlatform == Device.Android)
                AdUnitId = "ca-app-pub-5134727995066217/2997781125";
        }
    }
}