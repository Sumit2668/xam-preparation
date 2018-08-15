using Plugin.MediaManager;
using Plugin.MediaManager.Abstractions;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class VideoPlayer : ContentPage
    {
        private IPlaybackController PlaybackController => CrossMediaManager.Current.PlaybackController;

        public VideoPlayer ()
		{
			InitializeComponent ();
            this.volumeLabel.Text = "Volume (0-" + CrossMediaManager.Current.VolumeManager.MaxVolume + ")";
            //Initialize Volume settings to match interface
            int.TryParse(this.volumeEntry.Text, out var vol);
            CrossMediaManager.Current.VolumeManager.CurrentVolume = vol;
            CrossMediaManager.Current.VolumeManager.Mute = false;

            CrossMediaManager.Current.PlayingChanged += (sender, e) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    ProgressBar.Progress = e.Progress;
                    Duration.Text = "" + e.Duration.TotalSeconds + " seconds";
                });
            };
        }

        protected override void OnAppearing()
        {
            videoView.Source = "http://clips.vorwaerts-gmbh.de/big_buck_bunny.mp4";
        }

        void PlayClicked(object sender, System.EventArgs e)
        {
            PlaybackController.Play();
        }

        void PauseClicked(object sender, System.EventArgs e)
        {
            PlaybackController.Pause();
        }

        void StopClicked(object sender, System.EventArgs e)
        {
            PlaybackController.Stop();
        }
        private void SetVolumeBtn_OnClicked(object sender, EventArgs e)
        {
            int.TryParse(this.volumeEntry.Text, out var vol);
            CrossMediaManager.Current.VolumeManager.CurrentVolume = vol;
        }

        private void MutedBtn_OnClicked(object sender, EventArgs e)
        {
            if (CrossMediaManager.Current.VolumeManager.Mute)
            {
                CrossMediaManager.Current.VolumeManager.Mute = false;
                mutedBtn.Text = "Mute";
            }
            else
            {
                CrossMediaManager.Current.VolumeManager.Mute = true;
                mutedBtn.Text = "Unmute";
            }
        }

        //async void OnShowVideoLibraryClicked(object sender, EventArgs args)
        //{
        //    Button btn = (Button)sender;
        //    btn.IsEnabled = false;
        //    if (!CrossMedia.Current.IsPickVideoSupported)
        //    {
        //        await DisplayAlert("Videos Not Supported", ":( Permission not granted to videos.", "OK");
        //        return;
        //    }
        //    var file = await CrossMedia.Current.PickVideoAsync();

        //    if (file == null)
        //        return;

        //    await DisplayAlert("Video Selected", "Location: " + file.Path, "OK");
        //    file.Dispose();

        //    btn.IsEnabled = true;
        //}
    }
}