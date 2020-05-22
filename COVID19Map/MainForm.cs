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
        private Model model;

        public MainForm()
        {
            InitializeComponent();

            model = new Model();
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
            Mark.Font = DefaultFont;
            var marks = new GMapOverlay("COVIDMarks");
            foreach (var countryData in model.GetCOVIDData())
            {
                marks.Markers.Add(new Mark(countryData.Name,
                    new GMap.NET.PointLatLng(countryData.Latitude, countryData.Longitude), countryData.CasesCount));
            }
            gMapControl1.Overlays.Add(marks);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            InitMap();
            SetMarks();
        }
    }
}
