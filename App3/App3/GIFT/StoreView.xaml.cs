using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class StoreView : ContentPage
	{
        public List<Store> storelist;
		public StoreView ()
		{
            storelist = new List<Store>();
			InitializeComponent ();
            storelist.Add(new Store() { Id = 1, ImageUrl = "https://cdn.shopify.com/s/files/1/1104/4168/products/Allbirds_W_Wool_Runner_Kotare_GREY_ANGLE_0f3bfe63-ac7d-4106-9acf-d26f8414ac53_600x600.png", IsLike = true, SubTitle = "Test", Title = "Title" });
            storelist.Add(new Store() { Id = 2, ImageUrl = "https://cdn.shopify.com/s/files/1/1104/4168/products/Allbirds_W_Wool_Runner_Kotare_GREY_ANGLE_0f3bfe63-ac7d-4106-9acf-d26f8414ac53_600x600.png", IsLike = true, SubTitle = "Test", Title = "Title" });
            storelist.Add(new Store() { Id = 3, ImageUrl = "https://cdn.shopify.com/s/files/1/1104/4168/products/Allbirds_W_Wool_Runner_Kotare_GREY_ANGLE_0f3bfe63-ac7d-4106-9acf-d26f8414ac53_600x600.png", IsLike = true, SubTitle = "Test", Title = "Title" });
            storelist.Add(new Store() { Id = 4, ImageUrl = "https://cdn.shopify.com/s/files/1/1104/4168/products/Allbirds_W_Wool_Runner_Kotare_GREY_ANGLE_0f3bfe63-ac7d-4106-9acf-d26f8414ac53_600x600.png", IsLike = true, SubTitle = "Test", Title = "Title" });
            storelist.Add(new Store() { Id = 5, ImageUrl = "https://cdn.shopify.com/s/files/1/1104/4168/products/Allbirds_W_Wool_Runner_Kotare_GREY_ANGLE_0f3bfe63-ac7d-4106-9acf-d26f8414ac53_600x600.png", IsLike = true, SubTitle = "Test", Title = "Title" });
            storelist.Add(new Store() { Id = 6, ImageUrl = "https://cdn.shopify.com/s/files/1/1104/4168/products/Allbirds_W_Wool_Runner_Kotare_GREY_ANGLE_0f3bfe63-ac7d-4106-9acf-d26f8414ac53_600x600.png", IsLike = true, SubTitle = "Test", Title = "Title" });
            storelist.Add(new Store() { Id = 7, ImageUrl = "https://cdn.shopify.com/s/files/1/1104/4168/products/Allbirds_W_Wool_Runner_Kotare_GREY_ANGLE_0f3bfe63-ac7d-4106-9acf-d26f8414ac53_600x600.png", IsLike = true, SubTitle = "Test", Title = "Title" });
            storelist.Add(new Store() { Id = 8, ImageUrl = "https://cdn.shopify.com/s/files/1/1104/4168/products/Allbirds_W_Wool_Runner_Kotare_GREY_ANGLE_0f3bfe63-ac7d-4106-9acf-d26f8414ac53_600x600.png", IsLike = true, SubTitle = "Test", Title = "Title" });
            CV.ItemsSource = storelist;
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

        }
    }
}

public class Store
{
    public int Id { get; set; }
    public bool IsLike { get; set; }
    public string ImageUrl { get; set; }
    public string Title { get; set; }
    public string SubTitle { get; set; }
}