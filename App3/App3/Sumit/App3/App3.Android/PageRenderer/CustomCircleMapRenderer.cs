using System.ComponentModel;
using Android.Gms.Maps.Model;
using App3.CustomRenderered;
using App3.Droid.PageRenderer;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Maps.Android;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomCircleMap), typeof(CustomCircleMapRenderer))]
namespace App3.Droid.PageRenderer
{
    public class CustomCircleMapRenderer : MapRenderer
    {
        private CustomCircle circle;
        private bool isDrawn;

        protected override void OnElementChanged(ElementChangedEventArgs<Map> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                // Unsubscribe
            }

            if (e.NewElement != null)
            {
                var formsMap = (CustomCircleMap)e.NewElement;
                circle = formsMap.Circle;
                Control.GetMapAsync(this);
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName.Equals("VisibleRegion") && !isDrawn)
            {
                var circleOptions = new CircleOptions();
                circleOptions.InvokeCenter(new LatLng(circle.Position.Latitude, circle.Position.Longitude));
                circleOptions.InvokeRadius(circle.Radius);

                circleOptions.InvokeFillColor(0X66FF0000);
                circleOptions.InvokeStrokeColor(0X66FF0000);
                circleOptions.InvokeStrokeWidth(0);
                NativeMap.AddCircle(circleOptions);
                isDrawn = true;
            }
        }
    }
}