﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3.CustomControls
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UnderLineLabel  : ContentView
	{
		public UnderLineLabel  ()
		{
			InitializeComponent ();
        }
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        public static BindableProperty TextProperty = BindableProperty.Create(nameof(Text),
                                                  typeof(string),
                                                  typeof(UnderLineLabel),
                                                  defaultBindingMode: BindingMode.TwoWay,
                                                  propertyChanged: (bindable, oldVal, newVal) =>
                                                  {
                                                      var matEntry = (UnderLineLabel)bindable;
                                                      matEntry.customLabel.Text = (string)newVal;
                                                  });
        public Color LineColor
        {
            get { return (Color)GetValue(LineColorProperty); }
            set { SetValue(LineColorProperty, value); }
        }
        public static BindableProperty LineColorProperty = BindableProperty.Create(nameof(LineColor),
                                                  typeof(Color),
                                                  typeof(UnderLineLabel),
                                                   Color.Default,
                                                  defaultBindingMode: BindingMode.TwoWay,
                                                  propertyChanged: (bindable, oldVal, newVal) =>
                                                  {
                                                      var matEntry = (UnderLineLabel)bindable;
                                                      matEntry.customBox.BackgroundColor = (Color)newVal;
                                                  });

        public static readonly BindableProperty TextColorProperty =
          BindableProperty.Create(
              nameof(TextColor),
              typeof(Color),
              typeof(UnderLineLabel),
              Color.Default,
              defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: (bindable, oldVal, newVal) =>
            {
                var matEntry = (UnderLineLabel)bindable;
                matEntry.customLabel.TextColor = (Color)newVal;
            });

        public Color TextColor
        {
            get { return (Color)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }

        public static BindableProperty FontSizeProperty = BindableProperty.Create(nameof(FontSize),
                                                  typeof(double),
                                                  typeof(UnderLineLabel),
                                                  defaultBindingMode: BindingMode.TwoWay,
                                                  propertyChanged: (bindable, oldVal, newVal) =>
                                                  {
                                                      var matEntry = (UnderLineLabel)bindable;
                                                      matEntry.FontSize= (double)newVal;
                                                  });

        public double FontSize
        {
            get { return (double)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }

    }
}