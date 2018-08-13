using App3.CustomRenderered;
using Plugin.Geolocator;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace App3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapLocation : ContentPage
    {
        public MapLocation()
        {
            InitializeComponent();
            PreInitioalize();
        }
        private void PreInitioalize()
        {
            var pin = new Pin
            {
                Type = PinType.Place,
                Position = new Position(37.79752, -122.40183),
                Label = "Xamarin San Francisco Office",
                Address = "394 Pacific Ave, San Francisco CA"
            };

            var position = new Position(37.79752, -122.40183);
            customMap.Circle = new CustomCircle
            {
                Position = position,
                Radius = 1000
            };

            customMap.Pins.Add(pin);
            customMap.MoveToRegion(MapSpan.FromCenterAndRadius(position, Distance.FromMiles(1.0)));
        }
        private async void OnButtonClicked(object sender, EventArgs e)
        {


            try
            {
                var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Location);
                if (status != PermissionStatus.Granted)
                {
                    if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Location))
                    { await DisplayAlert("Need location", "Gunna need that location", "OK"); }
                    var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Location);
                    //Best practice to always check that the key exists 
                    if (results.ContainsKey(Permission.Location))
                        status = results[Permission.Location];
                }
                if (status == PermissionStatus.Granted)
                {
                    var results = await CrossGeolocator.Current.GetPositionAsync(TimeSpan.FromMilliseconds(1000));
                    LatitudeLabel.Text = results.Latitude.ToString();
                    LogitudeLabel.Text= results.Longitude.ToString();
                    //MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(37, -122), Distance.FromMiles(0.3)));
                    var pin = new Pin
                    {
                        Type = PinType.Place,
                        Position = new Position(results.Latitude, results.Longitude),
                        Label = "Xamarin San Francisco Office",
                        Address = "394 Pacific Ave, San Francisco CA"
                    };

                    var position = new Position(results.Latitude, results.Longitude);
                    customMap.Circle = new CustomCircle
                    {
                        Position = position,
                        Radius = 1000
                    };

                    customMap.Pins.Add(pin);
                    customMap.MoveToRegion(MapSpan.FromCenterAndRadius(position, Distance.FromMiles(1.0)));

                }
                else if (status != PermissionStatus.Unknown)
                {
                    await DisplayAlert("Location Denied", "Can not continue, try again.", "OK");
                }
            }
            catch (Exception ex)
            {
                LatitudeLabel.Text = "Error: " + ex.Message;
            }
        }
    }
}