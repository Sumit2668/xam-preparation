﻿using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App3.Validators
{
    public class CompareValidationBehavior : Behavior<Entry>
    {

        public static BindableProperty TextProperty = BindableProperty.Create<CompareValidationBehavior, string>(tc => tc.Text, string.Empty, BindingMode.TwoWay);

        public string Text
        {
            get=>(string)GetValue(TextProperty);
            set=>SetValue(TextProperty, value);
        }


        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += HandleTextChanged;
            base.OnAttachedTo(bindable);
        }

        void HandleTextChanged(object sender, TextChangedEventArgs e)
        {
            bool IsValid = false;
            IsValid = e.NewTextValue == Text;
            ((Entry)sender).TextColor = IsValid ? Color.Black : Color.Red;
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= HandleTextChanged;
            base.OnDetachingFrom(bindable);
        }
    }
}
