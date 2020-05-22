using GMap.NET;
using GMap.NET.WindowsForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COVID19Map
{
    public class Mark : GMapMarker
    {
        public static Font Font { get; set; }
        public PointLatLng Point { get; set; }
        private string CountryName { get; set; }
        private float CasesCount { get; set; }
        private float Radius
        {
            get
            {
                return (float)Math.Pow(Math.Log(CasesCount), 1.25);
            }
        }

        public Mark(string countryName, PointLatLng point, int casesCount) : base(point)
        {
            CountryName = countryName;
            Point = point;
            CasesCount = casesCount;

            //ToolTipText = CountryName;
            //ToolTipMode = MarkerTooltipMode.Always;
        }

        public override void OnRender(Graphics g)
        {
            var radius = Radius;
            g.FillEllipse(new SolidBrush(Color.DarkRed),
                LocalPosition.X - radius, LocalPosition.Y - radius,
                2 * radius, 2 * radius);
            g.DrawString($"{CasesCount}", Font, new SolidBrush(Color.White),
                LocalPosition.X - radius, LocalPosition.Y - Font.Height/2);
        }
    }
}
