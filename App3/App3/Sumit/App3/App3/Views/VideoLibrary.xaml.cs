using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class VideoLibrary : ContentPage
	{
		public VideoLibrary ()
		{
			InitializeComponent ();
		}

        private void Button_Clicked(object sender, EventArgs e)
        {
            Debug.WriteLine(Media.NaturalVideoWidth + "x" + Media.NaturalVideoHeight);

            switch (Media.Stretch)
            {
                case InTheHand.Forms.Stretch.None:
                    Media.Stretch = InTheHand.Forms.Stretch.Fill;
                    break;

                case InTheHand.Forms.Stretch.Fill:
                    Media.Stretch = InTheHand.Forms.Stretch.Uniform;
                    break;

                case InTheHand.Forms.Stretch.Uniform:
                    Media.Stretch = InTheHand.Forms.Stretch.UniformToFill;
                    break;

                case InTheHand.Forms.Stretch.UniformToFill:
                    Media.Stretch = InTheHand.Forms.Stretch.None;
                    break;
            }
        }
    }
}