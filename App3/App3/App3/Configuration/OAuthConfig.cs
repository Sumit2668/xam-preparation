using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App3.Configuration
{
    public class OAuthConfig
    {

        public static HomePage _HomePage;
        static NavigationPage _NavigationPage;
        public static UserDetails User;

        public static Action SuccessfulLoginAction
        {
            get
            {
                return new Action(() =>
                {
                    _NavigationPage.Navigation.PushModalAsync(_HomePage);
                });
            }
        }

    }
}
