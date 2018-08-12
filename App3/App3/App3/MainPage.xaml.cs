using App3.Configuration;
using App3.DataAccessLayer;
using App3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App3
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}
        //void LoginClick(object sender, EventArgs args)
        //{
        //    Button btncontrol = (Button)sender;
        //    string providername = btncontrol.Text;
        //    if (OAuthConfig.User == null)
        //    {
        //        Navigation.PushModalAsync(new ProviderLoginPage(providername));
        //    }
        //}
       
        private async void Button_Clicked(object sender, EventArgs e)
        {
            Employee em =new Employee();
            em.Name = txtname.Text;
            em.Occupation = txtpass.Text;
           await App.xamDatabase.SaveItemAsync(em);
        }

        public List<Employee> xamdata;
        private async void getbtn_Clicked(object sender, EventArgs e)
        {
            List<Employee> emdata =await App.xamDatabase.GetItemsAsync();
            xamdata = new List<Employee>();
            foreach (var item in emdata)
            {
                xamdata.Add(new Employee {Id=item.Id, Name = item.Name, Occupation = item.Occupation });
            }
            xamlist.ItemsSource = xamdata;
        }

    

        private async void xamlist_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            try
            {
                var item = (Employee)e.Item;
                Employee el = await App.xamDatabase.GetItemAsync(item.Id);
                txtname.Text = el.Name;
                txtpass.Text = el.Occupation;
                txtid.Text =   el.Id.ToString();
            }
            catch (Exception ex)
            {
            }
           
        }

        private async void UpdateId_Clicked(object sender, EventArgs e)
        {
            Employee em = new Employee();
            em.Id = Convert.ToInt32(txtid.Text);
            em.Name = txtname.Text;
            em.Occupation = txtpass.Text;
            await App.xamDatabase.SaveItemAsync(em);
        }

        private async void DeleteId_Clicked(object sender, EventArgs e)
        {
            try
            {
                Employee em = new Employee();
                em.Id = Convert.ToInt32(txtid.Text);
                em.Name = txtname.Text;
                em.Name = txtpass.Text;
                await App.xamDatabase.DeleteItemAsync(em);

            }
            catch (Exception ex)
            {
               await DisplayAlert("Error","Message - "+ex.Message,"ok");
            }
        }

        private async void GetId_Clicked(object sender, EventArgs e)
        {
            
        }
    }
}
