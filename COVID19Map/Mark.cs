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
        public static IMarkRender Render { get; set; }
        public static Font Font { get; set; }
        public float Radius
        {
            get
            {
                if (CasesCount == 0)
                {
                    return 0;
                }

                return (float)Math.Pow(Math.Log(CasesCount), 1.25);
            }
        }
        private string CountryName { get; set; }
        private float CasesCount { get; set; }

        public Mark(string countryName, PointLatLng point,
            long casesCount, long convalesCount, long diedCount) : base(point)
        {
            CountryName = countryName;
            CasesCount = casesCount;

            var radius = Radius;
            Size = new Size((int)(2 * radius), (int)(2 * radius));
            Offset = new Point((int)-radius, (int)-radius);

            if (Localization is null)
            {
                ToolTipMode = MarkerTooltipMode.Never;
                return;
            }
            ToolTip = new GMapRoundedToolTip(this) { Offset = new Point((int)radius, (int)-radius)};
            ToolTipText = $"{CountryName}\n{Localization.GetTotalCasesText()}: {casesCount}\n{Localization.GetConvalesText()}: {convalesCount}\n{Localization.GetDiedText()}: {diedCount}";
            ToolTipMode = MarkerTooltipMode.OnMouseOver;
            if (!(Font is null))
            {
                ToolTip.Font = Font;
            }
        }

        public override void OnRender(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color.DarkRed),
                LocalPosition.X, LocalPosition.Y,
                Size.Width, Size.Height);
        }
    }
}
