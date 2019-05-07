using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace App3.Models
{
    public  class ListGroup : ObservableCollection<Property>, INotifyPropertyChanged
    {

        public ListGroup(string title, string shortname, bool expanded = false)
        {
            Title = title;
            ShortName = shortname;
            Expanded = expanded;
        }

        private bool _expanded;
        public string Title { get; set; }
        public string ShortName { get; set; }

        public string TitleWithItemCount
        {
            get { return string.Format(Title); }
        }

        public bool Expanded
        {
            get { return _expanded; }
            set
            {
                if (_expanded != value)
                {
                    _expanded = value;
                    OnPropertyChanged("Expanded");
                    OnPropertyChanged("StateIcon");
                }
            }
        }

        public string StateIcon
        {
            get { return Expanded ? "icon.png" : "icon.png"; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private Property _oldnot;
        public void ShowOrHideFoods(Property not)
        {
            if (_oldnot == not)
            {
                // click twice on the same item will hide it
                not.IsVisible = !not.IsVisible;
            }
            else
            {
                if (_oldnot != null)
                {
                    // hide previous selected item
                    _oldnot.IsVisible = false;
                }
                // show selected item
                not.IsVisible = true;
            }

            _oldnot = not;
        }
    }
}