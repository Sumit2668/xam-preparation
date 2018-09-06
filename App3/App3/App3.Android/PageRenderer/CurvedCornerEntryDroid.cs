using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using App3.CustomRenderered;
using App3.Droid.DependencyService;
using App3.Droid.PageRenderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CurvedCornerEntry), typeof(CurvedCornerEntryDroid))]
namespace App3.Droid.PageRenderer
{
    public class CurvedCornerEntryDroid : EntryRenderer
    {
        private CurvedCornerEntry element;
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement != null || e.NewElement == null)
                return;
            element = (CurvedCornerEntry)Element;
            CurvePaint(element);
            // AddImage();

        }

        private void CurvePaint(CurvedCornerEntry view)
        {
            if (view.IsCurvedCornersEnabled)
            {
                // creating gradient drawable for the curved background
                var _gradientBackground = new GradientDrawable();
                _gradientBackground.SetShape(ShapeType.Rectangle);
                _gradientBackground.SetColor(view.BackgroundColor.ToAndroid());
                // Thickness of the stroke line
                _gradientBackground.SetStroke(view.BorderWidth, view.BorderColor.ToAndroid());
                // Radius for the curves
                _gradientBackground.SetCornerRadius(DpToPixels(this.Context,
                        Convert.ToSingle(view.CornerRadius)));
                // set the background of the label
                Control.SetBackground(_gradientBackground);
                Control.SetCursorVisible(view.CursorVisible);
            }
            // Set padding for the internal text from border
            Control.SetPadding(
            (int)DpToPixels(this.Context, Convert.ToSingle(12)),
            Control.PaddingTop,
            (int)DpToPixels(this.Context, Convert.ToSingle(12)),
            Control.PaddingBottom);
            AddImage();
        }


        private void AddImage()
        {
            var editText = Control;
            if (!string.IsNullOrEmpty(element.LeftImage) || !string.IsNullOrEmpty(element.RightImage))
                switch (element.ImageAlignment)
                {
                    case ImageEntryAlignment.Left:
                        editText.SetCompoundDrawablesWithIntrinsicBounds(GetDrawable(element.LeftImage), null, null, null);
                        break;
                    case ImageEntryAlignment.Right:
                        editText.SetCompoundDrawablesWithIntrinsicBounds(null, null, GetDrawable(element.RightImage), null);
                        break;
                    case ImageEntryAlignment.Both:
                        editText.SetCompoundDrawablesWithIntrinsicBounds(GetDrawable(element.LeftImage), null, RightGetDrawable(element.RightImage), null);
                        break;
                }
            editText.CompoundDrawablePadding = 25;
            //Control.Background.SetColorFilter(element.LineColor.ToAndroid(), PorterDuff.Mode.SrcAtop);
        }

        public static float DpToPixels(Context context, float valueInDp)
        {
            DisplayMetrics metrics = context.Resources.DisplayMetrics;
            return TypedValue.ApplyDimension(ComplexUnitType.Dip, valueInDp, metrics);
        }



        private BitmapDrawable GetDrawable(string imageEntryImage)
        {
            try
            {
                imageEntryImage = imageEntryImage.Replace(".jpg", "").Replace(".png", "");
                int id = (int)typeof(Resource.Drawable).GetField(imageEntryImage).GetValue(null);
                var myImage = BitmapFactory.DecodeResource(Forms.Context.Resources, id);
                return new BitmapDrawable(Resources, Bitmap.CreateScaledBitmap(myImage, element.ImageWidth * 2, element.ImageHeight * 2, true));
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private BitmapDrawable RightGetDrawable(string imageEntryImage)
        {
            imageEntryImage = imageEntryImage.Replace(".jpg", "").Replace(".png", "");
            int id = (int)typeof(Resource.Drawable).GetField(imageEntryImage).GetValue(null);
            var myImage = BitmapFactory.DecodeResource(Forms.Context.Resources, id);

            return new BitmapDrawable(Resources,
                Bitmap.CreateScaledBitmap(myImage, element.ImageWidth * 2, element.ImageHeight * 2, true));
        }
    }
}