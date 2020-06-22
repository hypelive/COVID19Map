using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.ToolTips;
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
        public static IMarkLocalization Localization { get; set; }
        public static Font Font { get; set; }
        private string CountryName { get; set; }
        private float CasesCount { get; set; }
        private float Radius
        {
            get
            {
                return (float)Math.Pow(Math.Log(CasesCount), 1.25);
            }
        }

        public Mark(string countryName, PointLatLng point,
            int casesCount, int convalesCount, int diedCount) : base(point)
        {
            CountryName = countryName;
            CasesCount = casesCount;

            var radius = Radius;
            Size = new Size((int)(2 * radius), (int)(2 * radius));
            Offset = new Point((int)-radius, (int)-radius);

            ToolTip = new GMapRoundedToolTip(this) { Offset = new Point((int)radius, (int)-radius), Font = Font };
            ToolTipText = $"{CountryName}\n{Localization.getTotalCasesText()}: {casesCount}\n{Localization.getConvalesText()}: {convalesCount}\n{Localization.getDiedText()}: {diedCount}";
            ToolTipMode = MarkerTooltipMode.OnMouseOver;
        }

        public override void OnRender(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color.DarkRed),
                LocalPosition.X, LocalPosition.Y,
                Size.Width, Size.Height);
            //g.DrawString($"{this.IsMouseOver}", Font, new SolidBrush(Color.White),
            //    LocalPosition.X - radius, LocalPosition.Y - Font.Height/2);
        }
    }
}
