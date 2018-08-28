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

        private  void btnInHead_Clicked(object sender, EventArgs e)
        {
             Navigation.PushAsync(new VideoLibrary());
        }

        private void btnbvr_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginPage());
        }
    }
}