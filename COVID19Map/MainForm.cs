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
        private readonly string pluginsHelpText = "Чтобы добавить новый способ подсчета статистики, нужно добавить ваш .dll в папку StatPlugins";
        private readonly string pluginRequirementsText = "Требования к плагину:\n1. должна использоваться StatsResources.dll\n2. должен быть хотя бы один класс, реализующий интерфейс IStatPlugin"; 

        public MainForm(IParser parser, IMarkLocalization localization)
        {
            InitializeComponent();

            Model = new Model(parser);
            InitMap();
            SetMarks(localization);
            AddStats();
        }

        private void pluginsInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var message = new StringBuilder();
            message.AppendLine(pluginsHelpText);
            message.AppendLine(pluginRequirementsText);

            MessageBox.Show(message.ToString(), pluginsInfoToolStripMenuItem.Text,
                MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void SetMarks(IMarkLocalization localization)
        {
            Mark.Localization = localization;
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

        private void AddStats()
        {
            foreach (var stat in Model.StatPlugins)
            {
                var menuItem = new ToolStripMenuItem
                {
                    Name = stat.GetType().Name,
                    Text = stat.GetLabel(),
                    Size = new Size(137, 22),
                };
                menuItem.Click += new EventHandler((sender, e) => ShowStatistic(stat.GetStatistic(Model.GetCOVIDData().ToList()), stat.GetLabel()));
                statisticsMenu.DropDownItems.Add(menuItem);
            }
            pluginsInfoToolStripMenuItem.Name = "pluginsInfoToolStripMenuItem";
            pluginsInfoToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            pluginsInfoToolStripMenuItem.Text = "Помощь";
            pluginsInfoToolStripMenuItem.Click += new System.EventHandler(pluginsInfoToolStripMenuItem_Click);
            statisticsMenu.DropDownItems.Add(pluginsInfoToolStripMenuItem);
        }

        private void ShowStatistic(string statistic, string caption)
        {
            var messageBox = MessageBox.Show(statistic, caption, MessageBoxButtons.OK);
        }
    }
}
