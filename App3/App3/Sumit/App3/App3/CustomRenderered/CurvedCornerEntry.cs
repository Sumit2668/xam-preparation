using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App3.CustomRenderered
{
   public class CurvedCornerEntry: Entry
    {
        public static readonly BindableProperty BorderColorProperty =
                      BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(CurvedCornerEntry), Color.Gray);

        public static readonly BindableProperty BorderWidthProperty =
                BindableProperty.Create(nameof(BorderWidth), typeof(int), typeof(CurvedCornerEntry), Device.OnPlatform<int>(1, 2, 2));


        public static readonly BindableProperty CornerRadiusProperty =
                BindableProperty.Create(nameof(CornerRadius), typeof(double), typeof(CurvedCornerEntry), Device.OnPlatform<double>(6, 7, 7));

        public static readonly BindableProperty IsCurvedCornersEnabledProperty =
                BindableProperty.Create(nameof(IsCurvedCornersEnabled), typeof(bool), typeof(CurvedCornerEntry), true);

        public static readonly BindableProperty LeftImageProperty =
                BindableProperty.Create(nameof(LeftImage), typeof(string), typeof(CurvedCornerEntry), string.Empty);

        public static readonly BindableProperty RightImageProperty =
            BindableProperty.Create(nameof(RightImage), typeof(string), typeof(CurvedCornerEntry), string.Empty);


        public static readonly BindableProperty ImageHeightProperty =
            BindableProperty.Create(nameof(ImageHeight), typeof(int), typeof(CurvedCornerEntry), 40);

        public static readonly BindableProperty ImageWidthProperty =
            BindableProperty.Create(nameof(ImageWidth), typeof(int), typeof(CurvedCornerEntry), 40);

        public static readonly BindableProperty ImageAlignmentProperty =
            BindableProperty.Create(nameof(ImageAlignment), typeof(ImageEntryAlignment), typeof(CurvedCornerEntry), ImageEntryAlignment.Left);

        public static readonly BindableProperty CursorVisibleProperty =
           BindableProperty.Create(nameof(CursorVisible), typeof(bool), typeof(CurvedCornerEntry), true);

        public bool CursorVisible
        {
            get => (bool)GetValue(CursorVisibleProperty);
            set => SetValue(CursorVisibleProperty, value);
        }

        public int ImageWidth
        {
            get => (int)GetValue(ImageWidthProperty);
            set => SetValue(ImageWidthProperty, value);
        }

        public int ImageHeight
        {
            get => (int)GetValue(ImageHeightProperty);
            set => SetValue(ImageHeightProperty, value);
        }

        public string LeftImage
        {
            get => (string)GetValue(LeftImageProperty);
            set => SetValue(LeftImageProperty, value);
        }

        public string RightImage
        {
            get => (string)GetValue(RightImageProperty);
            set => SetValue(RightImageProperty, value);
        }

        public ImageEntryAlignment ImageAlignment
        {
            get => (ImageEntryAlignment)GetValue(ImageAlignmentProperty);
            set => SetValue(ImageAlignmentProperty, value);
        }
        public bool IsCurvedCornersEnabled
        {
            get { return (bool)GetValue(IsCurvedCornersEnabledProperty); }
            set { SetValue(IsCurvedCornersEnabledProperty, value); }
        }
        public double CornerRadius
        {
            get { return (double)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public int BorderWidth
        {
            get { return (int)GetValue(BorderWidthProperty); }
            set { SetValue(BorderWidthProperty, value); }
        }
        public Color BorderColor
        {
            get { return (Color)GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }
        }
    }
    public enum ImageEntryAlignment
    {
        Left,
        Right,
        Both
    }
}