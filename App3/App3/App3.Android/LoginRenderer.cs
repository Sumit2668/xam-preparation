using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using App3;
using App3.Configuration;
using App3.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ProviderLoginPage), typeof(LoginRenderer))]
namespace App3.Droid
{
    public class LoginRenderer : PageRenderer
    {
        bool showLogin = true;
        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);

            //Get and Assign ProviderName from ProviderLoginPage
            var loginPage = Element as ProviderLoginPage;
            string providername = loginPage.ProviderName;

            var activity = Context as Activity;
            if (showLogin && OAuthConfig.User == null)
            {
                showLogin = false;

                //Create OauthProviderSetting class with Oauth Implementation .Refer Step 6
                OAuthProviderSetting oauth = new OAuthProviderSetting();

                if (providername == "Twitter")
                {
                    var auth = oauth.LoginWithTwitter();
                    // After Twitter  login completed 
                    auth.Completed += (sender, eventArgs) =>
                    {
                        if (eventArgs.IsAuthenticated)
                        {
                            OAuthConfig.User = new UserDetails
                            {
                                // Get and Save User Details 
                                Token = eventArgs.Account.Properties["oauth_token"],
                                TokenSecret = eventArgs.Account.Properties["oauth_token_secret"],
                                TwitterId = eventArgs.Account.Properties["user_id"],
                                ScreenName = eventArgs.Account.Properties["screen_name"]
                            };

                            OAuthConfig.SuccessfulLoginAction.Invoke();
                        }
                        else
                        {
                            // The user cancelled
                        }
                    };


                    activity.StartActivity(auth.GetUI(activity));
                }
                else
                {
                    var auth = oauth.LoginWithProvider(providername);

                    // After facebook,google and all identity provider login completed 
                    auth.Completed += (sender, eventArgs) =>
                    {
                        if (eventArgs.IsAuthenticated)
                        {
                            OAuthConfig.User = new UserDetails
                            {
                                // Get and Save User Details 
                                Token = eventArgs.Account.Properties["oauth_token"],
                                TokenSecret = eventArgs.Account.Properties["oauth_token_secret"],
                                TwitterId = eventArgs.Account.Properties["user_id"],
                                ScreenName = eventArgs.Account.Properties["screen_name"]
                            };

                            OAuthConfig.SuccessfulLoginAction.Invoke();
                        }
                        else
                        {
                            // The user cancelled
                        }
                    };
                    activity.StartActivity(auth.GetUI(activity));
                }
            }
        }
    }
}