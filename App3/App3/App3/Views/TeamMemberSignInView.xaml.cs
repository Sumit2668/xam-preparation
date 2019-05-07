using App3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace App3.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TeamMemberSignInView : ContentPage
	{
		public TeamMemberSignInView ()
		{
			InitializeComponent ();
            
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
            var vm = App.AppSetup.SignInViewModel;
            vm.EmployeeId = "";
            vm.IsEnableSignIn = vm.TeamMembers.Count > 0 ? true : false;
            BindingContext = App.AppSetup.SignInViewModel;
        }

        protected override void OnAppearing()
        {
           // App.AppSetup.SignInViewModel.GetAllEmployeeListCommand.Execute(null);
        }
        private void Lst_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            ((Xamarin.Forms.ListView)sender).SelectedItem = null;
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var vm = App.AppSetup.SignInViewModel;
            var item = ((Image)sender).BindingContext as EmployeeMdl;
            vm.TeamMember = new EmployeeMdl();
            vm.TeamMember = item;
            //vm.RemoveCommand.Execute(null);
        }

        private void Back_Tapped(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void AddMore_Tapped(object sender, EventArgs e)
        {
            //App.AppSetup.SignInViewModel.ECodeVisible = true;
            //entEmpId.Focus();
        }

        private void Bussy_Tapped(object sender, EventArgs e)
        {
            var item = ((Image)sender).BindingContext as EmployeeMdl;
            FileImageSource source = (FileImageSource)((Image)sender).Source;
            ((Image)sender).Source = source.File == "chackbox.png" ? "checkboxgreen.png" : "chackbox.png";
            var vm = App.AppSetup.SignInViewModel;
            vm.TeamMember = item;
            //if (source.File == "chackbox.png")
            //{
            //    vm.AddEmployeeCommand.Execute(null);
            //}
            //else
            //{
            //    vm.RemoveEmployeeCommand.Execute(null);
            //}
        }
    }
}