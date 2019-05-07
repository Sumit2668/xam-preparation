using App3.Models;
using App3.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PickerList : ContentPage
    {

        WebServices api;
        private ObservableCollection<ListGroup> _allGroups;
        private ObservableCollection<ListGroup> _expandedGroups;
        public PickerList ()
		{
			InitializeComponent ();
            Device.BeginInvokeOnMainThread(async () =>
            {
                await PrepareNotificationData();
            });
        }
        private async Task PrepareNotificationData()
        {
            api = new WebServices();
            MainHeading notification = await api.ControlDetails("Picker");
            ObservableCollection<ListGroup> notGroup = new ObservableCollection<ListGroup>();
            foreach (var item in notification.headings)
            {
                ListGroup group = new ListGroup(item.name, "o");
                foreach (var item2 in item.properties)
                {
                    group.Add(new Property() { prop_name = item2.prop_name, prop_desc = ":" + item2.prop_desc });
                }
                notGroup.Add(group);
            }

            _allGroups = notGroup;
            UpdateListContent();
        }

        private void HeaderTapped(object sender, EventArgs args)
        {
            try
            {
                int selectedIndex = _expandedGroups.IndexOf(
                ((ListGroup)((Button)sender).CommandParameter));
                _allGroups[selectedIndex].Expanded = !_allGroups[selectedIndex].Expanded;

                UpdateListContent();
            }
            catch (Exception ex)
            {
                DisplayAlert("Message", ex.Message, "OK");
            }
        }
        private void UpdateListContent()
        {
            try
            {
                _expandedGroups = new ObservableCollection<ListGroup>();
                foreach (ListGroup notgroup in _allGroups)
                {

                    //Create new FoodGroups so we do not alter original list
                    ListGroup newGroup = new ListGroup(notgroup.Title, "o", notgroup.Expanded);
                    //Add the count of food items for Lits Header Titles to use
                    if (notgroup.Expanded)
                    {
                        foreach (Property n in notgroup)
                        {
                            newGroup.Add(n);
                        }
                    }
                    _expandedGroups.Add(newGroup);
                }
                MainList.ItemsSource = _expandedGroups;
            }
            catch (Exception ex)
            {
                DisplayAlert("Message", ex.Message, "OK");
            }

        }
    }
}
