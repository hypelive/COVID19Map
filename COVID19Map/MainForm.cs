using GMap.NET.WindowsForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COVID19Map
{
    public partial class MainForm : Form
    {
        private Model Model { get; set; }

        public MainForm()
        {
            InitializeComponent();

            Model = new Model();
            InitMap();
            SetMarks();
        }

        private void pluginsInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var messageBox = MessageBox.Show("help");
        }

        private void InitMap()
        {
            gMapControl1.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            gMapControl1.Zoom = 1;
            gMapControl1.MaxZoom = 15;
            gMapControl1.MinZoom = 1;

            gMapControl1.Dock = DockStyle.Fill;

            gMapControl1.MapProvider = GMap.NET.MapProviders.GMapProviders.GoogleMap;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
        }

        private void SetMarks()
        {
            Mark.Localization = new EngMarkLocalization();
            Mark.Font = DefaultFont;

            var marks = new GMapOverlay("COVIDMarks");
            foreach (var countryData in Model.GetCOVIDData())
            {
                marks.Markers.Add(new Mark(countryData.Name,
                    new GMap.NET.PointLatLng(countryData.Latitude, countryData.Longitude),
                    countryData.CasesCount, countryData.СonvalesCount, countryData.DiedCount));
            }
            gMapControl1.Overlays.Add(marks);

            foreach (var mark in marks.Markers)
            {
                gMapControl1.UpdateMarkerLocalPosition(mark);
            }
        }
    }
}
