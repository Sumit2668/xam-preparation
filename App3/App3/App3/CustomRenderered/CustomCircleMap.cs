using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Maps;


namespace App3.CustomRenderered
{
    public class CustomCircleMap : Map
    {
        public CustomCircle Circle { get; set; }
    }
    public class CustomCircle
    {
        public Position Position { get; set; }

        public double Radius { get; set; }
    }
}
