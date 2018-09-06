using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using App3.CustomRenderered;
using App3.iOS.PageRenderer;
using CoreAnimation;
using CoreGraphics;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CurvedCornerEntry), typeof(CurvedCornerEntryIos))]
namespace App3.iOS.PageRenderer
{
    public class CurvedCornerEntryIos : EntryRenderer
    {
        private CurvedCornerEntry element;
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || e.NewElement == null)
                return;
            element = (CurvedCornerEntry)Element;
            Paint(element);
            AddImage();
            //Control.LeftView = new UIView(new CGRect(0f, 0f, 9f, 20f));
            //Control.LeftViewMode = UITextFieldViewMode.Always;
            //Control.KeyboardAppearance = UIKeyboardAppearance.Dark;
            //Control.ReturnKeyType = UIReturnKeyType.Done;
            //Control.Layer.CornerRadius = Convert.ToSingle(view.CornerRadius);
            //Control.Layer.BorderColor = view.BorderColor.ToCGColor();
            //Control.Layer.BorderWidth = view.BorderWidth;
            //Control.ClipsToBounds = true;

        }

        private void Paint(CurvedCornerEntry view)
        {

            Control.LeftView = new UIView(new CGRect(0f, 0f, 9f, 20f));
            Control.LeftViewMode = UITextFieldViewMode.Always;
            Control.KeyboardAppearance = UIKeyboardAppearance.Dark;
            Control.ReturnKeyType = UIReturnKeyType.Done;
            Control.Layer.CornerRadius = Convert.ToSingle(view.CornerRadius);
            Control.Layer.BorderColor = view.BorderColor.ToCGColor();
            Control.Layer.BorderWidth = view.BorderWidth;
            Control.ClipsToBounds = true;
            Control.TintColor = UIColor.Clear;
        }

        private void AddImage()
        {
            var textField = Control;
            if (!string.IsNullOrEmpty(element.LeftImage) || !string.IsNullOrEmpty(element.RightImage))
                switch (element.ImageAlignment)
                {
                    case ImageEntryAlignment.Left:
                        textField.LeftViewMode = UITextFieldViewMode.Always;
                        textField.LeftView = GetImageView(element.LeftImage, element.ImageHeight, element.ImageWidth);
                        break;
                    case ImageEntryAlignment.Right:
                        textField.RightViewMode = UITextFieldViewMode.Always;
                        textField.RightView = GetImageView(element.RightImage, element.ImageHeight, element.ImageWidth);
                        break;
                    case ImageEntryAlignment.Both:
                        textField.RightViewMode = UITextFieldViewMode.Always;
                        textField.LeftViewMode = UITextFieldViewMode.Always;
                        textField.RightView = GetImageView(element.RightImage, element.ImageHeight, element.ImageWidth);
                        textField.LeftView = GetImageView(element.LeftImage, element.ImageHeight, element.ImageWidth);
                        break;
                }

            textField.BorderStyle = UITextBorderStyle.None;
            var bottomBorder = new CALayer
            {
                Frame = new CGRect(0.0f, element.HeightRequest - 1, Frame.Width, 1.0f),
                BorderWidth = 2.0f,
                BorderColor = element.BorderColor.ToCGColor()
            };

            textField.Layer.AddSublayer(bottomBorder);
            textField.Layer.MasksToBounds = true;
        }

        private UIView GetImageView(string imagePath, int height, int width)
        {
            var uiImageView = new UIImageView(UIImage.FromBundle(imagePath))
            {
                Frame = new RectangleF(0, 0, width, height)
            };
            //var objLeftView = new UIView(new Rectangle(0, 0, width + 10, height));
            //objLeftView.AddSubview(uiImageView);
            UIView objLeftView = new UIView(new System.Drawing.Rectangle(0, 0, width + 10, height));
            objLeftView.AddSubview(uiImageView);
            return objLeftView;
        }
    }

}